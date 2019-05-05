namespace DemoMain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=CarsModel_EF")
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<CarManufacturer> CarManufacturer { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Offers> Offers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>()
                .Property(e => e.Login)
                .IsFixedLength();

            modelBuilder.Entity<Accounts>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Accounts>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<CarManufacturer>()
                .HasMany(e => e.Cars)
                .WithRequired(e => e.CarManufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Offers>()
                .Property(e => e.Owner)
                .IsFixedLength();

            modelBuilder.Entity<Offers>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Offers>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength();
        }
    }
}
