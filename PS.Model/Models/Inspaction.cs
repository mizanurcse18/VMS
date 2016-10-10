using System;
using System.Collections.Generic;

namespace PS.Model.Models
{
    public partial class Inspaction
    {
        public Inspaction()
        {
            this.InspactionDetails = new List<InspactionDetail>();
        }

        public string ID { get; set; }
        public string Number { get; set; }
        public string VehicleID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<bool> IsPassed { get; set; }
        public Nullable<System.DateTime> NextDate { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string ActionType { get; set; }
        public Nullable<System.DateTime> ActionDate { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ICollection<InspactionDetail> InspactionDetails { get; set; }
    }
}
