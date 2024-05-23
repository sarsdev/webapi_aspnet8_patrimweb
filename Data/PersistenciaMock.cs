using webapi_aspnet8_patrimweb.Models.Entidade;
namespace webapi_aspnet8_patrimweb.Data;
public class PersistenciaMock : IPersistencia
{
    #region Movimentação

    public bool AdicionaMovimentacao(Movimentacao movimentacao)
    {
        throw new NotImplementedException();
    }

    public bool AdicionaMovimentacoes(IEnumerable<Movimentacao> movimentacoes)
    {
        throw new NotImplementedException();
    }

    public bool RemoveMovimentacao(Movimentacao movimentacao)
    {
        throw new NotImplementedException();
    }

    public bool RemoveMovimentacoes(IEnumerable<Movimentacao> movimentacoes)
    {
        throw new NotImplementedException();
    }    
    
    public long RetornaNovoSequencialMovimentacao()
    {
        return DadosMock.Movimentacoes.Select(s => s.Sequencial).Max() + 1;
    }

    public Movimentacao? RetornaMovimentacao(long sequencial)
    {
        return DadosMock.Movimentacoes.Where(w => w.Sequencial.Equals(sequencial)).FirstOrDefault();
    }

    public IEnumerable<Movimentacao> RetornaMovimentacoes(IEnumerable<long> sequenciais)
    {
        return DadosMock.Movimentacoes.Where(w => sequenciais.Contains(w.Sequencial));
    }

    public IEnumerable<Movimentacao> RetornaMovimentacoes()
    {
        return DadosMock.Movimentacoes;
    }

    public IEnumerable<Movimentacao> RetornaMovimentacoes(DateOnly data)
    {
        return DadosMock.Movimentacoes.Where(w => w.DataDaMovimentacao.Equals(data));
    }

    public IEnumerable<Movimentacao> RetornaMovimentacoes(DateOnly dataInicialDoPeriodo, DateOnly dataFinalDoPeriodo)
    {
        return DadosMock.Movimentacoes
            .Where(w => 
                w.DataDaMovimentacao >= dataInicialDoPeriodo 
                && w.DataDaMovimentacao <= dataFinalDoPeriodo
            );
    }

    public IEnumerable<Movimentacao> RetornaMovimentacoes(long sequencialDoProduto, DateOnly dataInicialDoPeriodo, DateOnly dataFinalDoPeriodo)
    {
        return DadosMock.Movimentacoes
            .Where(w => 
                w.SequencialDoProduto.Equals(sequencialDoProduto)
                && w.DataDaMovimentacao >= dataInicialDoPeriodo 
                && w.DataDaMovimentacao <= dataFinalDoPeriodo
            );
    }
    
    #endregion Movimentação
    
    #region Empresa

    public Empresa? RetornaEmpresa(long sequencial)
    {
        return DadosMock.Empresas.Where(w => w.Sequencial.Equals(sequencial)).FirstOrDefault();
    }

    public IEnumerable<Empresa> RetornaEmpresas()
    {
        return DadosMock.Empresas;
    }
    
    #endregion Empresa
    
    #region Produto

    public IEnumerable<Produto> RetornaProdutos()
    {
        return DadosMock.Produtos;
    }

    public IEnumerable<Produto> RetornaProdutos(int numero, long sequencialDaEmpresa)
    {
        return DadosMock.Produtos
            .Where(w => 
                w.Numero.Equals(numero) 
                && w.SequencialDaEmpresa.Equals(sequencialDaEmpresa)
            );
    }

    public IEnumerable<Produto> RetornaProdutos(int numero, int nroComponente, long sequencialDaEmpresa)
    {
        return DadosMock.Produtos
            .Where(w => 
                w.Numero.Equals(numero)
                && w.NroComponente.Equals(nroComponente)
                && w.SequencialDaEmpresa.Equals(sequencialDaEmpresa)
            );
    }

    public Produto? RetornaProduto(long sequencial)
    {
        return DadosMock.Produtos.Where(w => w.Sequencial.Equals(sequencial)).FirstOrDefault();
    }

    #endregion Produto
}