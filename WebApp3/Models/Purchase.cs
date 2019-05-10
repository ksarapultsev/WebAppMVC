using System;

namespace WebApp3.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }

    }
}