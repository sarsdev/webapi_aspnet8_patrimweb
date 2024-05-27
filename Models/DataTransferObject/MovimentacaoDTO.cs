using System.Text.Json.Serialization;
using webapi_aspnet8_patrimweb.Models.Entidade;
using webapi_aspnet8_patrimweb.Models.Enumerable;
namespace webapi_aspnet8_patrimweb.Models.DataTransferObject;
public class MovimentacaoDTO
{
    [JsonPropertyName("sequencial")]
    public long Sequencial { get; set; }

    [JsonPropertyName("data")]
    public DateOnly Data { get; set; }

    [JsonPropertyName("tipo")]
    public TipoDeMovimentacao Tipo { get; set; }

    [JsonPropertyName("produto")]
    public ProdutoDTO Produto { get; set; }

    [JsonPropertyName("total")]
    public bool IndicadorTotal { get; set; }

    [JsonPropertyName("tipovalor")]
    public TipoDeValorMovimentacao TipoDeValor { get; set; }

    [JsonPropertyName("valor")]
    public float Valor { get; set; }

    [JsonPropertyName("links")]
    public IEnumerable<HateoasDetalhesDTO>? Links { get; set; }

    [JsonConstructor]
    #pragma warning disable CS8618
    public MovimentacaoDTO() {}
    #pragma warning restore CS8618

    public MovimentacaoDTO(Movimentacao movimentacao, ProdutoDTO produto)
    {
        Sequencial = movimentacao.Sequencial;
        Data = movimentacao.DataDaMovimentacao;
        IndicadorTotal = movimentacao.IndicadorTotal;
        Produto = produto;
        Tipo = movimentacao.Tipo;
        TipoDeValor = movimentacao.TipoDeValor;
        Valor = movimentacao.ValorOperacao;
        Links = [
            new HateoasDetalhesDTO("GET", "Self", $"api/movimentacao/{Sequencial}"),
            new HateoasDetalhesDTO("GET", "Obter Descrição do Tipo", $"api/movimentacao/tipos/{(int)Tipo}"),
            new HateoasDetalhesDTO("GET", "Obter Descrição do Tipo de Valor", $"api/movimentacao/tiposdevalor/{(int)TipoDeValor}"),
            new HateoasDetalhesDTO("DELETE", "Self", $"api/movimentacao/{Sequencial}")
        ];
    }
}