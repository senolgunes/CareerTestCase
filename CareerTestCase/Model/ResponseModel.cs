using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareerTestCase.Model
{
    public class Response
    {
        public bool isSucces { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
