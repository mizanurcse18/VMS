using System;
using System.Collections.Generic;
using PS.Model.Models;

namespace PS.IDataAccess.Vehicle
{
    public interface IDAVehicleStatus
    {
        Int64 Save(VehicleStatu entity);
        Int64 Update(VehicleStatu entity);
        void Delete(String filterExpression);
        List<VehicleStatu> Get(int pageSize, int currentPage, String sortExpression, String filterExpression);
        //DAVehicleStatu Get(String id);
    }
}