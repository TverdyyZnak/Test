using Library.DataAccess.Entites;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.DataAccess.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.ISBN).HasMaxLength(13).IsRequired();
            builder.Property(b =>b.Image).HasMaxLength(Book.IMAGE_MAX_SIZE);

        }
    }
}
