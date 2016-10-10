using System;
using System.Collections.Generic;
using PS.Data.Infrastructure;
using PS.Data.Repository;
using PS.Model.Models;


namespace PS.Service
{
    public interface IInspactionDetailService
    {

        bool Save(InspactionDetail inspactionDetail);
        bool Update(InspactionDetail entity);
        bool Delete(String id);
        InspactionDetail Get(string id);
        IEnumerable<InspactionDetail> Get(int pageSize, int currentPage, string sortExpression, string filterExpression);
        IEnumerable<InspactionDetail> Get();

        void SaveRecord();
    }
    public class InspactionDetailService : IInspactionDetailService
    {
        private readonly IInspactionDetailRepository _InspactionDetailRepository;
        private readonly IUnitOfWork unitOfWork;
        //DAInspactionDetail daInspactionDetail = new DAInspactionDetail();

        public InspactionDetailService()
        {
            this._InspactionDetailRepository = new InspactionDetailRepository(new DatabaseFactory());
            this.unitOfWork = new UnitOfWork(new DatabaseFactory());
        }
        public InspactionDetailService(IInspactionDetailRepository InspactionDetailRepository, IUnitOfWork unitOfWork)
        {
            this._InspactionDetailRepository = InspactionDetailRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Save(InspactionDetail inspactionDetail)
        {
            bool isSuccess = true;
            try
            {
                inspactionDetail.ID = Guid.NewGuid().ToString();
                _InspactionDetailRepository.Add(inspactionDetail);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Update(InspactionDetail inspactionDetail)
        {
            bool isSuccess = true;
            try
            {
                _InspactionDetailRepository.Update(inspactionDetail);
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
            var entityInfo = _InspactionDetailRepository.GetById(id);
            try
            {
                _InspactionDetailRepository.Delete(entityInfo);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public InspactionDetail Get(string id)
        {
            return _InspactionDetailRepository.GetById(id);
            //return daItem.Get(id);
        }
        public IEnumerable<InspactionDetail> Get(int pageSize, int currentPage, string sortExpression, string filterExpression)
        {
            return _InspactionDetailRepository.GetAll();
            //return daInspactionDetail.Get(pageSize, currentPage, sortExpression, filterExpression);
        }
        public IEnumerable<InspactionDetail> Get()
        {
            //return InspactionDetailRepository.GetAll();
            return _InspactionDetailRepository.GetAll();
        }
        public void SaveRecord()
        {
            unitOfWork.Commit();
        }
    }
}


