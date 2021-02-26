using System;
using System.Collections.Generic;

namespace CareerTestCase.DAL.Entities
{
    public partial class Education
    {
        public int Id { get; set; }
        public string UniversityName { get; set; }
        public string DepartmanName { get; set; }
        public DateTime StarDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }

        public virtual Cv Cvs { get; set; }
    }
}
