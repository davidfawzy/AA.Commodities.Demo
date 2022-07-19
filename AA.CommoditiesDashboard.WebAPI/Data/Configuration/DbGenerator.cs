using AA.CommoditiesDashboard.DataAccess.Contexts;
using AA.CommoditiesDashboard.DataAccess.Models;
using AA.CommoditiesDashboard.WebAPI.Data.Models;
using AA.CommoditiesDashboard.WebAPI.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AA.CommoditiesDashboard.WebAPI.Data.Configuration
{
    public class DataGenerator
    {

        public async static Task InitializeAsync(IServiceProvider serviceProvider)
        {
            //Setting database data from csv into inmemory
            //In production or live environment will be using SQL server or ther database management systems
            using (var context = new AnalyticsDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AnalyticsDbContext>>()))
            {
                var fileDataResult = new List<ModelResults>();
                var modelResultFolderPath = Environment.CurrentDirectory + @"\Data\Files";
                var models = new List<Model>();
                var commodities = new List<Commodity>();

                foreach (var file in Directory.GetFiles(modelResultFolderPath))
                {
                    var filenames = file.Split("_");
                    var modelName = filenames[1];
                    var commodityName = filenames[2];
                    var fileResults = FileExtension.GetCSVData(file);

                    fileResults.ForEach(x =>
                    {
                        x.CommodityName = commodityName;
                        x.ModelName = modelName;
                    });

                    SetDbTablesForModelAndCommodity(models, commodities, modelName, commodityName);

                    fileDataResult.AddRange(fileResults);
                }

                var positions = fileDataResult.Select(x => x.Position).OrderBy(x => x).Distinct();
                var contracts = fileDataResult.Select(x => x.Contract).OrderBy(x => x).Distinct();
                var newTradeActions = fileDataResult.Select(x => x.NewTradeAction).OrderBy(x => x).Distinct();

                foreach (var position in positions)
                {
                    context.Position.Add(new DataAccess.Models.Position { Name = position });
                }

                foreach (var contract in contracts)
                {
                    context.Contract.Add(new DataAccess.Models.Contract { Name = contract });
                }

                foreach (var nta in newTradeActions)
                {
                    context.NewTradeAction.Add(new DataAccess.Models.NewTradeAction { Name = nta });
                }

                foreach (var com in commodities)
                {
                    context.Commodity.Add(com);
                }

                foreach (var model in models)
                {
                    context.Model.Add(model);
                }

                context.SaveChanges();

                var dbPosition = context.Position.ToList();
                var dbContract = context.Contract.ToList();
                var dbNewTradeAction = context.NewTradeAction.ToList();
                var dbCommodity = context.Commodity.ToList();
                var dbModel = context.Model.ToList();

                foreach (var modelResult in fileDataResult)
                {
                    var modelDb = new ModelResult();
                    var commodityId = dbCommodity.FirstOrDefault(c => c.Name == modelResult.CommodityName)?.Id;
                    var modelId = dbModel.FirstOrDefault(c => c.Name == modelResult.ModelName)?.Id;

                    var positionId = dbPosition.FirstOrDefault(x => x.Name == modelResult.Position)?.Id;
                    var contractId = dbContract.FirstOrDefault(x => x.Name == modelResult.Contract)?.Id;
                    var newTradeActionId = dbNewTradeAction.FirstOrDefault(x => x.Name == modelResult.NewTradeAction)?.Id;

                    modelDb.Price = modelResult.Price;
                    modelDb.PnlDaily = modelResult.PnlDaily;
                    modelDb.Date = Convert.ToDateTime(modelResult.Date);
                    modelDb.PositionId = positionId.Value;
                    modelDb.ContractId = contractId.Value;
                    modelDb.NewTradeActionId = newTradeActionId.Value;
                    modelDb.CommodityId = commodityId.Value;
                    modelDb.ModelId = modelId.Value;
                    context.ModelResult.Add(modelDb);

                    await context.SaveChangesAsync(true);
                }

                var dbModels = context.ModelResult.ToList();
            }
        }

        private static void SetDbTablesForModelAndCommodity(List<Model> models, List<Commodity> commodities, string modelName, string commodityName)
        {
            var model = new Model { Name = modelName };
            var commodity = new Commodity { Name = commodityName };

            if (!models.Contains(model))
            {
                models.Add(model);
            }

            if (!commodities.Contains(commodity))
            {
                commodities.Add(commodity);
            }
        }
    }
}