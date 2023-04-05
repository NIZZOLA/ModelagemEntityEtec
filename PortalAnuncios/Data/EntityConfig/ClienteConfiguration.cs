using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelagemBd;

namespace PortalAnuncios.Data.EntityConfig
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Cpf).IsRequired().HasMaxLength(18);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
        }
    }
}
