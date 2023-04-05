using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelagemBd;

namespace PortalAnuncios.Data.EntityConfig
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("ClientesEnderecos");
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Rua)
                .IsRequired().HasMaxLength(40);
            builder.Property(e => e.Numero)
                .IsRequired().HasMaxLength(10);
            builder.Property(e => e.Bairro)
                .IsRequired().HasMaxLength(40);
            builder.Property(e => e.Estado)
                .IsRequired().HasMaxLength(2);
            builder.Property(e => e.Cep)
                .IsRequired().HasMaxLength(10);

            builder.HasOne(a => a.Cliente)
                .WithMany(a => a.Enderecos)
                .HasForeignKey(a => a.ClienteId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
