using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PS.IDataAccess.Vehicle;
using PS.Model.Models;


namespace PS.DataAccess.Vehicle
{
    public class DAInspaction : DABase, IDAInspaction
    {

        #region Properties

        private DAInspaction entityDA;

        #endregion Properties

        #region Methods

        public long Save(Inspaction entity)
        {
            throw new NotImplementedException();
        }

        public long Update(Inspaction entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string filterExpression)
        {
            throw new NotImplementedException();
        }  

        public List<Inspaction> Get(Int32 pageSize, Int32 currentPage, String sortExpression, String filterExpression)
        {
            DataTable dt = new DataTable();
            List<Inspaction> listOfObj = new List<Inspaction>();

            if (ConnectionState.Open == ConnectionState.Open)
            {
                connection.Close();
            }

            connection.Open();
            SqlCommand cmd = new SqlCommand("Inspaction", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
            cmd.Parameters.Add("@CurrentPage", SqlDbType.Int).Value = currentPage;
            cmd.Parameters.Add("@SortExpression", SqlDbType.VarChar).Value = sortExpression;
            cmd.Parameters.Add("@FilterExpression", SqlDbType.VarChar).Value = filterExpression;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            connection.Close();
            adp.Fill(dt);

            listOfObj = dt.AsEnumerable().Select(dr => new Inspaction()
            {
                ID = dr.GetString("ID"),
                Number = dr.GetString("Number"),
                VehicleID = dr.GetString("VehicleID"),
                Date = (DateTime)dr.GetDateTime("Date"),
                IsPassed = dr.GetBoolean("IsPassed"),
                NextDate = (DateTime)dr.GetDateTime("NextDate"),
                CreateDate = (DateTime)dr.GetDateTime("CreateDate"),
                CreatedBy = dr.GetString("CreatedBy"),
                UpdatedBy = dr.GetString("UpdatedBy"),
                ActionType = dr.GetString("ActionType"),
                ActionDate = (DateTime)dr.GetDateTime("ActionDate"),
                Vehicle = new Model.Models.Vehicle()
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


