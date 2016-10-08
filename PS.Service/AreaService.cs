 
/*
* Tools: Code Generator
* Author: Md. Mizanur Rahman
* Software Engineer 
* Phone : 01672352566
* Email: munna.cse_18@yahoo.com
* */
//Please Rename your Namespace
// Code Generate Time - 05/10/2016 08:57:50 PM


using System;
using System.Collections.Generic;
using PS.Data.Infrastructure;
using PS.Data.Repository;
using PS.Model.Models;


namespace PS.Service
{
    public interface IAreaService
    {

        bool Save(Area area);
        bool Update(Area entity);
        bool Delete(String id);
        Area Get(string id);
        IEnumerable<Area> Get(int pageSize, int currentPage, string sortExpression, string filterExpression);
        IEnumerable<Area> Get();

        void SaveRecord();
    }
    public class AreaService : IAreaService
    {
        private readonly IAreaRepository _AreaRepository;
        private readonly IUnitOfWork unitOfWork;
        //DAArea daArea = new DAArea();

        public AreaService()
        {
            this._AreaRepository = new AreaRepository(new DatabaseFactory());
            this.unitOfWork = new UnitOfWork(new DatabaseFactory());
        }
        public AreaService(IAreaRepository AreaRepository, IUnitOfWork unitOfWork)
        {
            this._AreaRepository = AreaRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Save(Area area)
        {
            bool isSuccess = true;
            try
            {
                area.ID = Guid.NewGuid().ToString();
                _AreaRepository.Add(area);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Update(Area area)
        {
            bool isSuccess = true;
            try
            {
                _AreaRepository.Update(area);
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
            var entityInfo = _AreaRepository.GetById(id);
            try
            {
                _AreaRepository.Delete(entityInfo);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public Area Get(string id)
        {
            return _AreaRepository.GetById(id);
            //return daItem.Get(id);
        }
        public IEnumerable<Area> Get(int pageSize, int currentPage, string sortExpression, string filterExpression)
        {
            return _AreaRepository.GetAll();
            //return daArea.Get(pageSize, currentPage, sortExpression, filterExpression);
        }
        public IEnumerable<Area> Get()
        {
            //return AreaRepository.GetAll();
            return _AreaRepository.GetAll();
        }
        public void SaveRecord()
        {
            unitOfWork.Commit();
        }
    }
}


