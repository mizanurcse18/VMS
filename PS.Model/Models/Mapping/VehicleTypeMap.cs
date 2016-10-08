using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PS.Model.Models.Mapping
{
    public class VehicleTypeMap : EntityTypeConfiguration<VehicleType>
    {
        public VehicleTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(36);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(36);

            this.Property(t => t.ActionType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("VehicleType");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.ActionType).HasColumnName("ActionType");
            this.Property(t => t.ActionDate).HasColumnName("ActionDate");
        }
    }
}
