using System;
using System.Collections.Generic;
using PS.Model.Models;

namespace PS.IDataAccess.Vehicle
{
    public interface IDAVehicleType
    {
        Int64 Save(VehicleType entity);
        Int64 Update(VehicleType entity);
        void Delete(String filterExpression);
        List<VehicleType> Get(int pageSize, int currentPage, String sortExpression, String filterExpression);
        //DAVehicleType Get(String id);
    }
}