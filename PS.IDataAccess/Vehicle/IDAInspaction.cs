using System;
using System.Collections.Generic;
using PS.Model.Models;

namespace PS.IDataAccess.Vehicle
{
    public interface IDAInspaction
    {
        Int64 Save(Inspaction entity);
        Int64 Update(Inspaction entity);
        void Delete(String filterExpression);
        List<Inspaction> Get(int pageSize, int currentPage, String sortExpression, String filterExpression);
        //DAInspaction Get(String id);
    }
}