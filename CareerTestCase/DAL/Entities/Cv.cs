using System;
using System.Collections.Generic;

namespace CareerTestCase.DAL.Entities
{
    public partial class Cv
    {
        public int UserId { get; set; }
        public string JobName { get; set; }
        public string CvName { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Experince> Experincies { get; set; }
    }
}
