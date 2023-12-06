using Microsoft.EntityFrameworkCore;
using RhommieBank.Services.MasterAPI.Models;
using RhommieBank.Services.MasterAPI.Configuration;
using RhommieBank.Services.MasterAPI.Models;
using System.Reflection.Emit;

namespace RhommieBank.Services.MasterAPI.Data
{
    public class RhommieBankDbContext : DbContext
    {
        public RhommieBankDbContext(DbContextOptions<RhommieBankDbContext> op) : base(op)
        {

        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Rekening> Rekenings { get; set; }
        public DbSet<User> UserLogins { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //// Primary Key
            //modelBuilder.Entity<Person>().HasKey(p => p.PersonId);

            //// Nullable column
            //modelBuilder.Entity<Person>().Property(p => p.FirstName).IsRequired(false);

            //// Max length for varchar column
            //modelBuilder.Entity<Person>().Property(p => p.FirstName).HasMaxLength(50);

            //// Identity (auto-increment) for a column
            //modelBuilder.Entity<Person>().Property(p => p.PersonId).ValueGeneratedOnAdd();

            //// Unique constraint for a column
            //modelBuilder.Entity<Rekening>().HasIndex(r => r.NomorRekening).IsUnique();

            //// Default value for a column
            //modelBuilder.Entity<Person>().Property(p => p.Age).HasDefaultValue(18);

            // Gunakan konfigurasi untuk entitas Person
            mb.ApplyConfiguration(new PersonConfiguration());


            base.OnModelCreating(mb);

            mb.Entity<User>().HasData(new User() {
                username = "rhommie",
                password = "123",
                email = "rhommie.1997@gmail.com",
                imagePath = null,
                isAdmin = true,
                nickname = "Rhommie"
            });

            mb.Entity<Person>().HasData(new Person() {
                id = 1,
                name = "Erling Haaland",
                age = 22,
                created_by = "System",
                created_dt = DateTime.Now,
            });

            mb.Entity<Person>().HasData(new Person()
            {
                id = 2,
                name = "Kylian Mbappe",
                age = 24,
                created_by = "System",
                created_dt = DateTime.Now,
            });

            mb.Entity<Bank>().HasData(new Bank() {
                BankCode = "014",
                BankName = "BCA"
            });

            mb.Entity<Bank>().HasData(new Bank()
            {
                BankCode = "002",
                BankName = "BRI"
            });

            mb.Entity<Bank>().HasData(new Bank()
            {
                BankCode = "008",
                BankName = "Bank Mandiri"
            });

            mb.Entity<Bank>().HasData(new Bank()
            {
                BankCode = "009",
                BankName = "BNI"
            });
        }

    }
}
