using System;

namespace AA.CommoditiesDashboard.DataAccess.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public BaseModel()
        {
            CreatedDate = new DateTime();
            ModifiedDate = new DateTime();
        }
    }
}
