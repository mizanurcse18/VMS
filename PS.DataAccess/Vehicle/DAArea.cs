 
/*
* Tools: Code Generator
* Author: Md. Mizanur Rahman
* Software Engineer 
* Phone : 01672352566
* Email: munna.cse_18@yahoo.com
* */
//Please Rename your Namespace
// Code Generate Time - 05/10/2016 08:57:51 PM


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PS.IDataAccess;
using PS.IDataAccess.Vehicle;
using PS.Model.Models;


namespace PS.DataAccess.Vehicle
{
    public class DAArea : DABase, IDAArea
    {

        #region Properties

        private DAArea entityDA;

        #endregion Properties

        #region Methods

        public long Save(Area entity)
        {
            throw new NotImplementedException();
        }

        public long Update(Area entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string filterExpression)
        {
            throw new NotImplementedException();
        }  

        public List<Area> Get(Int32 pageSize, Int32 currentPage, String sortExpression, String filterExpression)
        {
            DataTable dt = new DataTable();
            List<Area> listOfObj = new List<Area>();

            if (ConnectionState.Open == ConnectionState.Open)
            {
                connection.Close();
            }

            connection.Open();
            SqlCommand cmd = new SqlCommand("Area", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
            cmd.Parameters.Add("@CurrentPage", SqlDbType.Int).Value = currentPage;
            cmd.Parameters.Add("@SortExpression", SqlDbType.VarChar).Value = sortExpression;
            cmd.Parameters.Add("@FilterExpression", SqlDbType.VarChar).Value = filterExpression;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            connection.Close();
            adp.Fill(dt);

            listOfObj = dt.AsEnumerable().Select(dr => new Area()
            {
                ID = dr.GetString("ID"),
                Name = dr.GetString("Name")
            }).ToList();

            return listOfObj;
        }
        //public Area Get(string id)
        //{
        //    entity = new DAArea();
        //    return entity.Get(1000, 1, String.Empty, " ID =" + id).Single(x => x.ID == id);
        //}
        #endregion Methods
    }
}


