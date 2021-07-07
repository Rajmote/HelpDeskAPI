using Dapper;
using HelpDeskDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HelpDeskDAL
{
    public class UserRepository : IRepository<DTO_User>
    {
        private readonly IConnectionFactory _connectionFactory;

        public UserRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<DTO_User> Add(DTO_User entity)
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

        public async Task<IEnumerable<DTO_User>> Get()
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                //parameters.Add("@UserId", Convert.ToInt32(HttpContext.Current.Request.Headers["userId"]));
                return await SqlMapper.QueryAsync<DTO_User>(_connectionFactory.GetConnection(), "Usp_User_ReadAll", commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DTO_User> Get(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", id);
                return await SqlMapper.QueryFirstOrDefaultAsync<DTO_User>(_connectionFactory.GetConnection(), "Usp_User_Read", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DTO_User> Update(DTO_User entity)
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
                parameters.Add("@UserId", entity.UserId);
                return await SqlMapper.QueryFirstOrDefaultAsync<DTO_User>(_connectionFactory.GetConnection(), "Usp_User_Update",
                    parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region " Unused "
        public async Task<DTO_User> Delete(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", id);
                return await SqlMapper.QueryFirstOrDefaultAsync<DTO_User>(_connectionFactory.GetConnection(), "Usp_User_Delete", parameters, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
