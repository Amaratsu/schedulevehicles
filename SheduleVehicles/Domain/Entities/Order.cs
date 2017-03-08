using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public int VoyageId { get; set; }
        public enum Status
        {
            Reserved,
            BoughtOut
        }

        public Voyage Voyage { get; set; }
    }
}
