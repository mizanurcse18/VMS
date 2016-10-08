using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PS.Model.Models.Mapping
{
    public class HREmployeeMap : EntityTypeConfiguration<HREmployee>
    {
        public HREmployeeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.ID)
                .IsRequired()
                .HasMaxLength(36);

            this.Property(t => t.EmployeeTypeID)
                .HasMaxLength(36);

            this.Property(t => t.Code)
                .HasMaxLength(10);

            this.Property(t => t.Name)
                .HasMaxLength(50);

            this.Property(t => t.Designation)
                .HasMaxLength(50);

            this.Property(t => t.CurentAddress)
                .HasMaxLength(100);

            this.Property(t => t.ParmanentAddress)
                .HasMaxLength(100);

            this.Property(t => t.CityID)
                .HasMaxLength(36);

            this.Property(t => t.Country)
                .HasMaxLength(50);

            this.Property(t => t.ContactNumber1)
                .HasMaxLength(20);

            this.Property(t => t.ContactNumber2)
                .HasMaxLength(20);

            this.Property(t => t.Email)
                .HasMaxLength(30);

            this.Property(t => t.NIDNumber)
                .HasMaxLength(30);

            this.Property(t => t.DrivingLicenceNumber)
                .HasMaxLength(50);

            this.Property(t => t.CreatedBy)
                .HasMaxLength(36);

            this.Property(t => t.UpdatedBy)
                .HasMaxLength(36);

            this.Property(t => t.ActionType)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("HREmployee");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.EmployeeTypeID).HasColumnName("EmployeeTypeID");
            this.Property(t => t.Code).HasColumnName("Code");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.DateOfBirth).HasColumnName("DateOfBirth");
            this.Property(t => t.Designation).HasColumnName("Designation");
            this.Property(t => t.JoiningDate).HasColumnName("JoiningDate");
            this.Property(t => t.LeaveDate).HasColumnName("LeaveDate");
            this.Property(t => t.CurentAddress).HasColumnName("CurentAddress");
            this.Property(t => t.ParmanentAddress).HasColumnName("ParmanentAddress");
            this.Property(t => t.CityID).HasColumnName("CityID");
            this.Property(t => t.Country).HasColumnName("Country");
            this.Property(t => t.ContactNumber1).HasColumnName("ContactNumber1");
            this.Property(t => t.ContactNumber2).HasColumnName("ContactNumber2");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.NIDNumber).HasColumnName("NIDNumber");
            this.Property(t => t.DrivingLicenceNumber).HasColumnName("DrivingLicenceNumber");
            this.Property(t => t.HourlyCost).HasColumnName("HourlyCost");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            this.Property(t => t.UpdatedBy).HasColumnName("UpdatedBy");
            this.Property(t => t.ActionType).HasColumnName("ActionType");
            this.Property(t => t.ActionDate).HasColumnName("ActionDate");

            // Relationships
            this.HasOptional(t => t.Area)
                .WithMany(t => t.HREmployees)
                .HasForeignKey(d => d.CityID);
            this.HasOptional(t => t.HREmployeeType)
                .WithMany(t => t.HREmployees)
                .HasForeignKey(d => d.EmployeeTypeID);

        }
    }
}
