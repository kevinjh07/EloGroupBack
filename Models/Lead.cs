using System;

namespace EloGroupBack.Models
{
    public class Lead
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerEmail { get; set; }

        public int StatusId { get; set; }
    }
}