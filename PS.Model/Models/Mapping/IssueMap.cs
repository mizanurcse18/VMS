using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PS.Model.Models.Mapping
{
    public class IssueMap : EntityTypeConfiguration<Issue>
    {
        public IssueMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.VehicleID)
                .HasMaxLength(36);

            this.Property(t => t.StatusID)
                .HasMaxLength(36);

            this.Property(t => t.Title)
                .HasMaxLength(50);

            this.Property(t => t.Description)
                .HasMaxLength(300);

            this.Property(t => t.Attachment)
                .HasMaxLength(100);

            this.Property(t => t.ReportedBy)
                .HasMaxLength(36);

            this.Property(t => t.AssignedTo)
                .HasMaxLength(36);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(36);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(36);

            this.Property(t => t.ActionType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Issue");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.VehicleID).HasColumnName("VehicleID");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.StatusID).HasColumnName("StatusID");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Attachment).HasColumnName("Attachment");
            this.Property(t => t.ReportedBy).HasColumnName("ReportedBy");
            this.Property(t => t.AssignedTo).HasColumnName("AssignedTo");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.ActionType).HasColumnName("ActionType");
            this.Property(t => t.ActionDate).HasColumnName("ActionDate");

            // Relationships
            this.HasOptional(t => t.IssueStatu)
                .WithMany(t => t.Issues)
                .HasForeignKey(d => d.StatusID);
            this.HasOptional(t => t.Vehicle)
                .WithMany(t => t.Issues)
                .HasForeignKey(d => d.VehicleID);

        }
    }
}
