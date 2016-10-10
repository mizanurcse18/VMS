using System;
using System.Collections.Generic;
using PS.Model.Models;

namespace PS.IDataAccess.Vehicle
{
    public interface IDAHREmployee
    {
        Int64 Save(HREmployee entity);
        Int64 Update(HREmployee entity);
        void Delete(String filterExpression);
        List<HREmployee> Get(int pageSize, int currentPage, String sortExpression, String filterExpression);
        //DAHREmployee Get(String id);
    }
}