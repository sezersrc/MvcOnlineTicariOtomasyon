using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Context: DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<InvoicesDetail> InvoicesDetails { get; set; }
        public DbSet<Invoices> Invoicess { get; set; }
        public DbSet<Outgoing> Outgoings { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sales_Transaction> Sales_Transactions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProDetail> ProDetails { get; set; }
        public DbSet<ToDolist> ToDolists { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoTracking> CargoTrackings { get; set; }
        public DbSet<Message> Messages { get; set; }
        
    }
}