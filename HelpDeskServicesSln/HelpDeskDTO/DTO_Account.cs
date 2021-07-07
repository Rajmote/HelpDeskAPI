using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDeskDTO
{
    public class DTO_Account
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Pincode { get; set; }
        public int CityId { get; set; } 
        public int StatusId { get; set; }
        public string AdharId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string EmailId { get; set; } 
        public string Mobile { get; set; }
        public int RoleId { get; set; }
        public string Token { get; set; }
    }
}
