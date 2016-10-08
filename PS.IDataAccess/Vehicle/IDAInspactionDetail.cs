using System;
using System.Collections.Generic;
using PS.Model.Models;

namespace PS.IDataAccess.Vehicle
{
    public interface IDAInspactionDetail
    {
        Int64 Save(InspactionDetail entity);
        Int64 Update(InspactionDetail entity);
        void Delete(String filterExpression);
        List<InspactionDetail> Get(int pageSize, int currentPage, String sortExpression, String filterExpression);
        //DAInspactionDetail Get(String id);
    }
}