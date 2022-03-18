using HelpDeskDAL;
using HelpDeskDTO;
using System.Threading.Tasks;
using System.Web.Http;

namespace HelpDeskAPI.Controllers
{
   // To check devops setting
    public class AccountController : ApiController
    {
        private readonly IAccountRepository _repository;

        public AccountController()
        {

        }
        public AccountController(IAccountRepository repository) 
        {
            _repository = repository;
        }

        [HttpPost]
        [ActionName("Login")]
        public async Task<DTO_Account> PostAsync(DTO_Login input)  
        {
            return await _repository.Login(input.username, input.password, input.roleid);
        }

        [HttpPost]
        [ActionName("CreateUser")]
        public async Task<DTO_User> CreateUser(DTO_User entity)
        {
            return await _repository.CreateUser(entity);
        }

        [HttpPost]
        [ActionName("ChangePwd")]
        public async Task<bool> ChangePwd(DTO_ChangePwd entity)
        {
            return await _repository.ChangePwd(entity);
        }

        [HttpPost]
        [ActionName("ForgotPwd")]
        public async Task<bool> ForgotPwd(DTO_ForgotPwd entity)
        {
            return await _repository.ForgotPwd(entity);
        }

    }
}