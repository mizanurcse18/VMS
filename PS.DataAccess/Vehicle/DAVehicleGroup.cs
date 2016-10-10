using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PS.IDataAccess.Vehicle;
using PS.Model.Models;


namespace PS.DataAccess.Vehicle
{
    public class DAVehicleGroup : DABase, IDAVehicleGroup
    {

        #region Properties

        private DAVehicleGroup entityDA;

        #endregion Properties

        #region Methods

        public long Save(VehicleGroup entity)
        {
            throw new NotImplementedException();
        }

        public long Update(VehicleGroup entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string filterExpression)
        {
            throw new NotImplementedException();
        }  

        public List<VehicleGroup> Get(Int32 pageSize, Int32 currentPage, String sortExpression, String filterExpression)
        {
            DataTable dt = new DataTable();
            List<VehicleGroup> listOfObj = new List<VehicleGroup>();

            if (ConnectionState.Open == ConnectionState.Open)
            {
                connection.Close();
            }

            connection.Open();
            SqlCommand cmd = new SqlCommand("VehicleGroup", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
            cmd.Parameters.Add("@CurrentPage", SqlDbType.Int).Value = currentPage;
            cmd.Parameters.Add("@SortExpression", SqlDbType.VarChar).Value = sortExpression;
            cmd.Parameters.Add("@FilterExpression", SqlDbType.VarChar).Value = filterExpression;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            connection.Close();
            adp.Fill(dt);

            listOfObj = dt.AsEnumerable().Select(dr => new VehicleGroup()
            {
                ID = dr.GetString("ID"),
                Name = dr.GetString("Name")
            }).ToList();

            return listOfObj;
        }
        
        #endregion Methods
    }
}


