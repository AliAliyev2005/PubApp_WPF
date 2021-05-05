using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubApp_WPF.Models
{
    public class ProductHistory
    {
        public string Date { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Volume { get; set; }
        private string _total;
        public string Total
        {
            get { return _total; }
            set { _total = value + " $"; }
        }
        public int Count { get; set; }
    }
}
