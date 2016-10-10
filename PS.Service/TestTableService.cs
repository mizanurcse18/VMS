using System;
using System.Collections.Generic;
using PS.Data.Infrastructure;
using PS.Data.Repository;
using PS.Model.Models;


namespace PS.Service
{
    public interface ITestTableService
    {
        bool Save(TestTable entity);
        bool Update(TestTable entity);
        bool Delete(string id);
        TestTable Get(int id);
        IEnumerable<TestTable> Get(int pageSize, int currentPage, string sortExpression, string filterExpression);
        IEnumerable<TestTable> Get();

        void SaveRecord();
    }
    public class TestTableService : ITestTableService
    {
        private readonly ITestTableRepository _TestTableRepository;
        private readonly IUnitOfWork unitOfWork;
        //DATestTable daTestTable = new DATestTable();

        public TestTableService()
        {
            this._TestTableRepository = new TestTableRepository(new DatabaseFactory());
            this.unitOfWork = new UnitOfWork(new DatabaseFactory());
        }
        public TestTableService(ITestTableRepository TestTableRepository, IUnitOfWork unitOfWork)
        {
            this._TestTableRepository = TestTableRepository;
            this.unitOfWork = unitOfWork;
        }
        public bool Save(TestTable entity)
        {
            bool isSuccess = true;
            try
            {
                entity.ID = Guid.NewGuid().ToString();
                _TestTableRepository.Add(entity);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Update(TestTable TestTable)
        {
            bool isSuccess = true;
            try
            {
                _TestTableRepository.Update(TestTable);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public bool Delete(string id)
        {
            bool isSuccess = true;
            var entityInfo = _TestTableRepository.GetById(id);
            try
            {
                _TestTableRepository.Delete(entityInfo);
            }
            catch
            {
                isSuccess = false;
            }
            return isSuccess;
        }
        public TestTable Get(string id)
        {
            return _TestTableRepository.GetById(id);
            //return daTestTable.Get(id);
        }
        public IEnumerable<TestTable> Get(int pageSize, int currentPage, string sortExpression, string filterExpression)
        {
            return _TestTableRepository.GetAll();
            //return daTestTable.Get(pageSize, currentPage, sortExpression, filterExpression);
        }
        public IEnumerable<TestTable> Get()
        {
            //return TestTableRepository.GetAll();
            return _TestTableRepository.GetAll();
        }
        public void SaveRecord()
        {
            unitOfWork.Commit();
        }
    }
}
