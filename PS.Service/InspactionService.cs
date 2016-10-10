using System;
using System.Collections.Generic;
using PS.Data.Infrastructure;
using PS.Data.Repository;
using PS.Model.Models;


namespace PS.Service
{
    public interface IInspactionService
    {

        bool Save(Inspaction inspaction);
        bool Update(Inspaction entity);
        bool Delete(String id);
        Inspaction Get(string id);
        IEnumerable<Inspaction> Get(int pageSize, int currentPage, string sortExpression, string filterExpression);
        IEnumerable<Inspaction> Get();

        void SaveRecord();
    }
    public class InspactionService : IInspactionService
    {
        private readonly IInspactionRepository _InspactionRepository;
        private readonly IUnitOfWork unitOfWork;
        //DAInspaction daInspaction = new DAInspaction();

        public InspactionService()
        {
            this._InspactionRepository = new InspactionRepository(new DatabaseFactory());
            this.unitOfWork = new UnitOfWork(new DatabaseFactory());
        }
        public InspactionService(IInspactionRepository InspactionRepository, IUnitOfWork unitOfWork)
        {
            this._InspactionRepository = InspactionRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Save(Inspaction inspaction)
        {
            bool isSuccess = true;
            try
            {
                inspaction.ID = Guid.NewGuid().ToString();
                _InspactionRepository.Add(inspaction);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Update(Inspaction inspaction)
        {
            bool isSuccess = true;
            try
            {
                _InspactionRepository.Update(inspaction);
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
            var entityInfo = _InspactionRepository.GetById(id);
            try
            {
                _InspactionRepository.Delete(entityInfo);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public Inspaction Get(string id)
        {
            return _InspactionRepository.GetById(id);
            //return daItem.Get(id);
        }
        public IEnumerable<Inspaction> Get(int pageSize, int currentPage, string sortExpression, string filterExpression)
        {
            return _InspactionRepository.GetAll();
            //return daInspaction.Get(pageSize, currentPage, sortExpression, filterExpression);
        }
        public IEnumerable<Inspaction> Get()
        {
            //return InspactionRepository.GetAll();
            return _InspactionRepository.GetAll();
        }
        public void SaveRecord()
        {
            unitOfWork.Commit();
        }
    }
}


