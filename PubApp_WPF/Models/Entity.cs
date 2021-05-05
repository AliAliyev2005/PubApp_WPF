using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubApp_WPF.Models
{
    public class Entity
    {
        private static int _id = default;
        public int ID { get; set; }

        public Entity()
        {
            ID = ++_id;
        }
    }
}
