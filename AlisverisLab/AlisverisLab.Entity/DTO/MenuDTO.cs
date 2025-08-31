using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlisverisLab.Entity.DTO
{
    public class MenuDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string AreaName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        //public bool Active { get; set; }
        public DateTime CreatedTime { get; set; }
        public int OrderNumber { get; set; }

        
        public string GTitle { get; set; }
        public string GIcon { get; set; }
        public string GAreaName { get; set; }
        public string GControllerName { get; set; }
        public string GActionName { get; set; }
        public int GOrderNumber { get; set; }
    }
}
