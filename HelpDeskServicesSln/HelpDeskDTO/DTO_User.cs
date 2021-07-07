using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDeskDTO
{
    public class DTO_User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string EmailId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Pincode { get; set; }
        public int CityId { get; set; }
        public int RoleId { get; set; }
        public int StatusId { get; set; }
        public string AdharId { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        
    }
}
