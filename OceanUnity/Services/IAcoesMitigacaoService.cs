
using oceanunity.dto;
using oceanunity.entities;

namespace oceanunity.Services
{
    public interface IAcoesMitigacaoService
    {
        Task<IResult> CreateAcaoAsync(AcoesMitigacaoDTO acoesMitigacaoDTO);
        Task<IResult> GetAcaoByIdAsync(long acoesId);
        Task<IResult> UpdateAcaoAsync(AcoesMitigacaoDTO acoesMitigacaoDTO);
        Task<IResult> DeleteAcaoAsync(long acoesId);
        Task<IResult> FindAllPaginadoAsyncByEmpresa(int pagina, int tamanhoPagina, long empresaId);
    }
}
