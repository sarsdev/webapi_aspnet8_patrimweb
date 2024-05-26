using Microsoft.AspNetCore.Mvc;
using webapi_aspnet8_patrimweb.Data;
using webapi_aspnet8_patrimweb.Models.DataTransferObject;
using webapi_aspnet8_patrimweb.Models.Entidade;

namespace webapi_aspnet8_patrimweb.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
[ProducesResponseType(typeof(RespostaHttpFalhaDTO), StatusCodes.Status404NotFound)]
[ProducesResponseType(typeof(RespostaHttpFalhaDTO), StatusCodes.Status500InternalServerError)]
public class EmpresaController: ControllerBase
{
    private readonly IPersistencia _dados = new PersistenciaMock();

    [HttpGet()]    
    [ProducesResponseType(typeof(IEnumerable<Empresa>), StatusCodes.Status200OK)]
    public IActionResult ListaEmpresas()
    {
        try
        {
            var lista = _dados.RetornaEmpresas();
            return lista.Any() ? Ok(lista) : NotFound(new RespostaHttpFalhaDTO(StatusCodes.Status404NotFound, "Informação não encontrada", "Não foram encontradas empresas!"));
        }
        catch (Exception erro)
        {
            return new ObjectResult(new RespostaHttpFalhaDTO(StatusCodes.Status500InternalServerError, "Erro inesperado", erro.Message));
        }
    }

    [HttpGet("{sequencial:long}")]
    [ProducesResponseType(typeof(Empresa), StatusCodes.Status200OK)]
    public IActionResult RetornaEmpresa([FromRoute]long sequencial)
    {
        try
        {
            var empresa = _dados.RetornaEmpresa(sequencial);
            return empresa != null ? Ok(empresa) : NotFound(new RespostaHttpFalhaDTO(StatusCodes.Status404NotFound, "Informação não encontrada", "Não foi encontrada a empresa!"));
        }
        catch (Exception erro)
        {
            return new ObjectResult(new RespostaHttpFalhaDTO(StatusCodes.Status500InternalServerError, "Erro inesperado", erro.Message));
        }
    }

}