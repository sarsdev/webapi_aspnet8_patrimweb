using System.Text.Json.Serialization;

namespace webapi_aspnet8_patrimweb.Models.DataTransferObject;
public class RespostaHttpFalhaDTO(int codigoHttp, string titulo, string detalhes)
{
    [JsonPropertyName("codigohttp")]
    public int CodigoHTTP { get; set; } = codigoHttp;

    [JsonPropertyName("titulo")]
    public string Titulo { get; set; } = titulo;

    [JsonPropertyName("detalhes")]
    public string Detalhes { get; set; } = detalhes;
}