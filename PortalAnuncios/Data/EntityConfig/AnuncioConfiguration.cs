using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelagemBd;

namespace PortalAnuncios.Data.EntityConfig
{
    public class AnuncioConfiguration : IEntityTypeConfiguration<Anuncio>
    {
        public void Configure(EntityTypeBuilder<Anuncio> builder)
        {
            builder.ToTable("Anuncios");
            builder.HasKey(x => x.Id);

            builder.HasOne(a => a.Anunciante)
                .WithMany(a => a.Anuncios)
                .HasForeignKey(a => a.AnuncianteId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(1000);
        }
    }
}
