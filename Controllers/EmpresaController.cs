using Microsoft.AspNetCore.Mvc;
using webapi_aspnet8_patrimweb.Data;
using webapi_aspnet8_patrimweb.Models.DataTransferObject;

namespace webapi_aspnet8_patrimweb.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[ProducesResponseType(typeof(RespostaHttpFalhaDTO), StatusCodes.Status404NotFound)]
[ProducesResponseType(typeof(RespostaHttpFalhaDTO), StatusCodes.Status500InternalServerError)]
public class EmpresaController: ControllerBase
{
    private readonly IPersistencia _dados = new PersistenciaMock();

    [HttpGet("inicial")]
    [ProducesResponseType(typeof(HateoasDTO), StatusCodes.Status200OK)]
    public IActionResult ListaAcoesPossiveis() => Ok(new HateoasDTO()
        {
            Links = [
                new HateoasDetalhesDTO("GET", "Self", "api/empresa/inicial"),
                new HateoasDetalhesDTO("GET", "Listar Empresas", "api/empresa"),
                new HateoasDetalhesDTO("GET", "Retornar Empresa", "api/empresa/{sequencial:long}")
            ]
        });

    [HttpGet()]    
    [ProducesResponseType(typeof(IEnumerable<EmpresaDTO>), StatusCodes.Status200OK)]
    public IActionResult ListaEmpresas()
    {
        try
        {
            var lista = _dados.RetornaEmpresas().Select(s => new EmpresaDTO(s.Sequencial, s.NomeFantasia));
            return lista.Any() ? Ok(lista) : NotFound(new RespostaHttpFalhaDTO(StatusCodes.Status404NotFound, "Informação não encontrada", "Não foram encontradas empresas!"));
        }
        catch (Exception erro)
        {
            return new ObjectResult(new RespostaHttpFalhaDTO(StatusCodes.Status500InternalServerError, "Erro inesperado", erro.Message));
        }
    }

    [HttpGet("{sequencial:long}")]
    [ProducesResponseType(typeof(EmpresaDTO), StatusCodes.Status200OK)]
    public IActionResult RetornaEmpresa([FromRoute]long sequencial)
    {
        try
        {
            var empresa = _dados.RetornaEmpresa(sequencial);
            if(empresa == null) return NotFound(new RespostaHttpFalhaDTO(StatusCodes.Status404NotFound, "Informação não encontrada", "Não foi encontrada a empresa!"));
            return Ok(new EmpresaDTO(empresa.Sequencial, empresa.NomeFantasia));
        }
        catch (Exception erro)
        {
            return new ObjectResult(new RespostaHttpFalhaDTO(StatusCodes.Status500InternalServerError, "Erro inesperado", erro.Message));
        }
    }

}