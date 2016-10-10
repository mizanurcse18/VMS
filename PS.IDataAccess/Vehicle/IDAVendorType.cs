using System;
using System.Collections.Generic;
using PS.Model.Models;

namespace PS.IDataAccess.Vehicle
{
    public interface IDAVendorType
    {
        Int64 Save(VendorType entity);
        Int64 Update(VendorType entity);
        void Delete(String filterExpression);
        List<VendorType> Get(int pageSize, int currentPage, String sortExpression, String filterExpression);
        //DAVendorType Get(String id);
    }
}