using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PS.IDataAccess.Vehicle;
using PS.Model.Models;


namespace PS.DataAccess.Vehicle
{
    public class DAVehicleType : DABase, IDAVehicleType
    {

        #region Properties

        private DAVehicleType entityDA;

        #endregion Properties

        #region Methods

        public long Save(VehicleType entity)
        {
            throw new NotImplementedException();
        }

        public long Update(VehicleType entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string filterExpression)
        {
            throw new NotImplementedException();
        }  

        public List<VehicleType> Get(Int32 pageSize, Int32 currentPage, String sortExpression, String filterExpression)
        {
            DataTable dt = new DataTable();
            List<VehicleType> listOfObj = new List<VehicleType>();

            if (ConnectionState.Open == ConnectionState.Open)
            {
                connection.Close();
            }

            connection.Open();
            SqlCommand cmd = new SqlCommand("VehicleType", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
            cmd.Parameters.Add("@CurrentPage", SqlDbType.Int).Value = currentPage;
            cmd.Parameters.Add("@SortExpression", SqlDbType.VarChar).Value = sortExpression;
            cmd.Parameters.Add("@FilterExpression", SqlDbType.VarChar).Value = filterExpression;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            connection.Close();
            adp.Fill(dt);

            listOfObj = dt.AsEnumerable().Select(dr => new VehicleType()
            {
                ID = dr.GetString("ID"),
                Name = dr.GetString("Name"),
                CreateDate = (DateTime)dr.GetDateTime("CreateDate"),
                CreatedBy = dr.GetString("CreatedBy"),
                UpdatedBy = dr.GetString("UpdatedBy"),
                ActionType = dr.GetString("ActionType"),
                ActionDate = (DateTime)dr.GetDateTime("ActionDate")
            }).ToList();

            return listOfObj;
        }
       
        #endregion Methods
    }
}


