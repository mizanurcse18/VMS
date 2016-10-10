using System;
using System.Collections.Generic;
using PS.Data.Infrastructure;
using PS.Data.Repository;
using PS.Model.Models;


namespace PS.Service
{
    public interface IVehicleTypeService
    {

        bool Save(VehicleType vehicleType);
        bool Update(VehicleType entity);
        bool Delete(String id);
        VehicleType Get(string id);
        IEnumerable<VehicleType> Get(int pageSize, int currentPage, string sortExpression, string filterExpression);
        IEnumerable<VehicleType> Get();

        void SaveRecord();
    }
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IVehicleTypeRepository _VehicleTypeRepository;
        private readonly IUnitOfWork unitOfWork;
        //DAVehicleType daVehicleType = new DAVehicleType();

        public VehicleTypeService()
        {
            this._VehicleTypeRepository = new VehicleTypeRepository(new DatabaseFactory());
            this.unitOfWork = new UnitOfWork(new DatabaseFactory());
        }
        public VehicleTypeService(IVehicleTypeRepository VehicleTypeRepository, IUnitOfWork unitOfWork)
        {
            this._VehicleTypeRepository = VehicleTypeRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Save(VehicleType vehicleType)
        {
            bool isSuccess = true;
            try
            {
                vehicleType.ID = Guid.NewGuid().ToString();
                _VehicleTypeRepository.Add(vehicleType);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Update(VehicleType vehicleType)
        {
            bool isSuccess = true;
            try
            {
                _VehicleTypeRepository.Update(vehicleType);
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
            var entityInfo = _VehicleTypeRepository.GetById(id);
            try
            {
                _VehicleTypeRepository.Delete(entityInfo);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public VehicleType Get(string id)
        {
            return _VehicleTypeRepository.GetById(id);
            //return daItem.Get(id);
        }
        public IEnumerable<VehicleType> Get(int pageSize, int currentPage, string sortExpression, string filterExpression)
        {
            return _VehicleTypeRepository.GetAll();
            //return daVehicleType.Get(pageSize, currentPage, sortExpression, filterExpression);
        }
        public IEnumerable<VehicleType> Get()
        {
            //return VehicleTypeRepository.GetAll();
            return _VehicleTypeRepository.GetAll();
        }
        public void SaveRecord()
        {
            unitOfWork.Commit();
        }
    }
}


