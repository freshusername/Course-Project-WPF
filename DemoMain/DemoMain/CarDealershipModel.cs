namespace DemoMain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CarDealershipModel : DbContext
    {
        public CarDealershipModel()
            : base("name=CarDealership")
        {
        }

        public virtual DbSet<admins> admins { get; set; }
        public virtual DbSet<bans> bans { get; set; }
        public virtual DbSet<CarDiscounts> CarDiscounts { get; set; }
        public virtual DbSet<CarManufs> CarManufs { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<CarsComments> CarsComments { get; set; }
        public virtual DbSet<Engines> Engines { get; set; }
        public virtual DbSet<Transmissions> Transmissions { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarManufs>()
                .Property(e => e.manuf)
                .IsUnicode(false);

            modelBuilder.Entity<CarManufs>()
                .HasMany(e => e.Cars)
                .WithOptional(e => e.CarManufs)
                .HasForeignKey(e => e.manuf_id);

            modelBuilder.Entity<Cars>()
                .Property(e => e.model)
                .IsUnicode(false);

            modelBuilder.Entity<Cars>()
                .Property(e => e.color)
                .IsUnicode(false);

            modelBuilder.Entity<Cars>()
                .HasMany(e => e.CarDiscounts)
                .WithOptional(e => e.Cars)
                .HasForeignKey(e => e.car_id);

            modelBuilder.Entity<Cars>()
                .HasMany(e => e.CarsComments)
                .WithOptional(e => e.Cars)
                .HasForeignKey(e => e.car_id);

            modelBuilder.Entity<CarsComments>()
                .Property(e => e.comment)
                .IsUnicode(false);

            modelBuilder.Entity<Engines>()
                .Property(e => e.engine_name)
                .IsUnicode(false);

            modelBuilder.Entity<Engines>()
                .Property(e => e.fuel_type)
                .IsUnicode(false);

            modelBuilder.Entity<Engines>()
                .HasMany(e => e.Cars)
                .WithOptional(e => e.Engines)
                .HasForeignKey(e => e.engine_id);

            modelBuilder.Entity<Transmissions>()
                .Property(e => e.transmission_name)
                .IsUnicode(false);

            modelBuilder.Entity<Transmissions>()
                .HasMany(e => e.Cars)
                .WithOptional(e => e.Transmissions)
                .HasForeignKey(e => e.transmission_id);

            modelBuilder.Entity<Users>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.first_name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.last_name)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.avatar)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.CarsComments)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.user_id);
        }
    }
}
