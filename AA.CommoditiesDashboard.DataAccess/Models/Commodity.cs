using System.Collections.Generic;

namespace AA.CommoditiesDashboard.DataAccess.Models
{
    public class Commodity : BaseModel
    {
        public virtual ICollection<ModelResult> ModelResult { get; set; }
    }
}
