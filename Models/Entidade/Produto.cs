namespace webapi_aspnet8_patrimweb.Models.Entidade;
public class Produto
{
    public required long Sequencial { get; set; }
    public required int Numero { get; set; }
    public string? Descricao { get; set; }
    public required int NroComponente { get; set; }
    public required long SequencialDaEmpresa { get; set; }
    public required int Quantidade { get; set; }
    public required float ValorDeCompra { get; set; }
    public required float ValorDoImposto { get; set; }
}