using System;
using System.Collections.Generic;
using PS.Model.Models;

namespace PS.IDataAccess.Vehicle
{
    public interface IDAArea
    {
        Int64 Save(Area entity);
        Int64 Update(Area entity);
        void Delete(String filterExpression);
        List<Area> Get(int pageSize, int currentPage, String sortExpression, String filterExpression);
        //Area Get(String id);
    }
}