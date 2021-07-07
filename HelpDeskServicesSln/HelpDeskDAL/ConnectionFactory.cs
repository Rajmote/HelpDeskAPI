//using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace HelpDeskDAL
{
    public class ConnectionFactory:IConnectionFactory
    {             
        public IDbConnection GetConnection()
        {
            // return new SqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("DBConnectionString").Value);
            return new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        }

    }
}
