using System;
using System.Collections.Generic;

namespace PS.Model.Models
{
    public partial class HREmployeeType
    {
        public HREmployeeType()
        {
            this.HREmployees = new List<HREmployee>();
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<HREmployee> HREmployees { get; set; }
    }
}
