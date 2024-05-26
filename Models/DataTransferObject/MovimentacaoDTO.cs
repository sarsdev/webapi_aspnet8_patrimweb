using System.Text.Json.Serialization;
using webapi_aspnet8_patrimweb.Models.Entidade;
using webapi_aspnet8_patrimweb.Models.Enumerable;
namespace webapi_aspnet8_patrimweb.Models.DataTransferObject;
public class MovimentacaoDTO
{
    [JsonPropertyName("sequencial")]
    public long Sequencial { get; set; }

    [JsonPropertyName("data")]
    public required DateOnly Data { get; set; }

    [JsonPropertyName("tipo")]
    public required TipoDeMovimentacao Tipo { get; set; }

    [JsonPropertyName("produto")]
    public required Produto Produto { get; set; }

    [JsonPropertyName("total")]
    public required bool IndicadorTotal { get; set; }

    [JsonPropertyName("tipovalor")]
    public required TipoDeValorMovimentacao TipoDeValor { get; set; }

    [JsonPropertyName("valor")]
    public required float Valor { get; set; }
}