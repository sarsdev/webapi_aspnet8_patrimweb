using Microsoft.AspNetCore.Mvc;
using webapi_aspnet8_patrimweb.Models;

namespace webapi_aspnet8_patrimweb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovimentacaoController: ControllerBase
{
    private readonly IEnumerable<Movimentacao> _movimentacoes =
        [
            new()
            {
                Sequencial = 123,
                Data = DateOnly.FromDateTime(DateTime.Now),
                Tipo = TipoDeMovimentacao.AQUISICAO,
                Produto = new()
                {
                    Sequencial = 1,
                    Numero = 111,
                    NroComponente = 1,
                    Descricao = "Produto A"
                },
                IndicadorTotal = true,
                TipoDeValor = TipoDeValorMovimentacao.QUANTIDADE,
                Valor = 10
            },
            new()
            {
                Sequencial = 134,
                Data = DateOnly.FromDateTime(DateTime.Now),
                Tipo = TipoDeMovimentacao.BAIXA,
                Produto = new()
                {
                    Sequencial = 2,
                    Numero = 222,
                    NroComponente = 1,
                    Descricao = "Produto B"
                },
                IndicadorTotal = false,
                TipoDeValor = TipoDeValorMovimentacao.PERCENTUAL,
                Valor = 25
            },
            new()
            {
                Sequencial = 145,
                Data = DateOnly.FromDateTime(DateTime.Now),
                Tipo = TipoDeMovimentacao.TRANSFERENCIA,
                Produto = new()
                {
                    Sequencial = 3,
                    Numero = 333,
                    NroComponente = 1,
                    Descricao = "Produto C"
                },
                IndicadorTotal = false,
                TipoDeValor = TipoDeValorMovimentacao.VALOR,
                Valor = 150.99f
            }
        ];

    [HttpGet()]
    public ActionResult<Movimentacao> ListaMovimentacoes()
    {
        return Ok(_movimentacoes);
    }

    [HttpGet("{dataInicial}/{dataFinal}")]
    public ActionResult<Movimentacao> ListaMovimentacoes(DateOnly dataInicial, DateOnly dataFinal)
    {
        var lista = _movimentacoes
            .Where(w =>
                w.Data >= dataInicial
                && w.Data <= dataFinal
            ).ToList();
        return Ok(lista);
    }

    [HttpGet("{sequencialProduto}/{dataInicial}/{dataFinal}")]
    public ActionResult<Movimentacao> ListaMovimentacoes(long sequencialProduto, DateOnly dataInicial, DateOnly dataFinal)
    {
        var lista = _movimentacoes
            .Where(w =>
                w.Produto.Sequencial.Equals(sequencialProduto)
                && w.Data >= dataInicial
                && w.Data <= dataFinal
            ).ToList();
        return Ok(lista);
    }

    [HttpGet("{sequencial}")]
    public ActionResult<Movimentacao> RetornaMovimentacao(long sequencial)
    {
        var movimentacao = _movimentacoes.Where(w => w.Sequencial.Equals(sequencial)).FirstOrDefault();
        return Ok(movimentacao);
    }

    [HttpPost()]
    public ActionResult<Movimentacao> AdicionarMovimentacao(Movimentacao movimentacao)
    {
        movimentacao.Sequencial = 1100;
        return Created("api/Movimentacao/1100", movimentacao);
    }
    
    [HttpPost("varios")]
    public ActionResult<Movimentacao> AdicionarMovimentacoes(IEnumerable<Movimentacao> movimentacoes)
    {
        string localizacoes = string.Empty;
        int controleSequencial = 1000;
        foreach (var movimentacao in movimentacoes)
        {
            movimentacao.Sequencial = controleSequencial;
            localizacoes += $"api/Movimentacao/{controleSequencial};";
            controleSequencial++;
        }
        return Created(localizacoes, movimentacoes);
    }

    [HttpDelete("{sequencial}")]
    public ActionResult<Movimentacao> EstornaMovimentacao(long sequencial)
    {
        if(!_movimentacoes.Where(w => w.Sequencial.Equals(sequencial)).Any()) return NotFound();
        return NoContent();
    }

    [HttpDelete("varios")]
    public ActionResult<Movimentacao> EstornaMovimentacoes(IEnumerable<long> listaSequenciais)
    {
        if(!_movimentacoes.Where(w => listaSequenciais.Contains(w.Sequencial)).Any()) return NotFound();
        return NoContent();
    }
}