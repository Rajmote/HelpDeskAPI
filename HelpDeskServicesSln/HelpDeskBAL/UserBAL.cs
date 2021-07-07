using HelpDeskDAL;
using HelpDeskDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskBAL
{
    public class UserBAL : IRepository<DTO_User>
    {
        private readonly IRepository<DTO_User> _repository;

        public UserBAL(IRepository<DTO_User> repository)
        {
            _repository = repository;
        }
        public async Task<DTO_User> Add(DTO_User entity)
        {
            return await _repository.Add(entity);
        }

        public async Task<DTO_User> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<DTO_User>> Get()
        {
            return await _repository.Get();
        }

        public async Task<DTO_User> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<DTO_User> Update(DTO_User entity)
        {
            return await _repository.Update(entity);
        }
    }
}
