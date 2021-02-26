using System;
using System.Collections.Generic;

namespace CareerTestCase.DAL.Entities
{
    public partial class Job
    {
        public Job()
        {
            Applies = new HashSet<Apply>();
        }
        public int Id { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime ExpirationTime { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Apply> Applies { get; set; }
    }
}
