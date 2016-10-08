using System;
using System.Collections.Generic;
using PS.Model.Models;

namespace PS.IDataAccess.Vehicle
{
    public interface IDAVehicle
    {
        Int64 Save(Model.Models.Vehicle entity);
        Int64 Update(Model.Models.Vehicle entity);
        void Delete(String filterExpression);
        List<Model.Models.Vehicle> Get(int pageSize, int currentPage, String sortExpression, String filterExpression);
        //DAVehicle Get(String id);
    }
}