using System;
using System.Collections.Generic;

namespace PS.Model.Models
{
    public partial class InspactionDetail
    {
        public string ID { get; set; }
        public string InspactionID { get; set; }
        public Nullable<bool> AirCompressor { get; set; }
        public Nullable<bool> Battery { get; set; }
        public Nullable<bool> BeltsAndHoses { get; set; }
        public Nullable<bool> Body { get; set; }
        public Nullable<bool> BrakeAccessories { get; set; }
        public Nullable<bool> Clutch { get; set; }
        public Nullable<bool> CouplingDevices { get; set; }
        public Nullable<bool> DefrosterOrHeater { get; set; }
        public Nullable<bool> DriveLine { get; set; }
        public Nullable<bool> Engine { get; set; }
        public Nullable<bool> Exhaust { get; set; }
        public Nullable<bool> FifthWheel { get; set; }
        public Nullable<bool> FluidLevels { get; set; }
        public Nullable<bool> FrameAndAssembly { get; set; }
        public Nullable<bool> FrontAxle { get; set; }
        public Nullable<bool> FuelTanks { get; set; }
        public Nullable<bool> Horn { get; set; }
        public Nullable<bool> LightsHeadOrStop { get; set; }
        public Nullable<bool> LightsTailOrDash { get; set; }
        public Nullable<bool> LightsTurnIndicators { get; set; }
        public Nullable<bool> LightsClearanceOrMarker { get; set; }
        public Nullable<bool> Mirrors { get; set; }
        public Nullable<bool> Muffler { get; set; }
        public Nullable<bool> OilPressure { get; set; }
        public Nullable<bool> Radiator { get; set; }
        public Nullable<bool> RearEnd { get; set; }
        public Nullable<bool> Reflectors { get; set; }
        public Nullable<bool> Starter { get; set; }
        public Nullable<bool> Steering { get; set; }
        public Nullable<bool> SuspensionSystem { get; set; }
        public Nullable<bool> TireChains { get; set; }
        public Nullable<bool> Tires { get; set; }
        public Nullable<bool> Transmission { get; set; }
        public Nullable<bool> TripRecorder { get; set; }
        public Nullable<bool> WheelsAndRims { get; set; }
        public Nullable<bool> Windows { get; set; }
        public Nullable<bool> WindshieldWipers { get; set; }
        public Nullable<bool> FireExtinguisher { get; set; }
        public Nullable<bool> FlagsOrFlaresOrFusees { get; set; }
        public Nullable<bool> ReflectiveTriangles { get; set; }
        public Nullable<bool> SpareBulbsAndFuses { get; set; }
        public Nullable<bool> SpareSealBeam { get; set; }
        public Nullable<bool> Remarks { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string ActionType { get; set; }
        public Nullable<System.DateTime> ActionDate { get; set; }
        public virtual Inspaction Inspaction { get; set; }
    }
}
