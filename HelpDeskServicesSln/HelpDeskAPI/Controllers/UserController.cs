using HelpDeskAPI.Filter;
using HelpDeskDAL;
using HelpDeskDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HelpDeskAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [AuthorizeUserFilter(true)]
    public class UserController : ApiController
    {
        private readonly IRepository<DTO_User> _repository;
        public UserController()
        {

        }
        public UserController(IRepository<DTO_User> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ActionName("GetUser")]
        public async Task<DTO_User> Get(int id)
        {
            return await _repository.Get(id);
        }

        [HttpGet]
        [ActionName("GetUsers")]
        public async Task<IEnumerable<DTO_User>> Get()
        {
            return await _repository.Get();
        }

        [HttpPost]
        [ActionName("CreateUser")]
        public async Task<DTO_User> Add(DTO_User entity)
        {
            return await _repository.Add(entity);
        }

        [HttpPut]
        [ActionName("UpdateUser")]
        public async Task<DTO_User> Update(DTO_User entity)
        {
            return await _repository.Update(entity);
        }

        [HttpDelete]
        [ActionName("DeleteUser")]
        public async Task<DTO_User> Delete(int id)
        {
            return await _repository.Delete(id);
        }
    }
}
