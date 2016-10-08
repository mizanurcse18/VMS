using System;
using System.Collections.Generic;
using PS.Data.Infrastructure;
using PS.Data.Repository;
using PS.Model.Models;


namespace PS.Service
{
    public interface IVehicleGroupService
    {

        bool Save(VehicleGroup vehicleGroup);
        bool Update(VehicleGroup entity);
        bool Delete(String id);
        VehicleGroup Get(string id);
        IEnumerable<VehicleGroup> Get(int pageSize, int currentPage, string sortExpression, string filterExpression);
        IEnumerable<VehicleGroup> Get();

        void SaveRecord();
    }
    public class VehicleGroupService : IVehicleGroupService
    {
        private readonly IVehicleGroupRepository _VehicleGroupRepository;
        private readonly IUnitOfWork unitOfWork;
        //DAVehicleGroup daVehicleGroup = new DAVehicleGroup();

        public VehicleGroupService()
        {
            this._VehicleGroupRepository = new VehicleGroupRepository(new DatabaseFactory());
            this.unitOfWork = new UnitOfWork(new DatabaseFactory());
        }
        public VehicleGroupService(IVehicleGroupRepository VehicleGroupRepository, IUnitOfWork unitOfWork)
        {
            this._VehicleGroupRepository = VehicleGroupRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Save(VehicleGroup vehicleGroup)
        {
            bool isSuccess = true;
            try
            {
                vehicleGroup.ID = Guid.NewGuid().ToString();
                _VehicleGroupRepository.Add(vehicleGroup);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Update(VehicleGroup vehicleGroup)
        {
            bool isSuccess = true;
            try
            {
                _VehicleGroupRepository.Update(vehicleGroup);
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
            var entityInfo = _VehicleGroupRepository.GetById(id);
            try
            {
                _VehicleGroupRepository.Delete(entityInfo);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public VehicleGroup Get(string id)
        {
            return _VehicleGroupRepository.GetById(id);
            //return daItem.Get(id);
        }
        public IEnumerable<VehicleGroup> Get(int pageSize, int currentPage, string sortExpression, string filterExpression)
        {
            return _VehicleGroupRepository.GetAll();
            //return daVehicleGroup.Get(pageSize, currentPage, sortExpression, filterExpression);
        }
        public IEnumerable<VehicleGroup> Get()
        {
            //return VehicleGroupRepository.GetAll();
            return _VehicleGroupRepository.GetAll();
        }
        public void SaveRecord()
        {
            unitOfWork.Commit();
        }
    }
}


