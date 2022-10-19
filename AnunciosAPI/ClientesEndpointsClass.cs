using Microsoft.EntityFrameworkCore;
using AnunciosAPI.Data;
using ModelagemBd;
namespace AnunciosAPI;

public static class ClientesEndpointsClass
{
    public static void MapClienteEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Cliente", async (AnunciosAPIContext db) =>
        {
            return await db.Cliente.ToListAsync();
        })
        .WithName("GetAllClientes");

        routes.MapGet("/api/Cliente/{id}", async (int Id, AnunciosAPIContext db) =>
        {
            return await db.Cliente.FindAsync(Id)
                is Cliente model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetClienteById");

        routes.MapPut("/api/Cliente/{id}", async (int Id, Cliente cliente, AnunciosAPIContext db) =>
        {
            var foundModel = await db.Cliente.FindAsync(Id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }
            //update model properties here
            foundModel.Nome = cliente.Nome;
            foundModel.Nascimento = cliente.Nascimento;
            foundModel.Email = cliente.Email;

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateCliente");

        routes.MapPost("/api/Cliente/", async (Cliente cliente, AnunciosAPIContext db) =>
        {
            db.Cliente.Add(cliente);
            await db.SaveChangesAsync();
            return Results.Created($"/Clientes/{cliente.Id}", cliente);
        })
        .WithName("CreateCliente");

        routes.MapDelete("/api/Cliente/{id}", async (int Id, AnunciosAPIContext db) =>
        {
            if (await db.Cliente.FindAsync(Id) is Cliente cliente)
            {
                db.Cliente.Remove(cliente);
                await db.SaveChangesAsync();
                return Results.Ok(cliente);
            }

            return Results.NotFound();
        })
        .WithName("DeleteCliente");
    }
}
