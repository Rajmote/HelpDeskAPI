using HelpDeskDAL;
using HelpDeskDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskBAL
{
    public class TicketBAL: IRepository<DTO_Ticket>
    {
        private readonly IRepository<DTO_Ticket> _repository;

        public TicketBAL(IRepository<DTO_Ticket> repository)
        {
            _repository = repository;
        }
        public async Task<DTO_Ticket> Add(DTO_Ticket entity)
        {
            return await _repository.Add(entity);
        }

        public async Task<DTO_Ticket> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<DTO_Ticket>> Get() 
        {
            return await _repository.Get();
        }

        public async Task<DTO_Ticket> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<DTO_Ticket> Update(DTO_Ticket entity)
        {
            return await _repository.Update(entity);
        }
    }
}
