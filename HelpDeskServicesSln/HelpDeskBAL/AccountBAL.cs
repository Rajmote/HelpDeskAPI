using HelpDeskDAL;
using HelpDeskDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskBAL
{
    public class AccountBAL:IAccountRepository
    {
        private readonly IAccountRepository _repository;

        public AccountBAL(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<DTO_Account> Login(string username, string password, int roleid)
        {
            return await _repository.Login(username, password, roleid);
        }

        public bool IsAuthenticated(int userId, string securityToken)
        {
            return _repository.IsAuthenticated(userId, securityToken);
        }

        public async Task<DTO_User> CreateUser(DTO_User entity)
        {
            return await _repository.CreateUser(entity);
        }

        public async Task<bool> ChangePwd(DTO_ChangePwd entity)
        {
            return await _repository.ChangePwd(entity);
        }

        public async Task<bool> ForgotPwd(DTO_ForgotPwd entity)
        {
            return await _repository.ForgotPwd(entity);
        }
    }
}
