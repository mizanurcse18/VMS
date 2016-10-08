using System;
using System.Collections.Generic;
using PS.Model.Models;

namespace PS.IDataAccess.Vehicle
{
    public interface IDABrand
    {
        Int64 Save(Brand entity);
        Int64 Update(Brand entity);
        void Delete(String filterExpression);
        List<Brand> Get(int pageSize, int currentPage, String sortExpression, String filterExpression);
        //Brand Get(String id);
    }
}