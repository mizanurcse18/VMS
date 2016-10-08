using System;
using System.Collections.Generic;
using PS.Data.Infrastructure;
using PS.Data.Repository;
using PS.Model.Models;


namespace PS.Service
{
    public interface IVehicleService
    {

        bool Save(Vehicle vehicle);
        bool Update(Vehicle entity);
        bool Delete(String id);
        Vehicle Get(string id);
        IEnumerable<Vehicle> Get(int pageSize, int currentPage, string sortExpression, string filterExpression);
        IEnumerable<Vehicle> Get();

        void SaveRecord();
    }
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _VehicleRepository;
        private readonly IUnitOfWork unitOfWork;
        //DAVehicle daVehicle = new DAVehicle();

        public VehicleService()
        {
            this._VehicleRepository = new VehicleRepository(new DatabaseFactory());
            this.unitOfWork = new UnitOfWork(new DatabaseFactory());
        }
        public VehicleService(IVehicleRepository VehicleRepository, IUnitOfWork unitOfWork)
        {
            this._VehicleRepository = VehicleRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Save(Vehicle vehicle)
        {
            bool isSuccess = true;
            try
            {
                vehicle.ID = Guid.NewGuid().ToString();
                _VehicleRepository.Add(vehicle);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Update(Vehicle vehicle)
        {
            bool isSuccess = true;
            try
            {
                _VehicleRepository.Update(vehicle);
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
            var entityInfo = _VehicleRepository.GetById(id);
            try
            {
                _VehicleRepository.Delete(entityInfo);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public Vehicle Get(string id)
        {
            return _VehicleRepository.GetById(id);
            //return daItem.Get(id);
        }
        public IEnumerable<Vehicle> Get(int pageSize, int currentPage, string sortExpression, string filterExpression)
        {
            return _VehicleRepository.GetAll();
            //return daVehicle.Get(pageSize, currentPage, sortExpression, filterExpression);
        }
        public IEnumerable<Vehicle> Get()
        {
            //return VehicleRepository.GetAll();
            return _VehicleRepository.GetAll();
        }
        public void SaveRecord()
        {
            unitOfWork.Commit();
        }
    }
}


