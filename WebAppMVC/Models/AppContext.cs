using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppMVC.Models
{
    public class AppContext : DbContext
    {
        public AppContext() : base("DefaultConnection")
        {
        }

        public DbSet<User> Users { get; set; }

    }
}