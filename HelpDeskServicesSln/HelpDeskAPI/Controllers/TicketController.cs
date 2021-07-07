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
    public class TicketController : ApiController
    {
        private readonly IRepository<DTO_Ticket> _repository;
        public TicketController()
        {

        }
        public TicketController(IRepository<DTO_Ticket> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ActionName("GetTicket")]
        public async Task<DTO_Ticket> Get(int id)
        {
                return await _repository.Get(id); 
        }

        [HttpGet]
        [ActionName("GetTickets")]
        public async Task<IEnumerable<DTO_Ticket>> Get()
        {         
            return await _repository.Get();
        }

        [HttpPost]
        [ActionName("CreateTicket")]
        public async Task<DTO_Ticket> Add(DTO_Ticket entity)
        {
                //entity.UserId = Convert.ToInt32(HttpContext.Current.Request.Headers["userId"]);
                return await _repository.Add(entity);
        }

        [HttpPut]
        [ActionName("UpdateTicket")]
        public async Task<DTO_Ticket> Update(DTO_Ticket entity)
        {
            //entity.UserId = Convert.ToInt32(HttpContext.Current.Request.Headers["userId"]);
            return await _repository.Update(entity);
        }

        [HttpDelete]
        [ActionName("DeleteTicket")]
        public async Task<DTO_Ticket> Delete(int id)
        {
                return await _repository.Delete(id);
        }

    }
}