using System;

namespace AA.CommoditiesDashboard.DataAccess.Models
{
    public class ModelResult
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ContractId { get; set; }
        public decimal Price { get; set; }
        public int PositionId { get; set; }
        public int NewTradeActionId { get; set; }
        public int CommodityId { get; set; }
        public int ModelId { get; set; }
        public decimal PnlDaily { get; set; }

        public virtual Position Position { get; set; }
        public virtual NewTradeAction NewTradeAction { get; set; }
        public virtual Contract Contract { get; set; }
        public virtual Commodity Commodity { get; set; }
        public virtual Model Model { get; set; }
    }
}
