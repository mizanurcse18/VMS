using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using PS.Model.Models.Mapping;

namespace PS.Model.Models
{
    public partial class VMSContext : DbContext
    {
        static VMSContext()
        {
            Database.SetInitializer<VMSContext>(null);
        }

        public VMSContext()
            : base("Name=VMSContext")
        {
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<HREmployee> HREmployees { get; set; }
        public DbSet<HREmployeeType> HREmployeeTypes { get; set; }
        public DbSet<Inspaction> Inspactions { get; set; }
        public DbSet<InspactionDetail> InspactionDetails { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueStatu> IssueStatus { get; set; }
        public DbSet<MDFuelType> MDFuelTypes { get; set; }
        public DbSet<MDTransmissionType> MDTransmissionTypes { get; set; }
        public DbSet<MDVehicleBodyType> MDVehicleBodyTypes { get; set; }
        public DbSet<MDVehicleBrakeSystem> MDVehicleBrakeSystems { get; set; }
        public DbSet<MDVehicleDriveType> MDVehicleDriveTypes { get; set; }
        public DbSet<MDVehicleModel> MDVehicleModels { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleGroup> VehicleGroups { get; set; }
        public DbSet<VehicleStatu> VehicleStatus { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorType> VendorTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AreaMap());
            modelBuilder.Configurations.Add(new BrandMap());
            modelBuilder.Configurations.Add(new HREmployeeMap());
            modelBuilder.Configurations.Add(new HREmployeeTypeMap());
            modelBuilder.Configurations.Add(new InspactionMap());
            modelBuilder.Configurations.Add(new InspactionDetailMap());
            modelBuilder.Configurations.Add(new IssueMap());
            modelBuilder.Configurations.Add(new IssueStatuMap());
            modelBuilder.Configurations.Add(new MDFuelTypeMap());
            modelBuilder.Configurations.Add(new MDTransmissionTypeMap());
            modelBuilder.Configurations.Add(new MDVehicleBodyTypeMap());
            modelBuilder.Configurations.Add(new MDVehicleBrakeSystemMap());
            modelBuilder.Configurations.Add(new MDVehicleDriveTypeMap());
            modelBuilder.Configurations.Add(new MDVehicleModelMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new VehicleMap());
            modelBuilder.Configurations.Add(new VehicleGroupMap());
            modelBuilder.Configurations.Add(new VehicleStatuMap());
            modelBuilder.Configurations.Add(new VehicleTypeMap());
            modelBuilder.Configurations.Add(new VendorMap());
            modelBuilder.Configurations.Add(new VendorTypeMap());
        }
    }
}
