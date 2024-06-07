
using oceanunity.dto;
using oceanunity.entities;
using oceanunity.Services;

namespace oceanunity.Endpoints
{
    public static class AcoesMitigacaoEndpoints
    {
        public static void RegisterAcaoEndpoints(this WebApplication app)
        {
            var acoes = app.MapGroup("/api/v1/acoes");

            #region CRUD Operations
        

            acoes.MapPost("/", async (IAcoesMitigacaoService acoesMitigacaoService, AcoesMitigacaoDTO acao) => await acoesMitigacaoService.CreateAcaoAsync(acao))
                .WithOpenApi()
                .WithDescription("Cria uma nova ação.")
                .Accepts<AcoesMitigacaoDTO>("application/json")
                .Produces<AcoesMitigacaoDTO>(StatusCodes.Status201Created);

            acoes.MapGet("/", async (IAcoesMitigacaoService acoesMitigacaoService, long empresaId, int pagina = 1, int tamanhoPagina = 10) => await acoesMitigacaoService.FindAllPaginadoAsyncByEmpresa(pagina, tamanhoPagina, empresaId))
                .WithOpenApi()
                .WithDescription("Recupera todos as ações de uma empresa paginado.")
                .Produces<IEnumerable<AcoesMitigacaoDTO>>(StatusCodes.Status200OK);

            acoes.MapGet("/{acaoId}", async (IAcoesMitigacaoService acoesMitigacaoService, long acaoId) => await acoesMitigacaoService.GetAcaoByIdAsync(acaoId))
                .WithOpenApi()
                .WithDescription("Recupera uma ação específica pelo ID.")
                .Produces<AcoesMitigacaoDTO>(StatusCodes.Status200OK)
                .Produces(StatusCodes.Status404NotFound);

            acoes.MapPut("/", async (IAcoesMitigacaoService acoesMitigacaoService, AcoesMitigacaoDTO acao) =>
            {
                await acoesMitigacaoService.UpdateAcaoAsync(acao);
            })
                .WithOpenApi()
                .WithDescription("Atualiza uma ação existente.")
                .Accepts<AcoesMitigacaoDTO>("application/json")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound);

            acoes.MapDelete("/{acaoId}", async (IAcoesMitigacaoService acoesMitigacaoService, long acaoId) => await acoesMitigacaoService.DeleteAcaoAsync(acaoId))
                .WithOpenApi()
                .WithDescription("Exclui uma ação existente.")
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status404NotFound);

            #endregion
        }
    }
}
