using System;
using System.Collections.Generic;

namespace PS.Model.Models
{
    public partial class Area
    {
        public Area()
        {
            this.HREmployees = new List<HREmployee>();
            this.Vehicles = new List<Vehicle>();
            this.Vendors = new List<Vendor>();
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<HREmployee> HREmployees { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<Vendor> Vendors { get; set; }
    }
}
