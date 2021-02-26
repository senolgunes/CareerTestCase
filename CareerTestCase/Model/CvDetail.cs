using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerTestCase.Model
{
    public class CvDetail
    {
        public CvDTO  CvName { get; set; }

        public IEnumerable< EducationDTO>  Educations { get; set; }

        public IEnumerable<ExperinceDTO>   Experince{ get; set; }
    }
}
