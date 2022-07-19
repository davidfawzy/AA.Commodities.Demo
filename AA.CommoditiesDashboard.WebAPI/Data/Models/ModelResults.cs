using System;

namespace AA.CommoditiesDashboard.WebAPI.Data.Models
{
    public class ModelResults
    {
        public string Date { get; set; }
        public string Contract { get; set; }
        public decimal Price { get; set; }
        public string NewTradeAction { get; set; }
        public string Position { get; set; }
        public decimal PnlDaily { get; set; }
        public string ModelName { get; set; }
        public string CommodityName { get; set; }
    }
}
