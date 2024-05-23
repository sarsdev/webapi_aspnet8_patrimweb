using Microsoft.AspNetCore.Mvc;
using webapi_aspnet8_patrimweb.Data;
using webapi_aspnet8_patrimweb.Models.Entidade;

namespace webapi_aspnet8_patrimweb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmpresaController: ControllerBase
{
    private readonly IPersistencia _dados = new PersistenciaMock();

    [HttpGet()]
    public ActionResult<Empresa> ListaEmpresas()
    {
        return Ok(_dados.RetornaEmpresas());
    }

    [HttpGet("{sequencial}")]
    public ActionResult<Empresa> RetornaEmpresa(long sequencial)
    {
        return Ok(_dados.RetornaEmpresa(sequencial));
    }

}