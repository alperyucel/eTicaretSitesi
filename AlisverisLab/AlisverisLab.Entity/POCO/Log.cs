using AlisverisLab.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.Entity.POCO
{
    public class Log : IBaseEntity
    {
        public Log()
        {
            Date = DateTime.Now;
        }
        public int Id { get ; set ; }
        public int? AppUserId { get; set; }
        public DateTime Date { get; set; }
        public int LogTypeId { get; set; }
        public string Message { get; set; }

        public virtual LogType LogType { get; set; }
    }
}
