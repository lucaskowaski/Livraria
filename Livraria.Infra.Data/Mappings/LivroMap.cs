using Livraria.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livraria.Infra.Data.Mappings
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.Property(c => c.Id)
               .HasColumnName("Id");
            builder.Property(c => c.Titulo)
               .HasColumnType("varchar(100)")
               .HasMaxLength(100)
               .IsRequired();
            builder.Property(c => c.Autor)
              .HasColumnType("varchar(100)")
              .HasMaxLength(100)
              .IsRequired();
            builder.Property(c => c.Idioma)
              .HasColumnType("varchar(100)")
              .HasMaxLength(100)
              .IsRequired();
            builder.Property(c => c.AnoPublicacao)
             .IsRequired();
            builder.Property(c => c.NumeroPaginas)
             .IsRequired();
        }
    }
}
