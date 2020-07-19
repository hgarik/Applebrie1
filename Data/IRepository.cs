using WebApi.Data;
using WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers.Models;

namespace WebApi.Data
{
    public interface IRepository
    {
        Task<List<User>> GetUsers(FilterObj obj);
        //Task<User> GetById(int userId);
        Task<User> Add(IBaseEntity obj);
        Task<User> Update(IBaseEntity obj);
        Task<User> Delete(int userId);

    }
}
