using Dapper;
using HelpDeskDTO;
using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HelpDeskDAL
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public AccountRepository()
        {
            _connectionFactory = new ConnectionFactory();
        }

        public AccountRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public bool IsAuthenticated(int userId, string securityToken)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", userId);
                parameters.Add("@Token", securityToken);
                var result =  SqlMapper.QueryFirstOrDefault<DTO_Account>(_connectionFactory.GetConnection(), "Usp_IsAuthenticate", parameters, commandType: CommandType.StoredProcedure);
                if(result!= null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DTO_Account> Login(string username, string password, int roleid)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserName", username);
                parameters.Add("@Password", password);
                parameters.Add("@RoleId", roleid);
                var result = SqlMapper.QueryFirstOrDefault<DTO_Account>(_connectionFactory.GetConnection(), "Usp_Login", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DTO_User> CreateUser(DTO_User entity) 
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Name", entity.Name);
                parameters.Add("@Mobile", entity.Mobile);
                parameters.Add("@EmailId", entity.EmailId);
                parameters.Add("@Address1", entity.Address1);
                parameters.Add("@Address2", entity.Address2);
                parameters.Add("@Pincode", entity.Pincode);
                parameters.Add("@CityId", entity.CityId);
                parameters.Add("@RoleId", entity.RoleId);
                parameters.Add("@StatusId", entity.StatusId);
                parameters.Add("@AdharId", entity.AdharId);
                parameters.Add("@Password", entity.Password);
                parameters.Add("@Token", entity.Token);
                return await SqlMapper.QueryFirstOrDefaultAsync<DTO_User>(_connectionFactory.GetConnection(), "Usp_User_Create", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ChangePwd(DTO_ChangePwd entity)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", entity.userId);
                parameters.Add("@Password", entity.oldPwd);
                parameters.Add("@NewPassword", entity.newPwd);
                var result = await SqlMapper.ExecuteAsync(_connectionFactory.GetConnection(), "Usp_ChangePassWord", parameters, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> ForgotPwd(DTO_ForgotPwd entity) 
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@mobileno", entity.mobileno);
                parameters.Add("@emailId", entity.emailId);
                var result = SqlMapper.QueryFirstOrDefault<string>(_connectionFactory.GetConnection(), "Usp_ForgotPwd", parameters, commandType: CommandType.StoredProcedure);
                string body = "Your password for Customer Help Desk portal is => " + result;
                SendEmail(entity.emailId, body);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void SendEmail(string emailid, string body)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                UseDefaultCredentials = false,
                Port = 587,
                Credentials = new NetworkCredential("snehaldgarad@gmail.com", "Enrique7@"),
                EnableSsl = true,
            };

            smtpClient.Send("snehaldgarad@gmail.com", emailid, "Mail From Customer Help desk", body);
        }
    }
}
