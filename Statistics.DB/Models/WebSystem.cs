using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics.DB.Models
{
    public class WebSystem
    {
        public int Id { get; set; }
        public  DateTime LastVisited { get; set; } = new DateTime();
        public WebSystem()
        {
         
        }
    }
}
