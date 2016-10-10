using System;
using System.Collections.Generic;
using PS.Model.Models;

namespace PS.IDataAccess.Vehicle
{
    public interface IDAHREmployeeType
    {
        Int64 Save(HREmployeeType entity);
        Int64 Update(HREmployeeType entity);
        void Delete(String filterExpression);
        List<HREmployeeType> Get(int pageSize, int currentPage, String sortExpression, String filterExpression);
        //DAHREmployeeType Get(String id);
    }
}