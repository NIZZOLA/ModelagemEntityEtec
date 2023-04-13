using Microsoft.EntityFrameworkCore;
using PortalAnuncios.Data;

namespace PortalAnuncios.Endpoints;

public static class AnunciosEndpoints
{
    public static void MapEndpoints(this WebApplication app)
    {
        app.MapGet("/api/anuncios", async (PortalAnunciosContext context) =>
        {
            return await context.Cliente.Include(a => a.Enderecos).ToListAsync();
        });
    }
}
