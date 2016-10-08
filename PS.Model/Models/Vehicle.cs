using System;
using System.Collections.Generic;

namespace PS.Model.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            this.Inspactions = new List<Inspaction>();
            this.Issues = new List<Issue>();
        }

        public string ID { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string SerialNumber { get; set; }
        public string VehicleTypeID { get; set; }
        public string MadeByID { get; set; }
        public string VehicleModelID { get; set; }
        public string Trim { get; set; }
        public string LicensePlate { get; set; }
        public string RegistrationProvinceID { get; set; }
        public string Photo { get; set; }
        public string VehicleStatusID { get; set; }
        public string VehicleGroupID { get; set; }
        public string DriverID { get; set; }
        public string OwnershipID { get; set; }
        public string Color { get; set; }
        public string BodyTypeID { get; set; }
        public Nullable<decimal> MSRP { get; set; }
        public Nullable<decimal> Width { get; set; }
        public Nullable<decimal> Height { get; set; }
        public Nullable<decimal> Length { get; set; }
        public Nullable<decimal> InteriorVolume { get; set; }
        public Nullable<decimal> PassengerVolume { get; set; }
        public Nullable<decimal> CargoVolume { get; set; }
        public Nullable<decimal> GroundClearance { get; set; }
        public Nullable<decimal> BedLength { get; set; }
        public Nullable<decimal> CurbWeight { get; set; }
        public Nullable<decimal> GrossVehicleWeight { get; set; }
        public Nullable<decimal> TowingCapacity { get; set; }
        public Nullable<decimal> MaxPayload { get; set; }
        public Nullable<decimal> EPACity { get; set; }
        public Nullable<decimal> EPAHighway { get; set; }
        public Nullable<decimal> EPACombined { get; set; }
        public string EngineSummary { get; set; }
        public string EngineBrandID { get; set; }
        public Nullable<decimal> Bore { get; set; }
        public Nullable<decimal> Compression { get; set; }
        public Nullable<decimal> Cylinders { get; set; }
        public Nullable<decimal> Displacement { get; set; }
        public Nullable<decimal> FuelInduction { get; set; }
        public Nullable<decimal> FuelQuality { get; set; }
        public Nullable<decimal> MaxHP { get; set; }
        public Nullable<decimal> MaxTorque { get; set; }
        public Nullable<decimal> RedlineRPM { get; set; }
        public Nullable<decimal> Stroke { get; set; }
        public Nullable<decimal> Valves { get; set; }
        public string TransmissionSummary { get; set; }
        public string TransmissionBrandID { get; set; }
        public string TransmissionTypeID { get; set; }
        public Nullable<decimal> TransmissionGears { get; set; }
        public string DriveTypeID { get; set; }
        public string BrakeSystemID { get; set; }
        public Nullable<decimal> FrontTrackWidth { get; set; }
        public Nullable<decimal> RearTrackWidth { get; set; }
        public Nullable<decimal> Wheelbase { get; set; }
        public Nullable<decimal> FrontWheelDiameter { get; set; }
        public Nullable<decimal> RearWheelDiameter { get; set; }
        public Nullable<decimal> RearAxle { get; set; }
        public string FrontTireTypeID { get; set; }
        public Nullable<decimal> FrontTirePSI { get; set; }
        public string RearTireTypeID { get; set; }
        public Nullable<decimal> RearTirePSI { get; set; }
        public string FuelTypeID { get; set; }
        public Nullable<decimal> FuelTankCapacity { get; set; }
        public Nullable<decimal> OilCapacity { get; set; }
        public string PrimaryMeterID { get; set; }
        public Nullable<bool> FuelUnit { get; set; }
        public Nullable<bool> MeasurementUnit { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string ActionType { get; set; }
        public Nullable<System.DateTime> ActionDate { get; set; }
        public virtual Area Area { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Brand Brand1 { get; set; }
        public virtual HREmployee HREmployee { get; set; }
        public virtual HREmployee HREmployee1 { get; set; }
        public virtual ICollection<Inspaction> Inspactions { get; set; }
        public virtual ICollection<Issue> Issues { get; set; }
        public virtual MDFuelType MDFuelType { get; set; }
        public virtual MDTransmissionType MDTransmissionType { get; set; }
        public virtual MDVehicleBodyType MDVehicleBodyType { get; set; }
        public virtual MDVehicleBrakeSystem MDVehicleBrakeSystem { get; set; }
        public virtual MDVehicleDriveType MDVehicleDriveType { get; set; }
        public virtual MDVehicleModel MDVehicleModel { get; set; }
        public virtual VehicleGroup VehicleGroup { get; set; }
        public virtual VehicleStatu VehicleStatu { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
