using Microsoft.AspNetCore.Mvc;
using webapi_aspnet8_patrimweb.Data;
using webapi_aspnet8_patrimweb.Models.DataTransferObject;

namespace webapi_aspnet8_patrimweb.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[ProducesResponseType(typeof(RespostaHttpFalhaDTO), StatusCodes.Status404NotFound)]
[ProducesResponseType(typeof(RespostaHttpFalhaDTO), StatusCodes.Status500InternalServerError)]
public class ProdutoController: ControllerBase
{
    private readonly IPersistencia _dados = new PersistenciaMock();

    [HttpGet("inicial")]
    [ProducesResponseType(typeof(HateoasDTO), StatusCodes.Status200OK)]
    public IActionResult ListaAcoesPossiveis() => Ok(new HateoasDTO()
        {
            Links = [
                new HateoasDetalhesDTO("GET", "Self", "api/produto/inicial"),
                new HateoasDetalhesDTO("GET", "Listar Produtos", "api/produto"),
                new HateoasDetalhesDTO("GET", "Retornar Produto", "api/produto/{sequencial:long}"),
                new HateoasDetalhesDTO("GET", "Listar Produtos", "api/produto/{numero:int}/{sequencialEmpresa:long}"),
                new HateoasDetalhesDTO("GET", "Listar Produtos", "api/produto/{numero:int}/{nrocomponente:int}/{sequencialEmpresa:long}")
            ]
        });

    [HttpGet()]
    [ProducesResponseType(typeof(IEnumerable<ProdutoDTO>), StatusCodes.Status200OK)]
    public IActionResult ListaProdutos()
    {
        try
        {
            var lista = _dados.RetornaProdutos()
                .Select(s => {
                    var empresa = _dados.RetornaEmpresa(s.SequencialDaEmpresa);
                    if(empresa == null) return new ProdutoDTO(s, new EmpresaDTO(0, string.Empty));
                    return new ProdutoDTO(s, new EmpresaDTO(empresa.Sequencial, empresa.NomeFantasia));
                });
            return lista.Any() ? Ok(lista) : NotFound(new RespostaHttpFalhaDTO(StatusCodes.Status404NotFound, "Informação não encontrada", "Não foram encontrados produtos!"));
        }
        catch (Exception erro)
        {
            return new ObjectResult(new RespostaHttpFalhaDTO(StatusCodes.Status500InternalServerError, "Erro inesperado", erro.Message));
        }
    }

    [HttpGet("{numero:int}/{sequencialEmpresa:long}")]
    [ProducesResponseType(typeof(IEnumerable<ProdutoDTO>), StatusCodes.Status200OK)]
    public IActionResult ListaProdutos([FromRoute]int numero, [FromRoute]long sequencialEmpresa)
    {
        try
        {
            var lista = _dados.RetornaProdutos(numero, sequencialEmpresa)
                .Select(s => {
                    var empresa = _dados.RetornaEmpresa(s.SequencialDaEmpresa);
                    if(empresa == null) return new ProdutoDTO(s, new EmpresaDTO(0, string.Empty));
                    return new ProdutoDTO(s, new EmpresaDTO(empresa.Sequencial, empresa.NomeFantasia));
                });
            return lista.Any() ? Ok(lista) : NotFound(new RespostaHttpFalhaDTO(StatusCodes.Status404NotFound, "Informação não encontrada", "Não foram encontrados produtos!"));
        }
        catch (Exception erro)
        {
            return new ObjectResult(new RespostaHttpFalhaDTO(StatusCodes.Status500InternalServerError, "Erro inesperado", erro.Message));
        }
    }

    [HttpGet("{numero:int}/{nrocomponente:int}/{sequencialEmpresa:long}")]
    [ProducesResponseType(typeof(IEnumerable<ProdutoDTO>), StatusCodes.Status200OK)]
    public IActionResult ListaProdutos([FromRoute]int numero, [FromRoute]int nrocomponente, [FromRoute]long sequencialEmpresa)
    {
        try
        {
            var lista = _dados.RetornaProdutos(numero, nrocomponente, sequencialEmpresa)
                .Select(s => {
                    var empresa = _dados.RetornaEmpresa(s.SequencialDaEmpresa);
                    if(empresa == null) return new ProdutoDTO(s, new EmpresaDTO(0, string.Empty));
                    return new ProdutoDTO(s, new EmpresaDTO(empresa.Sequencial, empresa.NomeFantasia));
                });
            return lista.Any() ? Ok(lista) : NotFound(new RespostaHttpFalhaDTO(StatusCodes.Status404NotFound, "Informação não encontrada", "Não foram encontrados produtos!"));
        }
        catch (Exception erro)
        {
            return new ObjectResult(new RespostaHttpFalhaDTO(StatusCodes.Status500InternalServerError, "Erro inesperado", erro.Message));
        }
    }

    [HttpGet("{sequencial:long}")]
    [ProducesResponseType(typeof(ProdutoDTO), StatusCodes.Status200OK)]
    public IActionResult RetornaProduto(long sequencial)
    {
        try
        {
            var produto = _dados.RetornaProduto(sequencial);
            if(produto == null) return NotFound(new RespostaHttpFalhaDTO(StatusCodes.Status404NotFound, "Informação não encontrada", "Não foi encontrado o produto!"));
            var empresa = _dados.RetornaEmpresa(produto.SequencialDaEmpresa);
            if(empresa == null) return Ok(new ProdutoDTO(produto, new EmpresaDTO(0, "")));
            return Ok(new ProdutoDTO(produto, new EmpresaDTO(empresa.Sequencial, empresa.NomeFantasia)));
        }
        catch (Exception erro)
        {
            return new ObjectResult(new RespostaHttpFalhaDTO(StatusCodes.Status500InternalServerError, "Erro inesperado", erro.Message));
        }
    }

}