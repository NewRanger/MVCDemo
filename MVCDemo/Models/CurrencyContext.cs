namespace MVCDemo.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CurrencyContext : DbContext
    {
        public CurrencyContext()
            : base("name=CurrencyContext")
        {
        }

        public virtual DbSet<Currency> Currency { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>()
                .Property(e => e.code)
                .IsUnicode(false);

            modelBuilder.Entity<Currency>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Currency>()
                .Property(e => e.name_lat)
                .IsUnicode(false);
        }
    }
}
