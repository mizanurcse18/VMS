using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using PS.DataAccess;
using PS.IDataAccess.Vehicle;
using PS.IDataAccess.Vehicle;
using PS.Model.Models;


namespace PS.DataAccess.Vehicle
{
    public class DAVehicle : DABase, IDAVehicle
    {

        #region Properties

        private DAVehicle entityDA;

        #endregion Properties

        #region Methods

        public long Save(Model.Models.Vehicle entity)
        {
            throw new NotImplementedException();
        }

        public long Update(Model.Models.Vehicle entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string filterExpression)
        {
            throw new NotImplementedException();
        }

        public List<Model.Models.Vehicle> Get(Int32 pageSize, Int32 currentPage, String sortExpression, String filterExpression)
        {
            DataTable dt = new DataTable();
            List<Model.Models.Vehicle> listOfObj = new List<Model.Models.Vehicle>();

            if (ConnectionState.Open == ConnectionState.Open)
            {
                connection.Close();
            }

            connection.Open();
            SqlCommand cmd = new SqlCommand("Vehicle", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
            cmd.Parameters.Add("@CurrentPage", SqlDbType.Int).Value = currentPage;
            cmd.Parameters.Add("@SortExpression", SqlDbType.VarChar).Value = sortExpression;
            cmd.Parameters.Add("@FilterExpression", SqlDbType.VarChar).Value = filterExpression;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            connection.Close();
            adp.Fill(dt);

            listOfObj = dt.AsEnumerable().Select(dr => new Model.Models.Vehicle()
            {
                ID = dr.GetString("ID"),
                Name = dr.GetString("Name"),
                NickName = dr.GetString("NickName"),
                SerialNumber = dr.GetString("SerialNumber"),
                VehicleTypeID = dr.GetString("VehicleTypeID"),
                MadeByID = dr.GetString("MadeByID"),
                VehicleModelID = dr.GetString("VehicleModelID"),
                Trim = dr.GetString("Trim"),
                LicensePlate = dr.GetString("LicensePlate"),
                RegistrationProvinceID = dr.GetString("RegistrationProvinceID"),
                Photo = dr.GetString("Photo"),
                VehicleStatusID = dr.GetString("VehicleStatusID"),
                VehicleGroupID = dr.GetString("VehicleGroupID"),
                DriverID = dr.GetString("DriverID"),
                OwnershipID = dr.GetString("OwnershipID"),
                Color = dr.GetString("Color"),
                BodyTypeID = dr.GetString("BodyTypeID"),
                MSRP = dr.GetToDecimal("MSRP"),
                Width = dr.GetToDecimal("Width"),
                Height = dr.GetToDecimal("Height"),
                Length = dr.GetToDecimal("Length"),
                InteriorVolume = dr.GetToDecimal("InteriorVolume"),
                PassengerVolume = dr.GetToDecimal("PassengerVolume"),
                CargoVolume = dr.GetToDecimal("CargoVolume"),
                GroundClearance = dr.GetToDecimal("GroundClearance"),
                BedLength = dr.GetToDecimal("BedLength"),
                CurbWeight = dr.GetToDecimal("CurbWeight"),
                GrossVehicleWeight = dr.GetToDecimal("GrossVehicleWeight"),
                TowingCapacity = dr.GetToDecimal("TowingCapacity"),
                MaxPayload = dr.GetToDecimal("MaxPayload"),
                EPACity = dr.GetToDecimal("EPACity"),
                EPAHighway = dr.GetToDecimal("EPAHighway"),
                EPACombined = dr.GetToDecimal("EPACombined"),
                EngineSummary = dr.GetString("EngineSummary"),
                EngineBrandID = dr.GetString("EngineBrandID"),
                Bore = dr.GetToDecimal("Bore"),
                Compression = dr.GetToDecimal("Compression"),
                Cylinders = dr.GetToDecimal("Cylinders"),
                Displacement = dr.GetToDecimal("Displacement"),
                FuelInduction = dr.GetToDecimal("FuelInduction"),
                FuelQuality = dr.GetToDecimal("FuelQuality"),
                MaxHP = dr.GetToDecimal("MaxHP"),
                MaxTorque = dr.GetToDecimal("MaxTorque"),
                RedlineRPM = dr.GetToDecimal("RedlineRPM"),
                Stroke = dr.GetToDecimal("Stroke"),
                Valves = dr.GetToDecimal("Valves"),
                TransmissionSummary = dr.GetString("TransmissionSummary"),
                TransmissionBrandID = dr.GetString("TransmissionBrandID"),
                TransmissionTypeID = dr.GetString("TransmissionTypeID"),
                TransmissionGears = dr.GetToDecimal("TransmissionGears"),
                DriveTypeID = dr.GetString("DriveTypeID"),
                BrakeSystemID = dr.GetString("BrakeSystemID"),
                FrontTrackWidth = dr.GetToDecimal("FrontTrackWidth"),
                RearTrackWidth = dr.GetToDecimal("RearTrackWidth"),
                Wheelbase = dr.GetToDecimal("Wheelbase"),
                FrontWheelDiameter = dr.GetToDecimal("FrontWheelDiameter"),
                RearWheelDiameter = dr.GetToDecimal("RearWheelDiameter"),
                RearAxle = dr.GetToDecimal("RearAxle"),
                FrontTireTypeID = dr.GetString("FrontTireTypeID"),
                FrontTirePSI = dr.GetToDecimal("FrontTirePSI"),
                RearTireTypeID = dr.GetString("RearTireTypeID"),
                RearTirePSI = dr.GetToDecimal("RearTirePSI"),
                FuelTypeID = dr.GetString("FuelTypeID"),
                FuelTankCapacity = dr.GetToDecimal("FuelTankCapacity"),
                OilCapacity = dr.GetToDecimal("OilCapacity"),
                PrimaryMeterID = dr.GetString("PrimaryMeterID"),
                FuelUnit = dr.GetBoolean("FuelUnit"),
                MeasurementUnit = dr.GetBoolean("MeasurementUnit"),
                CreateDate = (DateTime)dr.GetDateTime("CreateDate"),
                CreatedBy = dr.GetString("CreatedBy"),
                UpdatedBy = dr.GetString("UpdatedBy"),
                ActionType = dr.GetString("ActionType"),
                ActionDate = (DateTime)dr.GetDateTime("ActionDate"),
                VehicleType = new VehicleType()
                {
                    ID = dr.GetString("ID"),
                    Name = dr.GetString("Name")
                },
                Vendor = new Vendor()
                {
                    ID = dr.GetString("ID"),
                    Name = dr.GetString("Name")
                },
                MDVehicleModel = new MDVehicleModel()
                {
                    ID = dr.GetString("ID"),
                    Name = dr.GetString("Name")
                },

                VehicleStatu = new VehicleStatu()
                {
                    ID = dr.GetString("ID"),
                    Name = dr.GetString("Name")
                },
                VehicleGroup = new VehicleGroup()
                {
                    ID = dr.GetString("ID"),
                    Name = dr.GetString("Name")
                },
                MDFuelType = new MDFuelType()
                {
                    ID = dr.GetString("ID"),
                    Name = dr.GetString("Name"),
                }
            }).ToList();

            return listOfObj;
        }

        #endregion Methods
    }
}


