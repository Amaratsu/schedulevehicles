using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BusStop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //
        public virtual ICollection<Voyage> CurrentBusStopIsDepartureForVoyages { get; set; }
        public virtual ICollection<Voyage> CurrentBusStopIsArrivalForVoyages { get; set; }
    }
}
