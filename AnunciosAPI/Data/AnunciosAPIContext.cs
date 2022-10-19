using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelagemBd;

namespace AnunciosAPI.Data
{
    public class AnunciosAPIContext : DbContext
    {
        public AnunciosAPIContext (DbContextOptions<AnunciosAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ModelagemBd.Cliente> Cliente { get; set; } = default!;
    }
}
