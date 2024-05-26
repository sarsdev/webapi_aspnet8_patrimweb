using System.Text.Json.Serialization;
namespace webapi_aspnet8_patrimweb.Models.DataTransferObject;
public class HateoasDTO
{
    [JsonPropertyName("links")]
    public IEnumerable<HateoasDetalhesDTO> Links { get; set; } = [];
}
public class HateoasDetalhesDTO(string metodoHttp, string relacao, string acao)
{
    [JsonPropertyName("type")]
    public string MetodoHttp { get; set; } = metodoHttp;

    [JsonPropertyName("rel")]
    public string Relacao { get; set; } = relacao;

    [JsonPropertyName("href")]
    public string Acao { get; set; } = acao;
}