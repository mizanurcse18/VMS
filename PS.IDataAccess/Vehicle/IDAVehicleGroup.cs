using System;
using System.Collections.Generic;
using PS.Model.Models;

namespace PS.IDataAccess.Vehicle
{
    public interface IDAVehicleGroup
    {
        Int64 Save(VehicleGroup entity);
        Int64 Update(VehicleGroup entity);
        void Delete(String filterExpression);
        List<VehicleGroup> Get(int pageSize, int currentPage, String sortExpression, String filterExpression);
        //DAVehicleGroup Get(String id);
    }
}