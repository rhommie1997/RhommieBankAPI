using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RhommieBank.Services.AuthAPI;


namespace RhommieBank.Services.AuthAPI.Data
{
    public class RhommieBankDbContext : IdentityDbContext
    {
        public RhommieBankDbContext(DbContextOptions<RhommieBankDbContext> op) : base(op)
        {

        }


        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
        }

    }
}
