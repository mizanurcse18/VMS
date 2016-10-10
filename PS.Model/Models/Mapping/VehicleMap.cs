using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PS.Model.Models.Mapping
{
    public class VehicleMap : EntityTypeConfiguration<Vehicle>
    {
        public VehicleMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.NickName)
                .HasMaxLength(50);

            this.Property(t => t.SerialNumber)
                .HasMaxLength(50);

            this.Property(t => t.VehicleTypeID)
                .HasMaxLength(36);

            this.Property(t => t.MadeByID)
                .HasMaxLength(36);

            this.Property(t => t.VehicleModelID)
                .HasMaxLength(36);

            this.Property(t => t.Trim)
                .HasMaxLength(50);

            this.Property(t => t.LicensePlate)
                .HasMaxLength(50);

            this.Property(t => t.RegistrationProvinceID)
                .HasMaxLength(36);

            this.Property(t => t.Photo)
                .HasMaxLength(50);

            this.Property(t => t.VehicleStatusID)
                .HasMaxLength(36);

            this.Property(t => t.VehicleGroupID)
                .HasMaxLength(36);

            this.Property(t => t.DriverID)
                .HasMaxLength(36);

            this.Property(t => t.OwnershipID)
                .HasMaxLength(36);

            this.Property(t => t.Color)
                .HasMaxLength(50);

            this.Property(t => t.BodyTypeID)
                .HasMaxLength(36);

            this.Property(t => t.EngineSummary)
                .HasMaxLength(200);

            this.Property(t => t.EngineBrandID)
                .HasMaxLength(36);

            this.Property(t => t.TransmissionSummary)
                .HasMaxLength(200);

            this.Property(t => t.TransmissionBrandID)
                .HasMaxLength(36);

            this.Property(t => t.TransmissionTypeID)
                .HasMaxLength(36);

            this.Property(t => t.DriveTypeID)
                .HasMaxLength(36);

            this.Property(t => t.BrakeSystemID)
                .HasMaxLength(36);

            this.Property(t => t.FrontTireTypeID)
                .HasMaxLength(36);

            this.Property(t => t.RearTireTypeID)
                .HasMaxLength(36);

            this.Property(t => t.FuelTypeID)
                .HasMaxLength(36);

            this.Property(t => t.PrimaryMeterID)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(36);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(36);

            this.Property(t => t.ActionType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Vehicle");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.NickName).HasColumnName("NickName");
            this.Property(t => t.SerialNumber).HasColumnName("SerialNumber");
            this.Property(t => t.VehicleTypeID).HasColumnName("VehicleTypeID");
            this.Property(t => t.MadeByID).HasColumnName("MadeByID");
            this.Property(t => t.VehicleModelID).HasColumnName("VehicleModelID");
            this.Property(t => t.Trim).HasColumnName("Trim");
            this.Property(t => t.LicensePlate).HasColumnName("LicensePlate");
            this.Property(t => t.RegistrationProvinceID).HasColumnName("RegistrationProvinceID");
            this.Property(t => t.Photo).HasColumnName("Photo");
            this.Property(t => t.VehicleStatusID).HasColumnName("VehicleStatusID");
            this.Property(t => t.VehicleGroupID).HasColumnName("VehicleGroupID");
            this.Property(t => t.DriverID).HasColumnName("DriverID");
            this.Property(t => t.OwnershipID).HasColumnName("OwnershipID");
            this.Property(t => t.Color).HasColumnName("Color");
            this.Property(t => t.BodyTypeID).HasColumnName("BodyTypeID");
            this.Property(t => t.MSRP).HasColumnName("MSRP");
            this.Property(t => t.Width).HasColumnName("Width");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.Length).HasColumnName("Length");
            this.Property(t => t.InteriorVolume).HasColumnName("InteriorVolume");
            this.Property(t => t.PassengerVolume).HasColumnName("PassengerVolume");
            this.Property(t => t.CargoVolume).HasColumnName("CargoVolume");
            this.Property(t => t.GroundClearance).HasColumnName("GroundClearance");
            this.Property(t => t.BedLength).HasColumnName("BedLength");
            this.Property(t => t.CurbWeight).HasColumnName("CurbWeight");
            this.Property(t => t.GrossVehicleWeight).HasColumnName("GrossVehicleWeight");
            this.Property(t => t.TowingCapacity).HasColumnName("TowingCapacity");
            this.Property(t => t.MaxPayload).HasColumnName("MaxPayload");
            this.Property(t => t.EPACity).HasColumnName("EPACity");
            this.Property(t => t.EPAHighway).HasColumnName("EPAHighway");
            this.Property(t => t.EPACombined).HasColumnName("EPACombined");
            this.Property(t => t.EngineSummary).HasColumnName("EngineSummary");
            this.Property(t => t.EngineBrandID).HasColumnName("EngineBrandID");
            this.Property(t => t.Bore).HasColumnName("Bore");
            this.Property(t => t.Compression).HasColumnName("Compression");
            this.Property(t => t.Cylinders).HasColumnName("Cylinders");
            this.Property(t => t.Displacement).HasColumnName("Displacement");
            this.Property(t => t.FuelInduction).HasColumnName("FuelInduction");
            this.Property(t => t.FuelQuality).HasColumnName("FuelQuality");
            this.Property(t => t.MaxHP).HasColumnName("MaxHP");
            this.Property(t => t.MaxTorque).HasColumnName("MaxTorque");
            this.Property(t => t.RedlineRPM).HasColumnName("RedlineRPM");
            this.Property(t => t.Stroke).HasColumnName("Stroke");
            this.Property(t => t.Valves).HasColumnName("Valves");
            this.Property(t => t.TransmissionSummary).HasColumnName("TransmissionSummary");
            this.Property(t => t.TransmissionBrandID).HasColumnName("TransmissionBrandID");
            this.Property(t => t.TransmissionTypeID).HasColumnName("TransmissionTypeID");
            this.Property(t => t.TransmissionGears).HasColumnName("TransmissionGears");
            this.Property(t => t.DriveTypeID).HasColumnName("DriveTypeID");
            this.Property(t => t.BrakeSystemID).HasColumnName("BrakeSystemID");
            this.Property(t => t.FrontTrackWidth).HasColumnName("FrontTrackWidth");
            this.Property(t => t.RearTrackWidth).HasColumnName("RearTrackWidth");
            this.Property(t => t.Wheelbase).HasColumnName("Wheelbase");
            this.Property(t => t.FrontWheelDiameter).HasColumnName("FrontWheelDiameter");
            this.Property(t => t.RearWheelDiameter).HasColumnName("RearWheelDiameter");
            this.Property(t => t.RearAxle).HasColumnName("RearAxle");
            this.Property(t => t.FrontTireTypeID).HasColumnName("FrontTireTypeID");
            this.Property(t => t.FrontTirePSI).HasColumnName("FrontTirePSI");
            this.Property(t => t.RearTireTypeID).HasColumnName("RearTireTypeID");
            this.Property(t => t.RearTirePSI).HasColumnName("RearTirePSI");
            this.Property(t => t.FuelTypeID).HasColumnName("FuelTypeID");
            this.Property(t => t.FuelTankCapacity).HasColumnName("FuelTankCapacity");
            this.Property(t => t.OilCapacity).HasColumnName("OilCapacity");
            this.Property(t => t.PrimaryMeterID).HasColumnName("PrimaryMeterID");
            this.Property(t => t.FuelUnit).HasColumnName("FuelUnit");
            this.Property(t => t.MeasurementUnit).HasColumnName("MeasurementUnit");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.ActionType).HasColumnName("ActionType");
            this.Property(t => t.ActionDate).HasColumnName("ActionDate");

            // Relationships
            this.HasOptional(t => t.Area)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.RegistrationProvinceID);
            this.HasOptional(t => t.Brand)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.EngineBrandID);
            this.HasOptional(t => t.Brand1)
                .WithMany(t => t.Vehicles1)
                .HasForeignKey(d => d.TransmissionBrandID);
            this.HasOptional(t => t.HREmployee)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.DriverID);
            this.HasOptional(t => t.HREmployee1)
                .WithMany(t => t.Vehicles1)
                .HasForeignKey(d => d.OwnershipID);
            this.HasOptional(t => t.MDFuelType)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.FuelTypeID);
            this.HasOptional(t => t.MDTransmissionType)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.TransmissionTypeID);
            this.HasOptional(t => t.MDVehicleBodyType)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.BodyTypeID);
            this.HasOptional(t => t.MDVehicleBrakeSystem)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.BrakeSystemID);
            this.HasOptional(t => t.MDVehicleDriveType)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.DriveTypeID);
            this.HasOptional(t => t.MDVehicleModel)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.VehicleModelID);
            this.HasOptional(t => t.VehicleGroup)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.VehicleGroupID);
            this.HasOptional(t => t.VehicleStatu)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.VehicleStatusID);
            this.HasOptional(t => t.VehicleType)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.VehicleTypeID);
            this.HasOptional(t => t.Vendor)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(d => d.MadeByID);

        }
    }
}
