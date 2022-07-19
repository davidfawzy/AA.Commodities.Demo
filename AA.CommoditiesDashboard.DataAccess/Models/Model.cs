using System;
using System.Collections.Generic;

namespace AA.CommoditiesDashboard.DataAccess.Models
{
    public class Model : BaseModel
    {
        public virtual ICollection<ModelResult> ModelResult { get; set; }
    }
}
