using System;
using System.Collections.Generic;

namespace PS.Model.Models
{
    public partial class HREmployee
    {
        public HREmployee()
        {
            this.Vehicles = new List<Vehicle>();
            this.Vehicles1 = new List<Vehicle>();
        }

        public string ID { get; set; }
        public string EmployeeTypeID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Designation { get; set; }
        public Nullable<System.DateTime> JoiningDate { get; set; }
        public Nullable<System.DateTime> LeaveDate { get; set; }
        public string CurentAddress { get; set; }
        public string ParmanentAddress { get; set; }
        public string CityID { get; set; }
        public string Country { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public string Email { get; set; }
        public string NIDNumber { get; set; }
        public string DrivingLicenceNumber { get; set; }
        public Nullable<decimal> HourlyCost { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string ActionType { get; set; }
        public Nullable<System.DateTime> ActionDate { get; set; }
        public virtual Area Area { get; set; }
        public virtual HREmployeeType HREmployeeType { get; set; }
        public virtual ICollection<Vehicle> Vehicles { get; set; }
        public virtual ICollection<Vehicle> Vehicles1 { get; set; }
    }
}
