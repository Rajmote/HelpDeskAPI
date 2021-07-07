using Dapper;
using HelpDeskDTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HelpDeskDAL
{
    public class TicketRepository : IRepository<DTO_Ticket>
    {
        private readonly IConnectionFactory _connectionFactory;

        public TicketRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<DTO_Ticket> Add(DTO_Ticket entity)
        {
            try
            {
                if(entity.InWarranty=="on")
                {
                    entity.InWarranty = "1";
                }
                else
                {
                    entity.InWarranty = "0";
                }

                DynamicParameters parameters = new DynamicParameters();
                //parameters.Add("@TicketId", entity.TicketId);
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@ProductId", entity.ProductId);
                parameters.Add("@ProductModel", entity.ProductModel);
                parameters.Add("@ProductType", entity.ProductType);
                parameters.Add("@StatusId", entity.StatusId);
                parameters.Add("@InvoiceId", entity.InvoiceId);
                parameters.Add("@Issue", entity.Issue);
                parameters.Add("@Comments", entity.Comments);
                parameters.Add("@InvDate", entity.InvDate);
                parameters.Add("@InWarranty", entity.InWarranty);
                var result = await SqlMapper.QueryFirstOrDefaultAsync<DTO_Ticket>(_connectionFactory.GetConnection(), "Usp_Ticket_Create", parameters, commandType: CommandType.StoredProcedure);

                string body = "The new Ticket has been created. for Product ID : "+ entity.ProductId;
                SendEmail(entity.UserId, body);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<DTO_Ticket>> Get()
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", Convert.ToInt32(HttpContext.Current.Request.Headers["userId"]));
                return await SqlMapper.QueryAsync<DTO_Ticket>(_connectionFactory.GetConnection(), "Usp_Ticket_ReadAll", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DTO_Ticket> Get(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TicketId", id);
                return await SqlMapper.QueryFirstOrDefaultAsync<DTO_Ticket>(_connectionFactory.GetConnection(), "Usp_Ticket_Read", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DTO_Ticket> Update(DTO_Ticket entity)
        {
            try
            {
                if (entity.InWarranty == "on")
                {
                    entity.InWarranty = "1";
                }
                else
                {
                    entity.InWarranty = "0";
                }

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TicketId", entity.TicketId);
                parameters.Add("@UserId", entity.UserId);
                parameters.Add("@ProductId", entity.ProductId);
                parameters.Add("@ProductModel", entity.ProductModel);
                parameters.Add("@ProductType", entity.ProductType);
                parameters.Add("@StatusId", entity.StatusId);
                parameters.Add("@InvoiceId", entity.InvoiceId);
                parameters.Add("@Issue", entity.Issue);
                parameters.Add("@Comments", entity.Comments);
                parameters.Add("@InvDate", entity.InvDate);
                parameters.Add("@InWarranty", entity.InWarranty);
                var result = await SqlMapper.QueryFirstOrDefaultAsync<DTO_Ticket>(_connectionFactory.GetConnection(), "Usp_Ticket_Update",
                    parameters, commandType: CommandType.StoredProcedure);

                string body = "The Ticket Id: "+ entity.TicketId+" has been updated. for Product ID : " + entity.ProductId;
                SendEmail(entity.UserId, body);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region " Email "
        public async Task<DTO_Ticket> Delete(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TicketId", id);
                return await SqlMapper.QueryFirstOrDefaultAsync<DTO_Ticket>(_connectionFactory.GetConnection(), "USP_Delete_Ticket", parameters, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SendEmail(int id,string body)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserId", id);
            var emailid =  SqlMapper.ExecuteScalar(_connectionFactory.GetConnection(), "Usp_User_email", parameters, commandType: CommandType.StoredProcedure);
            
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                UseDefaultCredentials=false,
                Port = 587,
                Credentials = new NetworkCredential("snehaldgarad@gmail.com", "Enrique7@"),
                EnableSsl = true,
            };

            smtpClient.Send("snehaldgarad@gmail.com", emailid.ToString(), "Mail From Customer Help desk", body);
        }
        #endregion

    }
}
