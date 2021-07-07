using Dapper;
using HelpDeskDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace HelpDeskDAL
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public AddressRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<DTO_DropDown>> GetCity(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@StateId", id);
                var result = await SqlMapper.QueryAsync<DTO_DropDown>(_connectionFactory.GetConnection(), "Usp_City_ReadAll", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<DTO_DropDown>> GetCountry()
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                //parameters.Add("@Id", id);
                var result = await SqlMapper.QueryAsync<DTO_DropDown>(_connectionFactory.GetConnection(), "Usp_Country_ReadAll", commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<DTO_DropDown>> GetState(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CountryId", id);
                var result =await  SqlMapper.QueryAsync<DTO_DropDown>(_connectionFactory.GetConnection(), "Usp_State_ReadAll", parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
