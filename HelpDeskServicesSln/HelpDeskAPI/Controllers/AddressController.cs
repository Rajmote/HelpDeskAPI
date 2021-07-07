using HelpDeskDAL;
using HelpDeskDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HelpDeskAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AddressController : ApiController
    {
        private readonly IAddressRepository _repository;
        public AddressController()
        {

        }
        public AddressController(IAddressRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ActionName("GetCity")]
        public async Task<IEnumerable<DTO_DropDown>> GetCity(int id)
        {
            return await _repository.GetCity(id);
        }

        [HttpGet]
        [ActionName("GetState")]
        public async Task<IEnumerable<DTO_DropDown>> GetState(int id)
        {
            return await _repository.GetState(id);
        }

        [HttpGet]
        [ActionName("GetCountry")]
        public async Task<IEnumerable<DTO_DropDown>> GetCountry()
        {
            return await _repository.GetCountry();
        }
    }
}
