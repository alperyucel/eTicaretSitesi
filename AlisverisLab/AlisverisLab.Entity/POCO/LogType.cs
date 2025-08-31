using AlisverisLab.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.Entity.POCO
{
    public class LogType : BaseEntity
    {
        public string LogTypeName { get; set; }

        public virtual ICollection<Log> Logs { get; set; }
    }
}
