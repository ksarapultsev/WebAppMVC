using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp3.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public User()
        {
            Products = new List<Product>();
        }
    }
}