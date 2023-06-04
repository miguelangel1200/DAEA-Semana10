using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCCodeFirst.Models
{
    public class DemoContext : DbContext
    {
        public DemoContext() : base("name = MyContextDB") { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Detail> Details { get; set; }
    }
}