using AA.CommoditiesDashboard.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AA.CommoditiesDashboard.Services.Models
{
    public class ModelResultDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ContractId { get; set; }
        public decimal Price { get; set; }
        public int PositionId { get; set; }
        public int NewTradeActionId { get; set; }
        public decimal PnlDaily { get; set; }

        public ContractDto Contract { get; set; }
        public PositionDto Position { get; set; }
        public NewTradeActionDto NewTradeAction { get; set; }
    }
}
