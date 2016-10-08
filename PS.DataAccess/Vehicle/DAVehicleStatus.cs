using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PS.IDataAccess.Vehicle;
using PS.Model.Models;


namespace PS.DataAccess.Vehicle
{
    public class DAVehicleStatu : DABase, IDAVehicleStatus
    {

        #region Properties

        private DAVehicleStatu entityDA;

        #endregion Properties

        #region Methods

        public long Save(VehicleStatu entity)
        {
            throw new NotImplementedException();
        }

        public long Update(VehicleStatu entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string filterExpression)
        {
            throw new NotImplementedException();
        }  

        public List<VehicleStatu> Get(Int32 pageSize, Int32 currentPage, String sortExpression, String filterExpression)
        {
            DataTable dt = new DataTable();
            List<VehicleStatu> listOfObj = new List<VehicleStatu>();

            if (ConnectionState.Open == ConnectionState.Open)
            {
                connection.Close();
            }

            connection.Open();
            SqlCommand cmd = new SqlCommand("VehicleStatu", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
            cmd.Parameters.Add("@CurrentPage", SqlDbType.Int).Value = currentPage;
            cmd.Parameters.Add("@SortExpression", SqlDbType.VarChar).Value = sortExpression;
            cmd.Parameters.Add("@FilterExpression", SqlDbType.VarChar).Value = filterExpression;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            connection.Close();
            adp.Fill(dt);

            listOfObj = dt.AsEnumerable().Select(dr => new VehicleStatu()
            {
                ID = dr.GetString("ID"),
                Name = dr.GetString("Name")
            }).ToList();

            return listOfObj;
        }
        
        #endregion Methods
    }
}

