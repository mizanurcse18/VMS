using System;
using System.Collections.Generic;
using PS.Data.Infrastructure;
using PS.Data.Repository;
using PS.Model.Models;


namespace PS.Service
{
    public interface IIssueService
    {

        bool Save(Issue issue);
        bool Update(Issue entity);
        bool Delete(String id);
        Issue Get(string id);
        IEnumerable<Issue> Get(int pageSize, int currentPage, string sortExpression, string filterExpression);
        IEnumerable<Issue> Get();

        void SaveRecord();
    }
    public class IssueService : IIssueService
    {
        private readonly IIssueRepository _IssueRepository;
        private readonly IUnitOfWork unitOfWork;
        //DAIssue daIssue = new DAIssue();

        public IssueService()
        {
            this._IssueRepository = new IssueRepository(new DatabaseFactory());
            this.unitOfWork = new UnitOfWork(new DatabaseFactory());
        }
        public IssueService(IIssueRepository IssueRepository, IUnitOfWork unitOfWork)
        {
            this._IssueRepository = IssueRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Save(Issue issue)
        {
            bool isSuccess = true;
            try
            {
                issue.ID = Guid.NewGuid().ToString();
                _IssueRepository.Add(issue);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Update(Issue issue)
        {
            bool isSuccess = true;
            try
            {
                _IssueRepository.Update(issue);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Delete(String id)
        {
            bool isSuccess = true;
            var entityInfo = _IssueRepository.GetById(id);
            try
            {
                _IssueRepository.Delete(entityInfo);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public Issue Get(string id)
        {
            return _IssueRepository.GetById(id);
            //return daItem.Get(id);
        }
        public IEnumerable<Issue> Get(int pageSize, int currentPage, string sortExpression, string filterExpression)
        {
            return _IssueRepository.GetAll();
            //return daIssue.Get(pageSize, currentPage, sortExpression, filterExpression);
        }
        public IEnumerable<Issue> Get()
        {
            //return IssueRepository.GetAll();
            return _IssueRepository.GetAll();
        }
        public void SaveRecord()
        {
            unitOfWork.Commit();
        }
    }
}


