using Microsoft.AspNetCore.Mvc;
using webapi_aspnet8_patrimweb.Data;
using webapi_aspnet8_patrimweb.Models.DataTransferObject;
using webapi_aspnet8_patrimweb.Models.Enumerable;

namespace webapi_aspnet8_patrimweb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovimentacaoController: ControllerBase
{
    private readonly IPersistencia _dados = new PersistenciaMock();

    [HttpGet("tipos")]
    public ActionResult ListaTiposDeMovimentacao()
    {
        var lista = Enum.GetValues(typeof(TipoDeMovimentacao))
            .Cast<TipoDeMovimentacao>()
            .ToDictionary(nome => nome.ToString(), valor => (int)valor);
        return Ok(lista);
    }

    [HttpGet("tiposdevalor")]
    public ActionResult ListaTiposDeValorMovimentacao()
    {
        var lista = Enum.GetValues(typeof(TipoDeValorMovimentacao))
            .Cast<TipoDeValorMovimentacao>()
            .ToDictionary(nome => nome.ToString(), valor => (int)valor);
        return Ok(lista);
    }

    [HttpGet()]
    public ActionResult<Movimentacao> ListaMovimentacoes()
    {
        return Ok(_dados.RetornaMovimentacoes());
    }

    [HttpGet("{dataInicial}/{dataFinal}")]
    public ActionResult<Movimentacao> ListaMovimentacoes(DateOnly dataInicial, DateOnly dataFinal)
    {
        return Ok(_dados.RetornaMovimentacoes(dataInicial, dataFinal));
    }

    [HttpGet("{sequencialProduto}/{dataInicial}/{dataFinal}")]
    public ActionResult<Movimentacao> ListaMovimentacoes(long sequencialProduto, DateOnly dataInicial, DateOnly dataFinal)
    {
        return Ok(_dados.RetornaMovimentacoes(sequencialProduto, dataInicial, dataFinal));
    }

    [HttpGet("{sequencial}")]
    public ActionResult<Movimentacao> RetornaMovimentacao(long sequencial)
    {
        return Ok(_dados.RetornaMovimentacao(sequencial));
    }

    [HttpPost()]
    public ActionResult<Movimentacao> AdicionarMovimentacao(Movimentacao movimentacao)
    {
        movimentacao.Sequencial = _dados.RetornaNovoSequencialMovimentacao();
        var movimentacaoEntidade = new Models.Entidade.Movimentacao(movimentacao);
        if(!_dados.AdicionaMovimentacao(movimentacaoEntidade))
            return Problem("Não foi possível executar a movimentação!");
        return Created($"api/movimentacao/{movimentacaoEntidade.Sequencial}", movimentacaoEntidade);
    }
    
    [HttpPost("varios")]
    public ActionResult<Movimentacao> AdicionarMovimentacoes(IEnumerable<Movimentacao> movimentacoes)
    {
        var sequencial = _dados.RetornaNovoSequencialMovimentacao();
        var movimentacoesEntidade = movimentacoes
            .Select(s => {
                s.Sequencial = sequencial++;
                return new Models.Entidade.Movimentacao(s);
            });
        if(!_dados.AdicionaMovimentacoes(movimentacoesEntidade))
            return Problem("Não foi possível executar a movimentação!");
        return Created("", movimentacoes);
    }

    [HttpDelete("{sequencial}")]
    public ActionResult<Movimentacao> EstornaMovimentacao(long sequencial)
    {
        var movimentacao = _dados.RetornaMovimentacao(sequencial);
        if(movimentacao == null) return NotFound();
        _dados.RemoveMovimentacao(movimentacao);
        return NoContent();
    }

    [HttpDelete("varios")]
    public ActionResult<Movimentacao> EstornaMovimentacoes(IEnumerable<long> listaSequenciais)
    {
        var movimentacoes = _dados.RetornaMovimentacoes(listaSequenciais);
        if(!movimentacoes.Count().Equals(listaSequenciais.Count())) return NotFound();
        _dados.RemoveMovimentacoes(movimentacoes);
        return NoContent();
    }
}