﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerTestCase.Model
{
    public class JobDTO
    {
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime ExpirationTime { get; set; }
        public int CompanyId { get; set; }
    }
}
