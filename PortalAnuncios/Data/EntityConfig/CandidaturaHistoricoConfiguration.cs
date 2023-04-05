using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModelagemBd;

namespace PortalAnuncios.Data.EntityConfig
{
    public class CandidaturaHistoricoConfiguration : IEntityTypeConfiguration<CandidaturaHistorico>
    {
        public void Configure(EntityTypeBuilder<CandidaturaHistorico> builder)
        {
            builder.ToTable("CandidaturasHistoricos");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataDoStatus)
                .IsRequired();

            builder.HasOne(x => x.Candidatura)
                .WithMany(x => x.Historico)
                .HasForeignKey(x => x.CandidaturaId)
                .OnDelete(DeleteBehavior.ClientCascade);            
        }
    }
}
