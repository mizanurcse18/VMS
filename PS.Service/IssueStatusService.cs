using System;
using System.Collections.Generic;
using PS.Data.Infrastructure;
using PS.Data.Repository;
using PS.Model.Models;


namespace PS.Service
{
    public interface IIssueStatusService
    {

        bool Save(IssueStatu issueStatus);
        bool Update(IssueStatu entity);
        bool Delete(String id);
        IssueStatu Get(string id);
        IEnumerable<IssueStatu> Get(int pageSize, int currentPage, string sortExpression, string filterExpression);
        IEnumerable<IssueStatu> Get();

        void SaveRecord();
    }
    public class IssueStatusService : IIssueStatusService
    {
        private readonly IIssueStatusRepository _IssueStatusRepository;
        private readonly IUnitOfWork unitOfWork;
        //DAIssueStatus daIssueStatus = new DAIssueStatus();

        public IssueStatusService()
        {
            this._IssueStatusRepository = new IssueStatusRepository(new DatabaseFactory());
            this.unitOfWork = new UnitOfWork(new DatabaseFactory());
        }
        public IssueStatusService(IIssueStatusRepository IssueStatusRepository, IUnitOfWork unitOfWork)
        {
            this._IssueStatusRepository = IssueStatusRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Save(IssueStatu issueStatus)
        {
            bool isSuccess = true;
            try
            {
                issueStatus.ID = Guid.NewGuid().ToString();
                _IssueStatusRepository.Add(issueStatus);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Update(IssueStatu issueStatus)
        {
            bool isSuccess = true;
            try
            {
                _IssueStatusRepository.Update(issueStatus);
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
            var entityInfo = _IssueStatusRepository.GetById(id);
            try
            {
                _IssueStatusRepository.Delete(entityInfo);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public IssueStatu Get(string id)
        {
            return _IssueStatusRepository.GetById(id);
            //return daItem.Get(id);
        }
        public IEnumerable<IssueStatu> Get(int pageSize, int currentPage, string sortExpression, string filterExpression)
        {
            return _IssueStatusRepository.GetAll();
            //return daIssueStatus.Get(pageSize, currentPage, sortExpression, filterExpression);
        }
        public IEnumerable<IssueStatu> Get()
        {
            //return IssueStatusRepository.GetAll();
            return _IssueStatusRepository.GetAll();
        }
        public void SaveRecord()
        {
            unitOfWork.Commit();
        }
    }
}


