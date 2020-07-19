using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Helpers.Models;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IRepository _repository;

        public UserController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("GetList")]
        public async Task<ActionResult<List<User>>> GetUsers(FilterObj obj)
        {
                var a = await _repository.GetUsers(obj);
                return a;
        }

        [HttpPost]
        [Route("AddUser/{categoryId}")]
        public async Task<ActionResult<User>> AddUser(short categoryId)
        {
            return await _repository.Add(new User()
            {
                CategoryId = categoryId
            });
        }

        [HttpPost]
        [Route("EditUser")]
        public async Task<ActionResult<User>> EditUser(User user)
        {
            return await _repository.Update(user);
        }

        [HttpPost]
        [Route("DeleteUser/{UserId}")]
        public async Task<ActionResult<User>> DeleteUser(int userId)
        {
            return await _repository.Delete(userId);
        }




    }
}
