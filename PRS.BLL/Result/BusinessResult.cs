using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRS.BLL.Result
{
    public class BusinessResult
    {
        public object Data { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
        public string Type { get; set; }
    }
}
