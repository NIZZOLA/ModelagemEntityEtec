using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelagemBd;

namespace PortalAnuncios.Data.EntityConfig
{
    public class CandidaturaConfiguration : IEntityTypeConfiguration<Candidatura>
    {
        public void Configure(EntityTypeBuilder<Candidatura> builder)
        {
            builder.ToTable("Candidaturas");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Status)
                .IsRequired();

            builder.HasOne(c => c.Anuncio)
                .WithMany(a => a.Candidaturas)
                .HasForeignKey(c => c.AnuncioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Candidato)
                .WithMany()
                .HasForeignKey(c => c.CandidatoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Historico)
                .WithOne(h => h.Candidatura)
                .HasForeignKey(h => h.CandidaturaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
