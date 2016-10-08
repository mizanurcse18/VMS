 
/*
* Tools: Code Generator
* Author: Md. Mizanur Rahman
* Software Engineer 
* Phone : 01672352566
* Email: munna.cse_18@yahoo.com
* */
//Please Rename your Namespace
// Code Generate Time - 05/10/2016 08:57:45 PM


using PS.Data.Infrastructure;
using PS.Model.Models;

namespace PS.Data.Repository
{
    public class AreaRepository: RepositoryBase<Area>, IAreaRepository
    {
        public AreaRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }

    public interface IAreaRepository : IRepository<Area>
    {
    }
}


