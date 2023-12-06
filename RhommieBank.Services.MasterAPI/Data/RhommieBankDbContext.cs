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
        public DbSet<TransactionNote> TransactionNotes { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }

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

            mb.Entity<TransactionNote>()
            .HasOne(tn => tn.TransferFrom)
            .WithMany(r => r.TransactionsFrom)
            .HasForeignKey(tn => tn.rekeningTransferFrom)
            .OnDelete(DeleteBehavior.Restrict); 

            mb.Entity<TransactionNote>()
            .HasOne(tn => tn.TransferTo)
            .WithMany(r => r.TransactionsTo)
            .HasForeignKey(tn => tn.rekeningTransferTo)
            .OnDelete(DeleteBehavior.Restrict);



            mb.Entity<Bank>()
            .HasOne(b => b.Currency)
            .WithMany(c => c.Banks)
            .HasForeignKey(b => b.CurrencyCode)
            .OnDelete(DeleteBehavior.Restrict);

            mb.ApplyConfiguration(new PersonConfiguration());


            base.OnModelCreating(mb);


            mb.Entity<Currency>().HasData(new Currency()
            {
                CurrencyCode = "IDR",
                CurrencyName = "Indonesian Rupiah",
                Country = "Indonesia"
            });

            mb.Entity<Currency>().HasData(new Currency()
            {
                CurrencyCode = "AUD",
                CurrencyName = "Australian Dollar",
                Country = "Australia"
            });

            mb.Entity<Currency>().HasData(new Currency()
            {
                CurrencyCode = "GBP",
                CurrencyName = "Sterling",
                Country = "United Kingdom"
            });

            mb.Entity<Currency>().HasData(new Currency()
            {
                CurrencyCode = "JPY",
                CurrencyName = "Japan Yen",
                Country = "Japan"
            });

            mb.Entity<Currency>().HasData(new Currency()
            {
                CurrencyCode = "MYR",
                CurrencyName = "Malaysian Ringgit",
                Country = "Malaysia"
            });

            mb.Entity<Currency>().HasData(new Currency()
            {
                CurrencyCode = "USD",
                CurrencyName = "US Dollar",
                Country = "United States"
            });


            mb.Entity<TransactionType>().HasData(new TransactionType()
            {
                id = 1,
                TransactionTypeName = "In-House",
                Charges = 0
            });

            mb.Entity<TransactionType>().HasData(new TransactionType()
            {
                id = 2,
                TransactionTypeName = "Domestic",
                Charges = 7000
            });

            mb.Entity<TransactionType>().HasData(new TransactionType()
            {
                id = 3,
                TransactionTypeName = "International",
                Charges = 45000
            });

            mb.Entity<User>().HasData(new User()
            {
                username = "rhommie",
                password = "123",
                email = "rhommie.1997@gmail.com",
                imagePath = null,
                isAdmin = true,
                nickname = "Rhommie"
            });

            mb.Entity<Person>().HasData(new Person()
            {
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

            mb.Entity<Bank>().HasData(new Bank()
            {
                BankCode = "014",
                BankName = "BCA",
                CurrencyCode = "IDR"
            });

            mb.Entity<Bank>().HasData(new Bank()
            {
                BankCode = "002",
                BankName = "BRI",
                CurrencyCode = "IDR"
            });

            mb.Entity<Bank>().HasData(new Bank()
            {
                BankCode = "008",
                BankName = "Bank Mandiri",
                CurrencyCode = "IDR"
            });

            mb.Entity<Bank>().HasData(new Bank()
            {
                BankCode = "009",
                BankName = "BNI",
                CurrencyCode = "IDR"
            });
        }

    }
}
