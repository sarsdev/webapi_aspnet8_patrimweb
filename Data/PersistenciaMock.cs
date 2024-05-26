using webapi_aspnet8_patrimweb.Models.Entidade;
namespace webapi_aspnet8_patrimweb.Data;
public class PersistenciaMock : IPersistencia
{
    #region Movimentação

    public void AdicionaMovimentacao(Movimentacao movimentacao)
    {
        try
        {
            DadosMock.Movimentacoes = DadosMock.Movimentacoes.Append(movimentacao);
        }
        catch (Exception erro)
        {
            throw new Exception($"Não foi posssível inserir a nova movimentação! Erro: {erro.Message}");
        }
    }

    public void AdicionaMovimentacoes(IEnumerable<Movimentacao> movimentacoes)
    {
        try
        {
            foreach (var movimentacao in movimentacoes)
            {
                DadosMock.Movimentacoes = DadosMock.Movimentacoes.Append(movimentacao);
            }
        }
        catch (Exception erro)
        {
            throw new Exception($"Não foi posssível inserir as novas movimentações! Erro: {erro.Message}");
        }
    }

    public void RemoveMovimentacao(Movimentacao movimentacao)
    {
        try
        {
            Movimentacao? movimentacaoAuxiliar = DadosMock.Movimentacoes
                .Where(w => w.Sequencial.Equals(movimentacao.Sequencial))
                .FirstOrDefault() ??
                throw new Exception("Movimentação não encontrada!");
            movimentacaoAuxiliar.Estounada = true;
        }
        catch (Exception erro)
        {
            throw new Exception($"Não foi posssível estornar a movimentação! Erro: {erro.Message}");
        }
    }

    public void RemoveMovimentacoes(IEnumerable<Movimentacao> movimentacoes)
    {
        try
        {
            foreach (var movimentacao in movimentacoes)
            {
                Movimentacao? movimentacaoAuxiliar = DadosMock.Movimentacoes
                    .Where(w => w.Sequencial.Equals(movimentacao.Sequencial))
                    .FirstOrDefault() ??
                    throw new Exception("Movimentação não encontrada!");
                movimentacaoAuxiliar.Estounada = true;                
            }
        }
        catch (Exception erro)
        {
            throw new Exception($"Não foi posssível estornas as movimentações! Erro: {erro.Message}");
        }
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

    public Produto RetornaProduto(long sequencial)
    {
        try
        {
            return DadosMock.Produtos.Where(w => w.Sequencial.Equals(sequencial)).First();            
        }
        catch (Exception)
        {
            throw new Exception("O produto não foi encontrado!");
        }
    }

    #endregion Produto
}