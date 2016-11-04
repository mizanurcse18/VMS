using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PS.DataAccess;
using PS.IDataAccess.Vehicle;
using PS.Model.Models;


namespace PS.DataAccess.Vehicle
{
    public class DAHREmployee : DABase, IDAHREmployee
    {

        #region Properties

        private DAHREmployee entityDA;

        #endregion Properties

        #region Methods

        public long Save(HREmployee entity)
        {
            throw new NotImplementedException();
        }

        public long Update(HREmployee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string filterExpression)
        {
            throw new NotImplementedException();
        }  

        public List<HREmployee> Get(Int32 pageSize, Int32 currentPage, String sortExpression, String filterExpression)
        {
            DataTable dt = new DataTable();
            List<HREmployee> listOfObj = new List<HREmployee>();

            if (ConnectionState.Open == ConnectionState.Open)
            {
                connection.Close();
            }

            connection.Open();
            SqlCommand cmd = new SqlCommand("HREmployee_Detailed", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
            cmd.Parameters.Add("@CurrentPage", SqlDbType.Int).Value = currentPage;
            cmd.Parameters.Add("@SortExpression", SqlDbType.VarChar).Value = sortExpression;
            cmd.Parameters.Add("@FilterExpression", SqlDbType.VarChar).Value = filterExpression;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            connection.Close();
            adp.Fill(dt);

            listOfObj = dt.AsEnumerable().Select(dr => new HREmployee()
            {
                ID = dr.GetString("ID"),
                EmployeeTypeID = dr.GetString("EmployeeTypeID"),
                Code = dr.GetString("Code"),
                Name = dr.GetString("Name"),
                DateOfBirth = dr.GetDateTime("DateOfBirth"),
                Designation = dr.GetString("Designation"),
                JoiningDate = dr.GetDateTime("JoiningDate"),
                LeaveDate = dr.GetDateTime("LeaveDate"),
                CurentAddress = dr.GetString("CurentAddress"),
                ParmanentAddress = dr.GetString("ParmanentAddress"),
                CityID = dr.GetString("CityID"),
                Country = dr.GetString("Country"),
                ContactNumber1 = dr.GetString("ContactNumber1"),
                ContactNumber2 = dr.GetString("ContactNumber2"),
                Email = dr.GetString("Email"),
                NIDNumber = dr.GetString("NIDNumber"),
                DrivingLicenceNumber = dr.GetString("DrivingLicenceNumber"),
                HourlyCost = dr.GetToDecimal("HourlyCost"),
                CreateDate = (DateTime)dr.GetDateTime("CreateDate"),
                CreatedBy = dr.GetString("CreatedBy"),
                UpdatedBy = dr.GetString("UpdatedBy"),
                ActionType = dr.GetString("ActionType"),
                ActionDate = (DateTime)dr.GetDateTime("ActionDate"),
                HREmployeeType = new HREmployeeType()
                {
                    ID = dr.GetString("ID"),
                    Name = dr.GetString("Name")
                }
                
            }).ToList();

            return listOfObj;
        }
       
        #endregion Methods
    }
}


