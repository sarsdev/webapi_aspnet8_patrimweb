using webapi_aspnet8_patrimweb.Models.Entidade;
using webapi_aspnet8_patrimweb.Models.Enumerable;
namespace webapi_aspnet8_patrimweb.Data;
public static class DadosMock
{
    public static IEnumerable<Movimentacao> Movimentacoes { get; set; } = 
    [
            new()
            {
                Sequencial = 123,
                DataDaMovimentacao = DateOnly.FromDateTime(DateTime.Now),
                Tipo = TipoDeMovimentacao.AQUISICAO,
                SequencialDoProduto = 110,
                ValorMovimentado = 100.0f,
                ValorDoImpostoMovimentado = 33.90f,
                Estounada = false
            },
            new()
            {
                Sequencial = 134,
                DataDaMovimentacao = DateOnly.FromDateTime(DateTime.Now),
                Tipo = TipoDeMovimentacao.BAIXA,
                SequencialDoProduto = 112,
                ValorMovimentado = 250.0f,
                ValorDoImpostoMovimentado = 0.0f,
                Estounada = false
            },
            new()
            {
                Sequencial = 145,
                DataDaMovimentacao = DateOnly.FromDateTime(DateTime.Now),
                Tipo = TipoDeMovimentacao.TRANSFERENCIA,
                SequencialDoProduto = 114,
                ValorMovimentado = 50.0f,
                ValorDoImpostoMovimentado = 0.99f,
                Estounada = false
            }
        ];
    
    public static IEnumerable<Empresa> Empresas { get; set; } = 
    [
        new()
        {
            Sequencial = 11,
            NomeFantasia = "Empresa Modelo A"
        },
        new()
        {
            Sequencial = 20,
            NomeFantasia = "Empresa Modelo B"
        }
    ];

    public static IEnumerable<Produto> Produtos { get; set; } = 
    [
        new()
        {
            Sequencial = 110,
            Numero = 121,
            NroComponente = 1,
            SequencialDaEmpresa = 1,
            Quantidade = 100,
            ValorDeCompra = 1000.0f,
            ValorDoImposto = 120.0f,
            Descricao = "Produto ABC"
        },
        new()
        {
            Sequencial = 111,
            Numero = 121,
            NroComponente = 2,
            SequencialDaEmpresa = 1,
            Quantidade = 10,
            ValorDeCompra = 100.0f,
            ValorDoImposto = 12.0f,
            Descricao = "Produto ABC"
        },
        new()
        {
            Sequencial = 112,
            Numero = 125,
            NroComponente = 1,
            SequencialDaEmpresa = 1,
            Quantidade = 25,
            ValorDeCompra = 255.0f,
            ValorDoImposto = 75.90f,
            Descricao = "Produto FGH"
        },
        new()
        {
            Sequencial = 113,
            Numero = 126,
            NroComponente = 1,
            SequencialDaEmpresa = 2,
            Quantidade = 5,
            ValorDeCompra = 59.90f,
            ValorDoImposto = 0.0f,
            Descricao = "Produto JKL"
        },
        new()
        {
            Sequencial = 114,
            Numero = 127,
            NroComponente = 1,
            SequencialDaEmpresa = 1,
            Quantidade = 50,
            ValorDeCompra = 890.65f,
            ValorDoImposto = 132.44f,
            Descricao = "Produto OPQ"
        }
    ];
}