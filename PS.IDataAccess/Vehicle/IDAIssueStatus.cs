using System;
using System.Collections.Generic;
using PS.Model.Models;

namespace PS.IDataAccess.Vehicle
{
    public interface IDAIssueStatus
    {
        Int64 Save(IssueStatu entity);
        Int64 Update(IssueStatu entity);
        void Delete(String filterExpression);
        List<IssueStatu> Get(int pageSize, int currentPage, String sortExpression, String filterExpression);
        //DAIssueStatu Get(String id);
    }
}