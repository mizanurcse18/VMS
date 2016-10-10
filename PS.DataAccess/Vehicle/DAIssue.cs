using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PS.DataAccess;
using PS.IDataAccess;
using PS.IDataAccess.Vehicle;
using PS.Model.Models;


namespace PS.DataAccess.Vehicle
{
    public class DAIssue : DABase, IDAIssue
    {

        #region Properties

        private DAIssue entityDA;

        #endregion Properties

        #region Methods

        public long Save(Issue entity)
        {
            throw new NotImplementedException();
        }

        public long Update(Issue entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string filterExpression)
        {
            throw new NotImplementedException();
        }  

        public List<Issue> Get(Int32 pageSize, Int32 currentPage, String sortExpression, String filterExpression)
        {
            DataTable dt = new DataTable();
            List<Issue> listOfObj = new List<Issue>();

            if (ConnectionState.Open == ConnectionState.Open)
            {
                connection.Close();
            }

            connection.Open();
            SqlCommand cmd = new SqlCommand("Issue", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
            cmd.Parameters.Add("@CurrentPage", SqlDbType.Int).Value = currentPage;
            cmd.Parameters.Add("@SortExpression", SqlDbType.VarChar).Value = sortExpression;
            cmd.Parameters.Add("@FilterExpression", SqlDbType.VarChar).Value = filterExpression;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            connection.Close();
            adp.Fill(dt);

            listOfObj = dt.AsEnumerable().Select(dr => new Issue()
            {
                ID = dr.GetString("ID"),
                VehicleID = dr.GetString("VehicleID"),
                CreateDate = (DateTime)dr.GetDateTime("CreateDate"),
                StatusID = dr.GetString("StatusID"),
                Title = dr.GetString("Title"),
                Description = dr.GetString("Description"),
                Attachment = dr.GetString("Attachment"),
                ReportedBy = dr.GetString("ReportedBy"),
                AssignedTo = dr.GetString("AssignedTo"),
                CreatedBy = dr.GetString("CreatedBy"),
                UpdatedBy = dr.GetString("UpdatedBy"),
                ActionType = dr.GetString("ActionType"),
                ActionDate = (DateTime)dr.GetDateTime("ActionDate"),
                Vehicle = new Model.Models.Vehicle()
                {
                    ID = dr.GetString("ID"),
                    Name = dr.GetString("Name")
                },
                IssueStatu = new IssueStatu()
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


