using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerTestCase.DAL.Entities
{
    public class Apply
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int JopId { get; set; }

        public virtual Job Jop { get; set; }
        public virtual User User { get; set; }

    }
}
