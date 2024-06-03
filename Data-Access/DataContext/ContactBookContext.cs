using ContactBookApp.Domain.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBookApp.Data_Access.DataContext
{
    public class ContactBookContext : DbContext
    {
        

        //Defining your table
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Account> Accounts { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(

                "Data Source=FREE-MAN\\SQLEXPRESS02;Database= Contact-Book; Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

            //Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;
           
        }
    }
}
