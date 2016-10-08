using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PS.IDataAccess.Vehicle;
using PS.Model.Models;


namespace PS.DataAccess.Vehicle
{
    public class DAInspactionDetail : DABase, IDAInspactionDetail
    {

        #region Properties

        private DAInspactionDetail entityDA;

        #endregion Properties

        #region Methods

        public long Save(InspactionDetail entity)
        {
            throw new NotImplementedException();
        }

        public long Update(InspactionDetail entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string filterExpression)
        {
            throw new NotImplementedException();
        }  

        public List<InspactionDetail> Get(Int32 pageSize, Int32 currentPage, String sortExpression, String filterExpression)
        {
            DataTable dt = new DataTable();
            List<InspactionDetail> listOfObj = new List<InspactionDetail>();

            if (ConnectionState.Open == ConnectionState.Open)
            {
                connection.Close();
            }

            connection.Open();
            SqlCommand cmd = new SqlCommand("InspactionDetail", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
            cmd.Parameters.Add("@CurrentPage", SqlDbType.Int).Value = currentPage;
            cmd.Parameters.Add("@SortExpression", SqlDbType.VarChar).Value = sortExpression;
            cmd.Parameters.Add("@FilterExpression", SqlDbType.VarChar).Value = filterExpression;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            connection.Close();
            adp.Fill(dt);

            listOfObj = dt.AsEnumerable().Select(dr => new InspactionDetail()
            {
                ID = dr.GetString("ID"),
                InspactionID = dr.GetString("InspactionID"),
                AirCompressor = dr.GetBoolean("AirCompressor"),
                Battery = dr.GetBoolean("Battery"),
                BeltsAndHoses = dr.GetBoolean("BeltsAndHoses"),
                Body = dr.GetBoolean("Body"),
                BrakeAccessories = dr.GetBoolean("BrakeAccessories"),
                Clutch = dr.GetBoolean("Clutch"),
                CouplingDevices = dr.GetBoolean("CouplingDevices"),
                DefrosterOrHeater = dr.GetBoolean("DefrosterOrHeater"),
                DriveLine = dr.GetBoolean("DriveLine"),
                Engine = dr.GetBoolean("Engine"),
                Exhaust = dr.GetBoolean("Exhaust"),
                FifthWheel = dr.GetBoolean("FifthWheel"),
                FluidLevels = dr.GetBoolean("FluidLevels"),
                FrameAndAssembly = dr.GetBoolean("FrameAndAssembly"),
                FrontAxle = dr.GetBoolean("FrontAxle"),
                FuelTanks = dr.GetBoolean("FuelTanks"),
                Horn = dr.GetBoolean("Horn"),
                LightsHeadOrStop = dr.GetBoolean("LightsHeadOrStop"),
                LightsTailOrDash = dr.GetBoolean("LightsTailOrDash"),
                LightsTurnIndicators = dr.GetBoolean("LightsTurnIndicators"),
                LightsClearanceOrMarker = dr.GetBoolean("LightsClearanceOrMarker"),
                Mirrors = dr.GetBoolean("Mirrors"),
                Muffler = dr.GetBoolean("Muffler"),
                OilPressure = dr.GetBoolean("OilPressure"),
                Radiator = dr.GetBoolean("Radiator"),
                RearEnd = dr.GetBoolean("RearEnd"),
                Reflectors = dr.GetBoolean("Reflectors"),
                Starter = dr.GetBoolean("Starter"),
                Steering = dr.GetBoolean("Steering"),
                SuspensionSystem = dr.GetBoolean("SuspensionSystem"),
                TireChains = dr.GetBoolean("TireChains"),
                Tires = dr.GetBoolean("Tires"),
                Transmission = dr.GetBoolean("Transmission"),
                TripRecorder = dr.GetBoolean("TripRecorder"),
                WheelsAndRims = dr.GetBoolean("WheelsAndRims"),
                Windows = dr.GetBoolean("Windows"),
                WindshieldWipers = dr.GetBoolean("WindshieldWipers"),
                FireExtinguisher = dr.GetBoolean("FireExtinguisher"),
                FlagsOrFlaresOrFusees = dr.GetBoolean("FlagsOrFlaresOrFusees"),
                ReflectiveTriangles = dr.GetBoolean("ReflectiveTriangles"),
                SpareBulbsAndFuses = dr.GetBoolean("SpareBulbsAndFuses"),
                SpareSealBeam = dr.GetBoolean("SpareSealBeam"),
                Remarks = dr.GetBoolean("Remarks"),
                CreateDate = (DateTime)dr.GetDateTime("CreateDate"),
                CreatedBy = dr.GetString("CreatedBy"),
                UpdatedBy = dr.GetString("UpdatedBy"),
                ActionType = dr.GetString("ActionType"),
                ActionDate = (DateTime)dr.GetDateTime("ActionDate"),
                Inspaction = new Inspaction()
                {
                    ID = dr.GetString("ID"),
                    Number = dr.GetString("Number")
                }
            }).ToList();

            return listOfObj;
        }
        
        #endregion Methods
    }
}


