using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PS.IDataAccess.Vehicle;
using PS.Model.Models;


namespace PS.DataAccess.Vehicle
{
    public class DAVendor : DABase, IDAVendor
    {

        #region Properties

        private DAVendor entityDA;

        #endregion Properties

        #region Methods

        public long Save(Vendor entity)
        {
            throw new NotImplementedException();
        }

        public long Update(Vendor entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string filterExpression)
        {
            throw new NotImplementedException();
        }  

        public List<Vendor> Get(Int32 pageSize, Int32 currentPage, String sortExpression, String filterExpression)
        {
            DataTable dt = new DataTable();
            List<Vendor> listOfObj = new List<Vendor>();

            if (ConnectionState.Open == ConnectionState.Open)
            {
                connection.Close();
            }

            connection.Open();
            SqlCommand cmd = new SqlCommand("Vendor", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;
            cmd.Parameters.Add("@CurrentPage", SqlDbType.Int).Value = currentPage;
            cmd.Parameters.Add("@SortExpression", SqlDbType.VarChar).Value = sortExpression;
            cmd.Parameters.Add("@FilterExpression", SqlDbType.VarChar).Value = filterExpression;
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            connection.Close();
            adp.Fill(dt);

            listOfObj = dt.AsEnumerable().Select(dr => new Vendor()
            {
                ID = dr.GetString("ID"),
                VendorTypeID = dr.GetString("VendorTypeID"),
                Name = dr.GetString("Name"),
                AddressLine1 = dr.GetString("AddressLine1"),
                AddressLine2 = dr.GetString("AddressLine2"),
                CityID = dr.GetString("CityID"),
                Country = dr.GetString("Country"),
                ContactPersonName = dr.GetString("ContactPersonName"),
                ContactNumber1 = dr.GetString("ContactNumber1"),
                ContactNumber2 = dr.GetString("ContactNumber2"),
                Email = dr.GetString("Email"),
                Website = dr.GetString("Website"),
                Remarks = dr.GetString("Remarks"),
                CreateDate = (DateTime)dr.GetDateTime("CreateDate"),
                CreatedBy = dr.GetString("CreatedBy"),
                UpdatedBy = dr.GetString("UpdatedBy"),
                ActionType = dr.GetString("ActionType"),
                ActionDate = (DateTime)dr.GetDateTime("ActionDate"),
                VendorType = new VendorType()
                {
                    ID = dr.GetString("ID"),
                    Name = dr.GetString("Name")
                },
                Area = new Area()
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


