using System;
using System.Collections.Generic;

namespace CareerTestCase.DAL.Entities
{
    public partial class Company
    {
        public Company()
        {
            Jops = new HashSet<Job>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Job> Jops { get; set; }
    }
}
