using System.Text.Json.Serialization;
using webapi_aspnet8_patrimweb.Models.Entidade;

namespace webapi_aspnet8_patrimweb.Models.DataTransferObject;
public class ProdutoDTO
{
    [JsonPropertyName("sequencial")]
    public long Sequencial { get; set; }

    [JsonPropertyName("numero")]
    public int Numero { get; set; }

    [JsonPropertyName("descricao")]
    public string Descricao { get; set; }

    [JsonPropertyName("nrocomponente")]
    public int NroComponente { get; set; }

    [JsonPropertyName("empresa")]
    public EmpresaDTO Empresa { get; set; }

    [JsonPropertyName("quantidade")]
    public int Quantidade { get; set; }

    [JsonPropertyName("valorcompra")]
    public float ValorDeCompra { get; set; }

    [JsonPropertyName("valorimposto")]
    public float ValorDoImposto { get; set; }
    
    [JsonPropertyName("links")]
    public IEnumerable<HateoasDetalhesDTO>? Links { get; set; }

    [JsonConstructor]
    #pragma warning disable CS8618
    public ProdutoDTO() {}
    #pragma warning restore CS8618

    public ProdutoDTO(Produto produto, EmpresaDTO empresa)
    {
        Sequencial = produto.Sequencial;
        Numero = produto.Numero;
        Descricao = produto.Descricao??string.Empty;
        NroComponente = produto.NroComponente;
        Empresa = empresa;
        Quantidade = produto.Quantidade;
        ValorDeCompra = produto.ValorDeCompra;
        ValorDoImposto = produto.ValorDoImposto;
        Links = [
            new HateoasDetalhesDTO("GET", "Self", $"api/produto/{Sequencial}")
        ];
    }
}