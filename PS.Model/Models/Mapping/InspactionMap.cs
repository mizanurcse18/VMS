using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PS.Model.Models.Mapping
{
    public class InspactionMap : EntityTypeConfiguration<Inspaction>
    {
        public InspactionMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.Number)
                .HasMaxLength(50);

            this.Property(t => t.VehicleID)
                .HasMaxLength(36);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(36);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(36);

            this.Property(t => t.ActionType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Inspaction");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Number).HasColumnName("Number");
            this.Property(t => t.VehicleID).HasColumnName("VehicleID");
            this.Property(t => t.Date).HasColumnName("Date");
            this.Property(t => t.IsPassed).HasColumnName("IsPassed");
            this.Property(t => t.NextDate).HasColumnName("NextDate");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.ActionType).HasColumnName("ActionType");
            this.Property(t => t.ActionDate).HasColumnName("ActionDate");

            // Relationships
            this.HasOptional(t => t.Vehicle)
                .WithMany(t => t.Inspactions)
                .HasForeignKey(d => d.VehicleID);

        }
    }
}
