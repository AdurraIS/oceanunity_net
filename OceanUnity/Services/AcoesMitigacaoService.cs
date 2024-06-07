
using Microsoft.EntityFrameworkCore;
using oceanunity.data;
using oceanunity.dto;
using oceanunity.entities;
using oceanunity.Services;

namespace oceanunity.services
{
    public class AcoesMitigacaoService : IAcoesMitigacaoService // Consider adding an interface
    {
        private readonly AcoesMitigacaoContext _context;

        public AcoesMitigacaoService(AcoesMitigacaoContext context)
        {
            _context = context;
        }

        #region CRUD

        public async Task<IResult> CreateAcaoAsync(AcoesMitigacaoDTO acoesMitigacao)
        {
            if (acoesMitigacao == null)
            {
                return TypedResults.BadRequest("Dados da ação inválidos.");
            }
                AcoesMitigacao acao = new AcoesMitigacao(acoesMitigacao.id_acao, acoesMitigacao.nome_acao
                , acoesMitigacao.desc_acao, acoesMitigacao.data_inicio_acao, acoesMitigacao.data_fim_acao
                , acoesMitigacao.status_acao, acoesMitigacao.id_empresa);
                _context.acoes.Add(acao);
                await _context.SaveChangesAsync();
                return TypedResults.Created($"/sensors/{acoesMitigacao.id_acao}", acoesMitigacao);
        }

        public async Task<IResult> GetAcaoByIdAsync(long acaoId)
        {
            if (acaoId <= 0)
            {
                return TypedResults.BadRequest("ID da ação inválido.");
            }

            var acao = await _context.acoes.FindAsync(acaoId);

            if (acao == null)
            {
                return TypedResults.NotFound();
            }

            return TypedResults.Ok(acao);
        }

        public async Task<IResult> UpdateAcaoAsync(AcoesMitigacaoDTO acoesMitigacao)
        {
            if (acoesMitigacao == null || acoesMitigacao.id_acao
             <= 0)
            {
                return TypedResults.BadRequest("Dados da ação inválidos.");
            }

            var existingAcao = await _context.acoes.FindAsync(acoesMitigacao.id_acao);

            if (existingAcao == null)
            {
                return TypedResults.NotFound();
            }

            existingAcao.nome_acao = acoesMitigacao.nome_acao;
            existingAcao.desc_acao = acoesMitigacao.desc_acao;
            existingAcao.data_inicio_acao = acoesMitigacao.data_inicio_acao;
            existingAcao.data_fim_acao = acoesMitigacao.data_fim_acao;
                await _context.SaveChangesAsync();
                return TypedResults.Ok(acoesMitigacao);

        }

        public async Task<IResult> DeleteAcaoAsync(long acaoId)
        {
            if (acaoId <= 0)
            {
                return TypedResults.BadRequest("ID da ação inválido.");
            }

            var acao = await _context.acoes.FindAsync(acaoId);

            if (acao == null)
            {
                return TypedResults.NotFound();
            }

            _context.acoes.Remove(acao);
                await _context.SaveChangesAsync();
                return TypedResults.Ok();
        }

        #endregion

        #region findAllPaginadoByEmpresa

        public async Task<IResult> FindAllPaginadoAsyncByEmpresa(int pagina, int tamanhoPagina, long empresaId)
        {
            if (pagina <= 0 || tamanhoPagina <= 0)
            {
                return TypedResults.BadRequest("Parâmetros de paginação inválidos.");
            }

            int skip = (pagina - 1) * tamanhoPagina;

            var acoes = await _context.acoes
                .Where(a=> a.id_empresa == empresaId)
                .Skip(skip)
                .Take(tamanhoPagina)
                .ToListAsync();

            return TypedResults.Ok(acoes);
        }
        #endregion
    }
}
