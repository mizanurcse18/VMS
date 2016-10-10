using System;
using System.Collections.Generic;
using PS.Data.Infrastructure;
using PS.Data.Repository;
using PS.Model.Models;


namespace PS.Service
{
    public interface IHREmployeeTypeService
    {

        bool Save(HREmployeeType hREmployeeType);
        bool Update(HREmployeeType entity);
        bool Delete(String id);
        HREmployeeType Get(string id);
        IEnumerable<HREmployeeType> Get(int pageSize, int currentPage, string sortExpression, string filterExpression);
        IEnumerable<HREmployeeType> Get();

        void SaveRecord();
    }
    public class HREmployeeTypeService : IHREmployeeTypeService
    {
        private readonly IHREmployeeTypeRepository _HREmployeeTypeRepository;
        private readonly IUnitOfWork unitOfWork;
        //DAHREmployeeType daHREmployeeType = new DAHREmployeeType();

        public HREmployeeTypeService()
        {
            this._HREmployeeTypeRepository = new HREmployeeTypeRepository(new DatabaseFactory());
            this.unitOfWork = new UnitOfWork(new DatabaseFactory());
        }
        public HREmployeeTypeService(IHREmployeeTypeRepository HREmployeeTypeRepository, IUnitOfWork unitOfWork)
        {
            this._HREmployeeTypeRepository = HREmployeeTypeRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Save(HREmployeeType hREmployeeType)
        {
            bool isSuccess = true;
            try
            {
                hREmployeeType.ID = Guid.NewGuid().ToString();
                _HREmployeeTypeRepository.Add(hREmployeeType);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Update(HREmployeeType hREmployeeType)
        {
            bool isSuccess = true;
            try
            {
                _HREmployeeTypeRepository.Update(hREmployeeType);
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
            var entityInfo = _HREmployeeTypeRepository.GetById(id);
            try
            {
                _HREmployeeTypeRepository.Delete(entityInfo);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public HREmployeeType Get(string id)
        {
            return _HREmployeeTypeRepository.GetById(id);
            //return daItem.Get(id);
        }
        public IEnumerable<HREmployeeType> Get(int pageSize, int currentPage, string sortExpression, string filterExpression)
        {
            return _HREmployeeTypeRepository.GetAll();
            //return daHREmployeeType.Get(pageSize, currentPage, sortExpression, filterExpression);
        }
        public IEnumerable<HREmployeeType> Get()
        {
            //return HREmployeeTypeRepository.GetAll();
            return _HREmployeeTypeRepository.GetAll();
        }
        public void SaveRecord()
        {
            unitOfWork.Commit();
        }
    }
}


