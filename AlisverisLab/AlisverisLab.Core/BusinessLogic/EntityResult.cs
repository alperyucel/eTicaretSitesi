using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.Core.BusinessLogic
{
    public class EntityResult
    {
        public bool IsSuccess { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public int DataCount { get; set; }
    }
}
