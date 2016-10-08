using System.Collections.Generic;


namespace PS.Service.Interface
{
    public interface IUserService
    {
        //bool Save(User User);
        //bool Update(User entity);
        bool Delete(int id);
       // User Get(string id);
        //User GetUserByUsername(string username);
        //IEnumerable<User> Get(int pageSize, int currentPage, string sortExpression, string filterExpression);
        //IEnumerable<User> Get();
        void SaveRecord();
    }
}