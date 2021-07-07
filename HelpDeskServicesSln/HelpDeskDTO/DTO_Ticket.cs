using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDeskDTO
{
    public class DTO_Ticket
    {
        public int TicketId { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public string ProductType { get; set; }
        public string ProductModel { get; set; }
        public string ProductId { get; set; }
        public string InvoiceId { get; set; }
        public DateTime InvDate { get; set; }
        public string InWarranty { get; set; }
        public string Issue { get; set; }
        public string Comments { get; set; } 
        
    }
}
