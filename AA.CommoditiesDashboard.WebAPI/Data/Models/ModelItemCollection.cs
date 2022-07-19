using System.Collections.Generic;

namespace AA.CommoditiesDashboard.WebAPI.Data.Models
{
    public class ModelItemCollection
    {
        public ModelItem Key { get; set; }
        public List<ModelResults> Items { get; set; }
        public ModelItemCollection()
        {
            Key = new ModelItem();
            Items = new List<ModelResults>();
        }
    }
}
