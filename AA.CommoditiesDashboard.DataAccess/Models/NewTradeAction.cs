using System;
using System.Collections.Generic;
using System.Text;

namespace AA.CommoditiesDashboard.DataAccess.Models
{
    public class NewTradeAction : BaseModel
    {
        public virtual ICollection<ModelResult> ModelResult { get; set; }
    }
}
