using SQLite.CodeFirst;

namespace Shasta_Water_Management
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<CustEquip> CustEquips { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<Model1>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);

            modelBuilder.Entity<CustEquip>()
                .Property(e => e.SerialNum)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CellPhoneNum)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.HomePhoneNum)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Zip)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Notes)
                .IsUnicode(false);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.ModelNum)
                .IsUnicode(false);

            modelBuilder.Entity<Equipment>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.StartLoc)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.EndLoc)
                .IsUnicode(false);

            modelBuilder.Entity<Service>()
                .Property(e => e.Diagnostics)
                .IsUnicode(false);
        }
    }
}
