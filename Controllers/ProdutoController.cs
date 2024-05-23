using Microsoft.AspNetCore.Mvc;
using webapi_aspnet8_patrimweb.Data;
using webapi_aspnet8_patrimweb.Models.Entidade;

namespace webapi_aspnet8_patrimweb.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController: ControllerBase
{
    private readonly IPersistencia _dados = new PersistenciaMock();

    [HttpGet()]
    public ActionResult<Produto> ListaProdutos()
    {
        return Ok(_dados.RetornaProdutos());
    }

    [HttpGet("{numero}/{sequencialEmpresa}")]
    public ActionResult<Produto> ListaProdutos(int numero, long sequencialEmpresa)
    {
        return Ok(_dados.RetornaProdutos(numero, sequencialEmpresa));
    }

    [HttpGet("{numero}/{nrocomponente}/{sequencialEmpresa}")]
    public ActionResult<Produto> ListaProdutos(int numero, int nrocomponente, long sequencialEmpresa)
    {
        return Ok(_dados.RetornaProdutos(numero, nrocomponente, sequencialEmpresa));
    }

    [HttpGet("{sequencial}")]
    public ActionResult<Produto> RetornaProduto(long sequencial)
    {
        return Ok(_dados.RetornaProduto(sequencial));
    }

}