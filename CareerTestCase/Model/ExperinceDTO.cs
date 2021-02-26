using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerTestCase.Model
{
    public class ExperinceDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Title { get; set; }
        public string ConpanyName { get; set; }
        public int UserId { get; set; }
    }
}
