using System;
using System.Collections.Generic;

namespace CareerTestCase.DAL.Entities
{
    public partial class Experince
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Title { get; set; }
        public string ConpanyName { get; set; }
        public int UserId { get; set; }

        public virtual Cv Cvs { get; set; }
    }
}
