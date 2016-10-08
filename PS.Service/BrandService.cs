using System;
using System.Collections.Generic;
using PS.Data.Infrastructure;
using PS.Data.Repository;
using PS.Model.Models;


namespace PS.Service
{
    public interface IBrandService
    {

        bool Save(Brand brand);
        bool Update(Brand entity);
        bool Delete(String id);
        Brand Get(string id);
        IEnumerable<Brand> Get(int pageSize, int currentPage, string sortExpression, string filterExpression);
        IEnumerable<Brand> Get();

        void SaveRecord();
    }
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _BrandRepository;
        private readonly IUnitOfWork unitOfWork;
        //DABrand daBrand = new DABrand();

        public BrandService()
        {
            this._BrandRepository = new BrandRepository(new DatabaseFactory());
            this.unitOfWork = new UnitOfWork(new DatabaseFactory());
        }
        public BrandService(IBrandRepository BrandRepository, IUnitOfWork unitOfWork)
        {
            this._BrandRepository = BrandRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Save(Brand brand)
        {
            bool isSuccess = true;
            try
            {
                brand.ID = Guid.NewGuid().ToString();
                _BrandRepository.Add(brand);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Update(Brand brand)
        {
            bool isSuccess = true;
            try
            {
                _BrandRepository.Update(brand);
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
            var entityInfo = _BrandRepository.GetById(id);
            try
            {
                _BrandRepository.Delete(entityInfo);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public Brand Get(string id)
        {
            return _BrandRepository.GetById(id);
            //return daItem.Get(id);
        }
        public IEnumerable<Brand> Get(int pageSize, int currentPage, string sortExpression, string filterExpression)
        {
            return _BrandRepository.GetAll();
            //return daBrand.Get(pageSize, currentPage, sortExpression, filterExpression);
        }
        public IEnumerable<Brand> Get()
        {
            //return BrandRepository.GetAll();
            return _BrandRepository.GetAll();
        }
        public void SaveRecord()
        {
            unitOfWork.Commit();
        }
    }
}


