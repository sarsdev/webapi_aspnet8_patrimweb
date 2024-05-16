namespace webapi_aspnet8_patrimweb.Models;
public enum TipoDeMovimentacao
{
    AQUISICAO,
    BAIXA,
    TRANSFERENCIA
}
public enum TipoDeValorMovimentacao
{
    VALOR,
    PERCENTUAL,
    QUANTIDADE
}
public class Movimentacao
{
    public long Sequencial { get; set; }
    public required DateOnly Data { get; set; }
    public required TipoDeMovimentacao Tipo { get; set; }
    public required Produto Produto { get; set; }
    public required bool IndicadorTotal { get; set; }
    public required TipoDeValorMovimentacao TipoDeValor { get; set; }
    public required float Valor { get; set; }
}
public class Produto
{
    public required long Sequencial { get; set; }
    public required int Numero { get; set; }
    public string? Descricao { get; set; }
    public required int NroComponente { get; set; }
}