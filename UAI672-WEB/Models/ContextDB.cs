using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;

namespace UAI672_WEB.Models
{
    public class ContextDB
    {
       /* public ContextDB() : base("MyConnectionString")
        {
        }

        public DbSet<BusDetail> Persons { get; set; }
        public DbSet<Addresses> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Addresses)
                .WithMany(a => a.Persons)
                .Map(m =>
                {
                    m.ToTable("PersonAddress");
                    m.MapLeftKey("PersonId");
                    m.MapRightKey("AddressId");
                });
        }*/
    }
}