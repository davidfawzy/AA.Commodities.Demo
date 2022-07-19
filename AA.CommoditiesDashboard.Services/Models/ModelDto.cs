using AA.CommoditiesDashboard.Services.Models;
using System.Collections.Generic;

namespace AA.CommoditiesDashboard.Services
{
    public class ModelDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ModelResultDto> ModelResult { get; set; }
    }
}
