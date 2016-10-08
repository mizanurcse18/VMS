using System;
using System.Collections.Generic;

namespace PS.Model.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            this.Vehicles = new List<Vehicle>();
        }

        public string ID { get; set; }
        public string VendorTypeID { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string CityID { get; set; }
        public string Country { get; set; }
        public string ContactPersonName { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string ActionType { get; set; }
        public Nullable<System.DateTime> ActionDate { get; set; }
        public virtual Area Area { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual VendorType VendorType { get; set; }
    }
}
