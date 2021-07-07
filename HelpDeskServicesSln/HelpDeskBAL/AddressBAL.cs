using HelpDeskDAL;
using HelpDeskDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskBAL
{
    public class AddressBAL : IAddressRepository
    {
        private readonly IAddressRepository _repository;

        public AddressBAL(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DTO_DropDown>> GetCity(int id)
        {
            return await _repository.GetCity(id);
        }

        public async Task<IEnumerable<DTO_DropDown>> GetCountry()
        {
            return await _repository.GetCountry();
        }

        public async Task<IEnumerable<DTO_DropDown>> GetState(int id)
        {
            return await _repository.GetState(id);
        }
    }
}
