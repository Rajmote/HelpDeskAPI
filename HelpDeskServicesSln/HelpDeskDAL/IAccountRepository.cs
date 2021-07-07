using HelpDeskDTO;
using System.Threading.Tasks;

namespace HelpDeskDAL
{
    public interface IAccountRepository
    {
        Task<DTO_Account> Login(string username, string password, int roleid);

        bool IsAuthenticated(int userId, string securityToken);
        Task<DTO_User> CreateUser(DTO_User entity);

        Task<bool> ChangePwd(DTO_ChangePwd entity);

        Task<bool> ForgotPwd(DTO_ForgotPwd entity);
    }
}
