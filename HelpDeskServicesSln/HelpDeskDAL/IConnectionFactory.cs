using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HelpDeskDAL
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
