using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PS.Model.Models.Mapping
{
    public class VendorMap : EntityTypeConfiguration<Vendor>
    {
        public VendorMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.VendorTypeID)
                .HasMaxLength(36);

            this.Property(t => t.Name)
                .HasMaxLength(100);

            this.Property(t => t.AddressLine1)
                .HasMaxLength(200);

            this.Property(t => t.AddressLine2)
                .HasMaxLength(200);

            this.Property(t => t.CityID)
                .HasMaxLength(36);

            this.Property(t => t.Country)
                .HasMaxLength(50);

            this.Property(t => t.ContactPersonName)
                .HasMaxLength(50);

            this.Property(t => t.ContactNumber1)
                .HasMaxLength(20);

            this.Property(t => t.ContactNumber2)
                .HasMaxLength(20);

            this.Property(t => t.Email)
                .HasMaxLength(20);

            this.Property(t => t.Website)
                .HasMaxLength(30);

            this.Property(t => t.Remarks)
                .HasMaxLength(300);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(36);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(36);

            this.Property(t => t.ActionType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Vendor");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.VendorTypeID).HasColumnName("VendorTypeID");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.AddressLine1).HasColumnName("AddressLine1");
            this.Property(t => t.AddressLine2).HasColumnName("AddressLine2");
            this.Property(t => t.CityID).HasColumnName("CityID");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.ContactPersonName).HasColumnName("ContactPersonName");
            this.Property(t => t.ContactNumber1).HasColumnName("ContactNumber1");
            this.Property(t => t.ContactNumber2).HasColumnName("ContactNumber2");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Website).HasColumnName("Website");
            this.Property(t => t.Remarks).HasColumnName("Remarks");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.ActionType).HasColumnName("ActionType");
            this.Property(t => t.ActionDate).HasColumnName("ActionDate");

            // Relationships
            this.HasOptional(t => t.Area)
                .WithMany(t => t.Vendors)
                .HasForeignKey(d => d.CityID);
            this.HasOptional(t => t.VendorType)
                .WithMany(t => t.Vendors)
                .HasForeignKey(d => d.VendorTypeID);

        }
    }
}
