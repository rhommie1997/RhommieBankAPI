using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RhommieBank.Services.PersonAPI.Models;

namespace RhommieBank.Services.PersonAPI.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {

        #region Examples

        //// Primary Key
        //builder.HasKey(p => p.PersonId);

        //// Nullable column
        //builder.Property(p => p.FirstName).IsRequired(false);

        //// Max length for varchar column
        //builder.Property(p => p.FirstName).HasMaxLength(50);

        //// Identity (auto-increment) for a column
        //builder.Property(p => p.PersonId).ValueGeneratedOnAdd();

        //// Default value for a column
        //builder.Property(p => p.Age).HasDefaultValue(18);

        #endregion

        public void Configure(EntityTypeBuilder<Person> bl)
        {
            bl.HasKey(x => x.id);
            bl.Property(x => x.name).HasMaxLength(50);
            bl.Property(x => x.id).ValueGeneratedOnAdd();
        }
    }
}
