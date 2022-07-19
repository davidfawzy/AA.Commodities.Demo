using AA.CommoditiesDashboard.DataAccess.Contexts;
using AA.CommoditiesDashboard.DataAccess.Contexts.Interfaces;
using AA.CommoditiesDashboard.DataAccess.Repositories;
using AA.CommoditiesDashboard.DataAccess.Repositories.Interfaces;
using AA.CommoditiesDashboard.Services;
using AA.CommoditiesDashboard.Services.Interfaces;
using AA.CommoditiesDashboard.WebAPI.Mappings.AutoMapper.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi.Models;
namespace AA.CommoditiesDashboard.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers();
            services.AddAutoMappingSetup();
            services.AddDbContext<AnalyticsDbContext>(options => options.UseInMemoryDatabase(databaseName: "Analytics"));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IAnalyticsDbContext, AnalyticsDbContext>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IModelRepository, ModelRespository>();
            services.AddScoped<INewTradeActionRepository, NewTradeActionRepository>();
            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<ICommodityRepository, CommodityRepository>();
            services.AddScoped<IModelResultRepository, ModelResultRepository>();

            services.AddScoped<IContractService, ContractService>();
            services.AddScoped<IModelService, ModelService>();
            services.AddScoped<INewTradeActionService, NewTradeActionService>();
            services.AddScoped<IPositionService, PositionService>();
            services.AddScoped<ICommodityService, CommodityService>();
            services.AddScoped<IModelResultService, ModelResultService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AA.CommoditiesDashboard.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
             
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AA.CommoditiesDashboard.Api v1"));
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(opts => opts.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed((host) => true).AllowCredentials().WithExposedHeaders("Content-Disposition"));
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
