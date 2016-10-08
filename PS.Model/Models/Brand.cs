using System;
using System.Collections.Generic;

namespace PS.Model.Models
{
    public partial class Brand
    {
        public Brand()
        {
            this.Vehicles = new List<Vehicle>();
            this.Vehicles1 = new List<Vehicle>();
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<Vehicle> Vehicles1 { get; set; }
    }
}
