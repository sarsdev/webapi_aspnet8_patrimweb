using Microsoft.AspNetCore.Mvc;
using webapi_aspnet8_patrimweb.Data;
using webapi_aspnet8_patrimweb.Models.DataTransferObject;
using webapi_aspnet8_patrimweb.Models.Entidade;
using webapi_aspnet8_patrimweb.Models.Enumerable;

namespace webapi_aspnet8_patrimweb.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[ProducesResponseType(typeof(RespostaHttpFalhaDTO), StatusCodes.Status500InternalServerError)]
public class MovimentacaoController: ControllerBase
{
    private readonly IPersistencia _dados = new PersistenciaMock();

    [HttpGet("tipos")]
    [ProducesResponseType(typeof(Dictionary<string, int>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RespostaHttpFalhaDTO), StatusCodes.Status404NotFound)]
    public IActionResult ListaTiposDeMovimentacao()
    {
        try
        {
            var lista = Enum.GetValues(typeof(TipoDeMovimentacao))
            .Cast<TipoDeMovimentacao>()
            .ToDictionary(nome => nome.ToString(), valor => (int)valor);
            return lista.Count != 0 ? Ok(lista) : NotFound(new RespostaHttpFalhaDTO(StatusCodes.Status404NotFound, "Informação não encontrada", "Não foram encontrados Tipos de Movimentação!"));
        }
        catch (Exception erro)
        {
            return new ObjectResult(new RespostaHttpFalhaDTO(StatusCodes.Status500InternalServerError, "Erro inesperado", erro.Message));
        }
    }

    [HttpGet("tiposdevalor")]
    [ProducesResponseType(typeof(Dictionary<string, int>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RespostaHttpFalhaDTO), StatusCodes.Status404NotFound)]
    public IActionResult ListaTiposDeValorMovimentacao()
    {
        try
        {
            var lista = Enum.GetValues(typeof(TipoDeValorMovimentacao))
            .Cast<TipoDeValorMovimentacao>()
            .ToDictionary(nome => nome.ToString(), valor => (int)valor);
            return lista.Count != 0 ? Ok(lista) : NotFound(new RespostaHttpFalhaDTO(StatusCodes.Status404NotFound, "Informação não encontrada", "Não foram encontrados Tipos de Valores para Movimentações!"));
        }
        catch (Exception erro)
        {
            return new ObjectResult(new RespostaHttpFalhaDTO(StatusCodes.Status500InternalServerError, "Erro inesperado", erro.Message));
        }
    }

    [HttpGet()]
    [ProducesResponseType(typeof(IEnumerable<MovimentacaoDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RespostaHttpFalhaDTO), StatusCodes.Status404NotFound)]
    public IActionResult ListaMovimentacoes()
    {
        try
        {
            var lista = _dados.RetornaMovimentacoes()
                .Where(w => w.Estounada.Equals(false))
                .Select(s => new MovimentacaoDTO(){
                    Sequencial = s.Sequencial,
                    Data = s.DataDaMovimentacao,
                    IndicadorTotal = s.IndicadorTotal,
                    Produto = _dados.RetornaProduto(s.SequencialDoProduto),
                    Tipo = s.Tipo,
                    TipoDeValor = s.TipoDeValor,
                    Valor = s.ValorOperacao
                });
            return lista.Any() ? Ok(lista) : NotFound(new RespostaHttpFalhaDTO(StatusCodes.Status404NotFound, "Informação não encontrada", "Não foram encontradas movimentações!"));
        }
        catch (Exception erro)
        {
            return new ObjectResult(new RespostaHttpFalhaDTO(StatusCodes.Status500InternalServerError, "Erro inesperado", erro.Message));
        }
    }

    [HttpGet("{dataInicial:datetime}/{dataFinal:datetime}")]
    [ProducesResponseType(typeof(IEnumerable<MovimentacaoDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RespostaHttpFalhaDTO), StatusCodes.Status404NotFound)]
    public IActionResult ListaMovimentacoes(DateOnly dataInicial, DateOnly dataFinal)
    {
        try
        {
            var lista = _dados.RetornaMovimentacoes(dataInicial, dataFinal)
                .Where(w => w.Estounada.Equals(false))
                .Select(s => new MovimentacaoDTO(){
                    Sequencial = s.Sequencial,
                    Data = s.DataDaMovimentacao,
                    IndicadorTotal = s.IndicadorTotal,
                    Produto = _dados.RetornaProduto(s.SequencialDoProduto),
                    Tipo = s.Tipo,
                    TipoDeValor = s.TipoDeValor,
                    Valor = s.ValorOperacao
                });
            return lista.Any() ? Ok(lista) : NotFound(new RespostaHttpFalhaDTO(StatusCodes.Status404NotFound, "Informação não encontrada", "Não foram encontradas movimentações!"));
        }
        catch (Exception erro)
        {
            return new ObjectResult(new RespostaHttpFalhaDTO(StatusCodes.Status500InternalServerError, "Erro inesperado", erro.Message));
        }
    }

    [HttpGet("{sequencialProduto:long}/{dataInicial:datetime}/{dataFinal:datetime}")]
    [ProducesResponseType(typeof(IEnumerable<MovimentacaoDTO>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RespostaHttpFalhaDTO), StatusCodes.Status404NotFound)]
    public IActionResult ListaMovimentacoes(long sequencialProduto, DateOnly dataInicial, DateOnly dataFinal)
    {
        try
        {
            var lista = _dados.RetornaMovimentacoes(sequencialProduto, dataInicial, dataFinal)
                .Where(w => w.Estounada.Equals(false))
                .Select(s => new MovimentacaoDTO(){
                    Sequencial = s.Sequencial,
                    Data = s.DataDaMovimentacao,
                    IndicadorTotal = s.IndicadorTotal,
                    Produto = _dados.RetornaProduto(s.SequencialDoProduto),
                    Tipo = s.Tipo,
                    TipoDeValor = s.TipoDeValor,
                    Valor = s.ValorOperacao
                });
            return lista.Any() ? Ok(lista) : NotFound(new RespostaHttpFalhaDTO(StatusCodes.Status404NotFound, "Informação não encontrada", "Não foram encontradas movimentações!"));
        }
        catch (Exception erro)
        {
            return new ObjectResult(new RespostaHttpFalhaDTO(StatusCodes.Status500InternalServerError, "Erro inesperado", erro.Message));
        }
    }

    [HttpGet("{sequencial:long}")]
    [ProducesResponseType(typeof(MovimentacaoDTO), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RespostaHttpFalhaDTO), StatusCodes.Status404NotFound)]
    public IActionResult RetornaMovimentacao(long sequencial)
    {
        try
        {
            var movimentacao = _dados.RetornaMovimentacao(sequencial);
            if(movimentacao == null || movimentacao.Estounada) return NotFound(new RespostaHttpFalhaDTO(StatusCodes.Status404NotFound, "Informação não encontrada", "Não foi encontrada a movimentação!"));
            return Ok(new MovimentacaoDTO(){
                Sequencial = movimentacao.Sequencial,
                Data = movimentacao.DataDaMovimentacao,
                IndicadorTotal = movimentacao.IndicadorTotal,
                Produto = _dados.RetornaProduto(movimentacao.SequencialDoProduto),
                Tipo = movimentacao.Tipo,
                TipoDeValor = movimentacao.TipoDeValor,
                Valor = movimentacao.ValorOperacao
            });
        }
        catch (Exception erro)
        {
            return new ObjectResult(new RespostaHttpFalhaDTO(StatusCodes.Status500InternalServerError, "Erro inesperado", erro.Message));
        }
    }

    [HttpPost()]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarMovimentacao(MovimentacaoDTO movimentacao)
    {
        try
        {
            movimentacao.Sequencial = _dados.RetornaNovoSequencialMovimentacao();
            var movimentacaoEntidade = new Movimentacao(movimentacao);
            _dados.AdicionaMovimentacao(movimentacaoEntidade);
            return Created($"api/movimentacao/{movimentacaoEntidade.Sequencial}", movimentacaoEntidade);
        }
        catch (Exception erro)
        {
            return new ObjectResult(new RespostaHttpFalhaDTO(StatusCodes.Status500InternalServerError, "Erro inesperado", erro.Message));
        }
    }
    
    [HttpPost("varios")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarMovimentacoes(IEnumerable<MovimentacaoDTO> movimentacoes)
    {
        try
        {
            var sequencial = _dados.RetornaNovoSequencialMovimentacao();
            var movimentacoesEntidade = movimentacoes
                .Select(s => {
                    s.Sequencial = sequencial++;
                    return new Movimentacao(s);
                });
            _dados.AdicionaMovimentacoes(movimentacoesEntidade);
            return Created("varios", movimentacoes);
        }
        catch (Exception erro)
        {
            return new ObjectResult(new RespostaHttpFalhaDTO(StatusCodes.Status500InternalServerError, "Erro inesperado", erro.Message));
        }
    }

    [HttpDelete("{sequencial:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RespostaHttpFalhaDTO), StatusCodes.Status404NotFound)]
    public IActionResult EstornaMovimentacao([FromRoute]long sequencial)
    {
        try
        {
            var movimentacao = _dados.RetornaMovimentacao(sequencial);
            if(movimentacao == null || movimentacao.Estounada) return NotFound(new RespostaHttpFalhaDTO(StatusCodes.Status404NotFound, "Informação não encontrada", "Não foi encontrada a movimentação!"));
            _dados.RemoveMovimentacao(movimentacao);
            return Ok();
        }
        catch (Exception erro)
        {
            return new ObjectResult(new RespostaHttpFalhaDTO(StatusCodes.Status500InternalServerError, "Erro inesperado", erro.Message));
        }
    }

    [HttpDelete("varios")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(RespostaHttpFalhaDTO), StatusCodes.Status404NotFound)]
    public IActionResult EstornaMovimentacoes([FromBody]IEnumerable<long> listaSequenciais)
    {
        try
        {
            var movimentacoes = _dados.RetornaMovimentacoes(listaSequenciais).Where(w => w.Estounada.Equals(false));
            var nroMovimentacoesEncontradas = movimentacoes.Count();
            var nroMovimentacoesSolicitadas = listaSequenciais.Count();
            if(!nroMovimentacoesEncontradas.Equals(nroMovimentacoesSolicitadas)) 
            {
                return NotFound(new RespostaHttpFalhaDTO(
                    StatusCodes.Status404NotFound,
                    "Informação não encontrada",
                    nroMovimentacoesEncontradas == 0 ? 
                        "Nenhuma movimentação foi encontrada!" :
                        nroMovimentacoesEncontradas < nroMovimentacoesSolicitadas ?
                            "Algumas movimentações não foram encontradas" : 
                            "Foram encontradas mais movimentações do que foram solicitadas"
                ));
            }
            _dados.RemoveMovimentacoes(movimentacoes);
            return Ok();        
        }
        catch (Exception erro)
        {
            return new ObjectResult(new RespostaHttpFalhaDTO(StatusCodes.Status500InternalServerError, "Erro inesperado", erro.Message));
        }
    }
}