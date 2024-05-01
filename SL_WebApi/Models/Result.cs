using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SL_WebApi.Models
{
    public class Result
    {
        public bool Correct { get; set; } = false;
        public string Message { get; set; }
        public Exception Error { get; set; }
        public object Data { get; set; }
    }
}