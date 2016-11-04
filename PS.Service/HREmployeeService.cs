using System;
using System.Collections.Generic;
using PS.Data.Infrastructure;
using PS.Data.Repository;
using PS.DataAccess.Vehicle;
using PS.Model.Models;


namespace PS.Service
{
    public interface IHREmployeeService
    {

        bool Save(HREmployee hREmployee);
        bool Update(HREmployee entity);
        bool Delete(String id);
        HREmployee Get(string id);
        IEnumerable<HREmployee> Get(int pageSize, int currentPage, string sortExpression, string filterExpression);
        IEnumerable<HREmployee> Get();

        void SaveRecord();
    }
    public class HREmployeeService : IHREmployeeService
    {
        private readonly IHREmployeeRepository _HREmployeeRepository;
        private readonly IUnitOfWork unitOfWork;
        DAHREmployee hrEmployeeDA = new DAHREmployee();

        public HREmployeeService()
        {
            this._HREmployeeRepository = new HREmployeeRepository(new DatabaseFactory());
            this.unitOfWork = new UnitOfWork(new DatabaseFactory());
        }
        public HREmployeeService(IHREmployeeRepository HREmployeeRepository, IUnitOfWork unitOfWork)
        {
            this._HREmployeeRepository = HREmployeeRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Save(HREmployee hREmployee)
        {
            bool isSuccess = true;
            try
            {
                hREmployee.ID = Guid.NewGuid().ToString();
                _HREmployeeRepository.Add(hREmployee);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Update(HREmployee hREmployee)
        {
            bool isSuccess = true;
            try
            {
                _HREmployeeRepository.Update(hREmployee);
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
            var entityInfo = _HREmployeeRepository.GetById(id);
            try
            {
                _HREmployeeRepository.Delete(entityInfo);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public HREmployee Get(string id)
        {
            return _HREmployeeRepository.GetById(id);
            //return daItem.Get(id);
        }
        public IEnumerable<HREmployee> Get(int pageSize, int currentPage, string sortExpression, string filterExpression)
        {
            return hrEmployeeDA.Get(pageSize, currentPage, sortExpression, filterExpression);
        }
        public IEnumerable<HREmployee> Get()
        {
            //return HREmployeeRepository.GetAll();
            return _HREmployeeRepository.GetAll();
        }
        public void SaveRecord()
        {
            unitOfWork.Commit();
        }
    }
}


