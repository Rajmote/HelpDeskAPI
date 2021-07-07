using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskDTO
{
    public class DTO_ChangePwd
    {
        public int userId { get; set; }
        public string oldPwd { get; set; }
        public string newPwd { get; set; } 
    }

    public class DTO_ForgotPwd 
    {
        public string mobileno { get; set; }
        public string emailId { get; set; }
    }

    
}
