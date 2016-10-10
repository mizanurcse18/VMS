using System;
using System.Collections.Generic;
using PS.Model.Models;

namespace PS.IDataAccess.Vehicle
{
    public interface IDAIssue
    {
        Int64 Save(Issue entity);
        Int64 Update(Issue entity);
        void Delete(String filterExpression);
        List<Issue> Get(int pageSize, int currentPage, String sortExpression, String filterExpression);
        //DAIssue Get(String id);
    }
}