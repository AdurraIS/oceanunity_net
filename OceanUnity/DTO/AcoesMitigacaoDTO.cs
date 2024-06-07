namespace oceanunity.dto;

[Serializable]
public record AcoesMitigacaoDTO(long id_acao, string nome_acao, string desc_acao, DateTime data_inicio_acao, 
        DateTime data_fim_acao, string status_acao, long id_empresa);