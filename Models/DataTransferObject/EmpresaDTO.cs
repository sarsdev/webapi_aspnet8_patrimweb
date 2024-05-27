using System.Text.Json.Serialization;

namespace webapi_aspnet8_patrimweb.Models.DataTransferObject;
public class EmpresaDTO
{
    [JsonPropertyName("sequencial")]
    public long Sequencial { get; set; }

    [JsonPropertyName("nomefantasia")]
    public string NomeFantasia { get; set; }
    
    [JsonPropertyName("links")]
    public IEnumerable<HateoasDetalhesDTO>? Links { get; set; }

    [JsonConstructor]
    #pragma warning disable CS8618
    public EmpresaDTO() {}
    #pragma warning restore CS8618

    public EmpresaDTO(long sequencial, string nomeFantasia)
    {
        Sequencial = sequencial;
        NomeFantasia = nomeFantasia;
        Links = [
            new HateoasDetalhesDTO("GET", "Self", $"api/empresa/{Sequencial}")
        ];
    }
}