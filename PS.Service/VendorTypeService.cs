using System;
using System.Collections.Generic;
using PS.Data.Infrastructure;
using PS.Data.Repository;
using PS.Model.Models;


namespace PS.Service
{
    public interface IVendorTypeService
    {

        bool Save(VendorType vendorType);
        bool Update(VendorType entity);
        bool Delete(String id);
        VendorType Get(string id);
        IEnumerable<VendorType> Get(int pageSize, int currentPage, string sortExpression, string filterExpression);
        IEnumerable<VendorType> Get();

        void SaveRecord();
    }
    public class VendorTypeService : IVendorTypeService
    {
        private readonly IVendorTypeRepository _VendorTypeRepository;
        private readonly IUnitOfWork unitOfWork;
        //DAVendorType daVendorType = new DAVendorType();

        public VendorTypeService()
        {
            this._VendorTypeRepository = new VendorTypeRepository(new DatabaseFactory());
            this.unitOfWork = new UnitOfWork(new DatabaseFactory());
        }
        public VendorTypeService(IVendorTypeRepository VendorTypeRepository, IUnitOfWork unitOfWork)
        {
            this._VendorTypeRepository = VendorTypeRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Save(VendorType vendorType)
        {
            bool isSuccess = true;
            try
            {
                vendorType.ID = Guid.NewGuid().ToString();
                _VendorTypeRepository.Add(vendorType);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Update(VendorType vendorType)
        {
            bool isSuccess = true;
            try
            {
                _VendorTypeRepository.Update(vendorType);
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
            var entityInfo = _VendorTypeRepository.GetById(id);
            try
            {
                _VendorTypeRepository.Delete(entityInfo);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public VendorType Get(string id)
        {
            return _VendorTypeRepository.GetById(id);
            //return daItem.Get(id);
        }
        public IEnumerable<VendorType> Get(int pageSize, int currentPage, string sortExpression, string filterExpression)
        {
            return _VendorTypeRepository.GetAll();
            //return daVendorType.Get(pageSize, currentPage, sortExpression, filterExpression);
        }
        public IEnumerable<VendorType> Get()
        {
            //return VendorTypeRepository.GetAll();
            return _VendorTypeRepository.GetAll();
        }
        public void SaveRecord()
        {
            unitOfWork.Commit();
        }
    }
}


