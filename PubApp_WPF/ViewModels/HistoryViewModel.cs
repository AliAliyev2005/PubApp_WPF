using PubApp_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubApp_WPF.ViewModels
{
    public class HistoryViewModel
    {
        public List<ProductHistory> ProductHistories { get; set; }
        public HistoryViewModel(List<ProductHistory> productHistories)
        {
            ProductHistories = productHistories;
        }
    }
}
