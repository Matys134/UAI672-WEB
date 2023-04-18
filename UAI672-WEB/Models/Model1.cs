using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace UAI672_WEB.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1ConnectionString")
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Details> Details { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>()
                .HasMany(e => e.Details)
                .WithOptional(e => e.Addresses)
                .HasForeignKey(e => e.Address);
        }
    }
}
