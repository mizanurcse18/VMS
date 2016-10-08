using System;
using System.Collections.Generic;

namespace PS.Model.Models
{
    public partial class MDTransmissionType
    {
        public MDTransmissionType()
        {
            this.Vehicles = new List<Vehicle>();
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
