using System;
using System.Collections.Generic;

namespace PS.Model.Models
{
    public partial class VendorType
    {
        public VendorType()
        {
            this.Vendors = new List<Vendor>();
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string ActionType { get; set; }
        public Nullable<System.DateTime> ActionDate { get; set; }
        public virtual ICollection<Vendor> Vendors { get; set; }
    }
}
