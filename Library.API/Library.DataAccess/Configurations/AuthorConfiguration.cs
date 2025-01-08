using Library.DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<AuthorEntity>
    {
        public void Configure(EntityTypeBuilder<AuthorEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(a => a.Name).IsRequired();
            builder.Property(a => a.Surname).IsRequired();
            builder.Property(a => a.Birthday).IsRequired(); ;
            builder.Property(a => a.Country).IsRequired();
        }
    }
}
