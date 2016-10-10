using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PS.Model.Models.Mapping
{
    public class InspactionDetailMap : EntityTypeConfiguration<InspactionDetail>
    {
        public InspactionDetailMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.InspactionID)
                .HasMaxLength(36);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(36);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(36);

            this.Property(t => t.ActionType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("InspactionDetail");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.InspactionID).HasColumnName("InspactionID");
            this.Property(t => t.AirCompressor).HasColumnName("AirCompressor");
            this.Property(t => t.Battery).HasColumnName("Battery");
            this.Property(t => t.BeltsAndHoses).HasColumnName("BeltsAndHoses");
            this.Property(t => t.Body).HasColumnName("Body");
            this.Property(t => t.BrakeAccessories).HasColumnName("BrakeAccessories");
            this.Property(t => t.Clutch).HasColumnName("Clutch");
            this.Property(t => t.CouplingDevices).HasColumnName("CouplingDevices");
            this.Property(t => t.DefrosterOrHeater).HasColumnName("DefrosterOrHeater");
            this.Property(t => t.DriveLine).HasColumnName("DriveLine");
            this.Property(t => t.Engine).HasColumnName("Engine");
            this.Property(t => t.Exhaust).HasColumnName("Exhaust");
            this.Property(t => t.FifthWheel).HasColumnName("FifthWheel");
            this.Property(t => t.FluidLevels).HasColumnName("FluidLevels");
            this.Property(t => t.FrameAndAssembly).HasColumnName("FrameAndAssembly");
            this.Property(t => t.FrontAxle).HasColumnName("FrontAxle");
            this.Property(t => t.FuelTanks).HasColumnName("FuelTanks");
            this.Property(t => t.Horn).HasColumnName("Horn");
            this.Property(t => t.LightsHeadOrStop).HasColumnName("LightsHeadOrStop");
            this.Property(t => t.LightsTailOrDash).HasColumnName("LightsTailOrDash");
            this.Property(t => t.LightsTurnIndicators).HasColumnName("LightsTurnIndicators");
            this.Property(t => t.LightsClearanceOrMarker).HasColumnName("LightsClearanceOrMarker");
            this.Property(t => t.Mirrors).HasColumnName("Mirrors");
            this.Property(t => t.Muffler).HasColumnName("Muffler");
            this.Property(t => t.OilPressure).HasColumnName("OilPressure");
            this.Property(t => t.Radiator).HasColumnName("Radiator");
            this.Property(t => t.RearEnd).HasColumnName("RearEnd");
            this.Property(t => t.Reflectors).HasColumnName("Reflectors");
            this.Property(t => t.Starter).HasColumnName("Starter");
            this.Property(t => t.Steering).HasColumnName("Steering");
            this.Property(t => t.SuspensionSystem).HasColumnName("SuspensionSystem");
            this.Property(t => t.TireChains).HasColumnName("TireChains");
            this.Property(t => t.Tires).HasColumnName("Tires");
            this.Property(t => t.Transmission).HasColumnName("Transmission");
            this.Property(t => t.TripRecorder).HasColumnName("TripRecorder");
            this.Property(t => t.WheelsAndRims).HasColumnName("WheelsAndRims");
            this.Property(t => t.Windows).HasColumnName("Windows");
            this.Property(t => t.WindshieldWipers).HasColumnName("WindshieldWipers");
            this.Property(t => t.FireExtinguisher).HasColumnName("FireExtinguisher");
            this.Property(t => t.FlagsOrFlaresOrFusees).HasColumnName("FlagsOrFlaresOrFusees");
            this.Property(t => t.ReflectiveTriangles).HasColumnName("ReflectiveTriangles");
            this.Property(t => t.SpareBulbsAndFuses).HasColumnName("SpareBulbsAndFuses");
            this.Property(t => t.SpareSealBeam).HasColumnName("SpareSealBeam");
            this.Property(t => t.Remarks).HasColumnName("Remarks");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.ActionType).HasColumnName("ActionType");
            this.Property(t => t.ActionDate).HasColumnName("ActionDate");

            // Relationships
            this.HasOptional(t => t.Inspaction)
                .WithMany(t => t.InspactionDetails)
                .HasForeignKey(d => d.InspactionID);

        }
    }
}
