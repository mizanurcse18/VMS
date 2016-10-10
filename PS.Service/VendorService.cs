using System;
using System.Collections.Generic;
using PS.Data.Infrastructure;
using PS.Data.Repository;
using PS.Model.Models;


namespace PS.Service
{
    public interface IVendorService
    {

        bool Save(Vendor vendor);
        bool Update(Vendor entity);
        bool Delete(String id);
        Vendor Get(string id);
        IEnumerable<Vendor> Get(int pageSize, int currentPage, string sortExpression, string filterExpression);
        IEnumerable<Vendor> Get();

        void SaveRecord();
    }
    public class VendorService : IVendorService
    {
        private readonly IVendorRepository _VendorRepository;
        private readonly IUnitOfWork unitOfWork;
        //DAVendor daVendor = new DAVendor();

        public VendorService()
        {
            this._VendorRepository = new VendorRepository(new DatabaseFactory());
            this.unitOfWork = new UnitOfWork(new DatabaseFactory());
        }
        public VendorService(IVendorRepository VendorRepository, IUnitOfWork unitOfWork)
        {
            this._VendorRepository = VendorRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Save(Vendor vendor)
        {
            bool isSuccess = true;
            try
            {
                vendor.ID = Guid.NewGuid().ToString();
                _VendorRepository.Add(vendor);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Update(Vendor vendor)
        {
            bool isSuccess = true;
            try
            {
                _VendorRepository.Update(vendor);
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
            var entityInfo = _VendorRepository.GetById(id);
            try
            {
                _VendorRepository.Delete(entityInfo);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public Vendor Get(string id)
        {
            return _VendorRepository.GetById(id);
            //return daItem.Get(id);
        }
        public IEnumerable<Vendor> Get(int pageSize, int currentPage, string sortExpression, string filterExpression)
        {
            return _VendorRepository.GetAll();
            //return daVendor.Get(pageSize, currentPage, sortExpression, filterExpression);
        }
        public IEnumerable<Vendor> Get()
        {
            //return VendorRepository.GetAll();
            return _VendorRepository.GetAll();
        }
        public void SaveRecord()
        {
            unitOfWork.Commit();
        }
    }
}


