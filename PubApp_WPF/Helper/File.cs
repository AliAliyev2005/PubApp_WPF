using PubApp_WPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubApp_WPF.Helper
{
    public static class File
    {
        public static void PrintVaucher(ProductHistory product)
        {
            Guid ID = Guid.NewGuid();
            using (FileStream fs = new FileStream(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
                 + "\\\\" + ID.ToString() + ".txt", FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
            {
                sw.WriteLine($"Date : {product.Date}");
                sw.WriteLine("=====================================");
                sw.WriteLine($"Name : {product.Name}");
                sw.WriteLine($"Price : {product.Price.Split()[0]} $");
                sw.WriteLine($"Volume : {product.Volume.Split()[0]} ml");
                sw.WriteLine("-------------------------------------");
                sw.WriteLine($"TOTAL : {product.Total} $");
            }
        }
    }
}
