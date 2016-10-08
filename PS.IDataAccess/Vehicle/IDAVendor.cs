using System;
using System.Collections.Generic;
using PS.Model.Models;

namespace PS.IDataAccess.Vehicle
{
    public interface IDAVendor
    {
        Int64 Save(Vendor entity);
        Int64 Update(Vendor entity);
        void Delete(String filterExpression);
        List<Vendor> Get(int pageSize, int currentPage, String sortExpression, String filterExpression);
        //DAVendor Get(String id);
    }
}