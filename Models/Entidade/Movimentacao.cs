using webapi_aspnet8_patrimweb.Models.DataTransferObject;
using webapi_aspnet8_patrimweb.Models.Enumerable;
namespace webapi_aspnet8_patrimweb.Models.Entidade;
public class Movimentacao
{
    public long Sequencial { get; set; }
    public DateOnly DataDaMovimentacao { get; set; }
    public TipoDeMovimentacao Tipo { get; set; }
    public long SequencialDoProduto { get; set; }
    public float ValorMovimentado { get; set; }
    public float ValorDoImpostoMovimentado { get; set; }
    public bool Estounada { get; set; }
    public bool IndicadorTotal { get; set; }
    public TipoDeValorMovimentacao TipoDeValor { get; set; }
    public float ValorOperacao { get; set; }

    public Movimentacao() { }
    public Movimentacao(MovimentacaoDTO dtoMovimentacao)
    {
        Sequencial = dtoMovimentacao.Sequencial;
        DataDaMovimentacao = dtoMovimentacao.Data;
        Tipo = dtoMovimentacao.Tipo;
        SequencialDoProduto = dtoMovimentacao.Produto.Sequencial;
        ValorMovimentado = RetornaValorMovimentado(dtoMovimentacao);
        ValorDoImpostoMovimentado = RetornaValorDoImpostoMovimentado(dtoMovimentacao);
        Estounada = false;
        IndicadorTotal = dtoMovimentacao.IndicadorTotal;
        TipoDeValor = dtoMovimentacao.TipoDeValor;
        ValorOperacao = dtoMovimentacao.Valor;
    }
    private static float RetornaValorMovimentado(MovimentacaoDTO dtoMovimentacao)
    {
        if(dtoMovimentacao.IndicadorTotal) return dtoMovimentacao.Produto.ValorDeCompra;
        return dtoMovimentacao.TipoDeValor 
        switch
        {
            TipoDeValorMovimentacao.VALOR => dtoMovimentacao.Valor,
            TipoDeValorMovimentacao.QUANTIDADE => dtoMovimentacao.Produto.ValorDeCompra * (dtoMovimentacao.Produto.Quantidade / dtoMovimentacao.Valor),
            TipoDeValorMovimentacao.PERCENTUAL => dtoMovimentacao.Produto.ValorDeCompra * dtoMovimentacao.Valor,
            _ => 0.0f,
        };
    }
    private static float RetornaValorDoImpostoMovimentado(MovimentacaoDTO dtoMovimentacao)
    {
        if(dtoMovimentacao.IndicadorTotal) return dtoMovimentacao.Produto.ValorDoImposto;
        return dtoMovimentacao.TipoDeValor 
        switch
        {
            TipoDeValorMovimentacao.VALOR => dtoMovimentacao.Valor,
            TipoDeValorMovimentacao.QUANTIDADE => dtoMovimentacao.Produto.ValorDoImposto * (dtoMovimentacao.Produto.Quantidade / dtoMovimentacao.Valor),
            TipoDeValorMovimentacao.PERCENTUAL => dtoMovimentacao.Produto.ValorDoImposto * dtoMovimentacao.Valor,
            _ => 0.0f,
        };
    }
}