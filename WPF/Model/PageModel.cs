using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Model
{
    internal class PageModel
    {
        public int ImageID { get; set; }
        public bool favorite { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public int StatisticNum { get; set; }
    }
}
