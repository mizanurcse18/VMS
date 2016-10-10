using System;
using System.Collections.Generic;
using PS.Data.Infrastructure;
using PS.Data.Repository;
using PS.Model.Models;


namespace PS.Service
{
    public interface IVehicleStatusService
    {

        bool Save(VehicleStatu VehicleStatu);
        bool Update(VehicleStatu entity);
        bool Delete(String id);
        VehicleStatu Get(string id);
        IEnumerable<VehicleStatu> Get(int pageSize, int currentPage, string sortExpression, string filterExpression);
        IEnumerable<VehicleStatu> Get();

        void SaveRecord();
    }
    public class VehicleStatuService : IVehicleStatusService
    {
        private readonly IVehicleStatusRepository _VehicleStatuRepository;
        private readonly IUnitOfWork unitOfWork;
        //DAVehicleStatu daVehicleStatu = new DAVehicleStatu();

        public VehicleStatuService()
        {
            this._VehicleStatuRepository = new VehicleStatusRepository(new DatabaseFactory());
            this.unitOfWork = new UnitOfWork(new DatabaseFactory());
        }
        public VehicleStatuService(IVehicleStatusRepository VehicleStatuRepository, IUnitOfWork unitOfWork)
        {
            this._VehicleStatuRepository = VehicleStatuRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Save(VehicleStatu VehicleStatu)
        {
            bool isSuccess = true;
            try
            {
                VehicleStatu.ID = Guid.NewGuid().ToString();
                _VehicleStatuRepository.Add(VehicleStatu);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Update(VehicleStatu VehicleStatu)
        {
            bool isSuccess = true;
            try
            {
                _VehicleStatuRepository.Update(VehicleStatu);
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
            var entityInfo = _VehicleStatuRepository.GetById(id);
            try
            {
                _VehicleStatuRepository.Delete(entityInfo);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public VehicleStatu Get(string id)
        {
            return _VehicleStatuRepository.GetById(id);
            //return daItem.Get(id);
        }
        public IEnumerable<VehicleStatu> Get(int pageSize, int currentPage, string sortExpression, string filterExpression)
        {
            return _VehicleStatuRepository.GetAll();
            //return daVehicleStatu.Get(pageSize, currentPage, sortExpression, filterExpression);
        }
        public IEnumerable<VehicleStatu> Get()
        {
            //return VehicleStatuRepository.GetAll();
            return _VehicleStatuRepository.GetAll();
        }
        public void SaveRecord()
        {
            unitOfWork.Commit();
        }
    }
}


