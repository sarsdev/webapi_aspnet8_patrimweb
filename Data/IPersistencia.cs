using webapi_aspnet8_patrimweb.Models.Entidade;
namespace webapi_aspnet8_patrimweb.Data;
public interface IPersistencia
{
    public long RetornaNovoSequencialMovimentacao();
    public Movimentacao? RetornaMovimentacao(long sequencial);
    public IEnumerable<Movimentacao> RetornaMovimentacoes();
    public IEnumerable<Movimentacao> RetornaMovimentacoes(IEnumerable<long> sequenciais);
    public IEnumerable<Movimentacao> RetornaMovimentacoes(DateOnly data);
    public IEnumerable<Movimentacao> RetornaMovimentacoes(DateOnly dataInicialDoPeriodo, DateOnly dataFinalDoPeriodo);
    public IEnumerable<Movimentacao> RetornaMovimentacoes(long sequencialDoProduto, DateOnly dataInicialDoPeriodo, DateOnly dataFinalDoPeriodo);
    public void AdicionaMovimentacao(Movimentacao movimentacao);
    public void AdicionaMovimentacoes(IEnumerable<Movimentacao> movimentacoes);
    public void RemoveMovimentacao(Movimentacao movimentacao);
    public void RemoveMovimentacoes(IEnumerable<Movimentacao> movimentacoes);
    public Produto? RetornaProduto(long sequencial);
    public IEnumerable<Produto> RetornaProdutos();
    public IEnumerable<Produto> RetornaProdutos(int numero, long sequencialDaEmpresa);
    public IEnumerable<Produto> RetornaProdutos(int numero, int nroComponente, long sequencialDaEmpresa);
    public Empresa? RetornaEmpresa(long sequencial);
    public IEnumerable<Empresa> RetornaEmpresas();
}