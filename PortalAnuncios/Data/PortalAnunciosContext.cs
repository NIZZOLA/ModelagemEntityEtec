using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelagemBd;

namespace PortalAnuncios.Data
{
    public class PortalAnunciosContext : DbContext
    {
        public PortalAnunciosContext(DbContextOptions<PortalAnunciosContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public DbSet<ModelagemBd.Anuncio> Anuncio { get; set; } = default!;

        public DbSet<ModelagemBd.Cliente>? Cliente { get; set; }

        public DbSet<ModelagemBd.Endereco>? Endereco { get; set; }

        public DbSet<ModelagemBd.Candidatura>? Candidatura { get; set; }

        public DbSet<ModelagemBd.CandidaturaHistorico>? CandidaturaHistorico { get; set; }
    }
}
