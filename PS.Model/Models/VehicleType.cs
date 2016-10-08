using System;
using System.Collections.Generic;

namespace PS.Model.Models
{
    public partial class VehicleType
    {
        public VehicleType()
        {
            this.Vehicles = new List<Vehicle>();
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string ActionType { get; set; }
        public Nullable<System.DateTime> ActionDate { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
    }
}
