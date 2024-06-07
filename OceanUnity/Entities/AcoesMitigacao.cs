using System.ComponentModel.DataAnnotations;

namespace oceanunity.entities;
public class AcoesMitigacao
{
    public long id_acao { get; set; }
    public string nome_acao { get; set; }
    public string desc_acao { get; set; }
    public DateTime data_inicio_acao { get; set; }
    public DateTime data_fim_acao { get; set; }
    public string status_acao { get; set; }
    public long id_empresa {get;set;}

    public AcoesMitigacao(long id_acao, string nome_acao, string desc_acao, DateTime data_inicio_acao, 
        DateTime data_fim_acao, string status_acao, long id_empresa)
    {
        this.id_acao = id_acao;
        this.nome_acao = nome_acao;
        this.desc_acao = desc_acao;
        this.data_inicio_acao = data_inicio_acao;
        this.data_fim_acao = data_fim_acao;
        this.status_acao = status_acao;
        this.id_empresa = id_empresa;
    }
}
