using Microsoft.AspNetCore.Mvc;
using webapi_aspnet8_patrimweb.Models.DataTransferObject;

namespace webapi_aspnet8_patrimweb.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class InicialController: ControllerBase
{
    [HttpGet()]
    [ProducesResponseType(typeof(HateoasDTO), StatusCodes.Status200OK)]
    public IActionResult ListaAcoesPossiveis() => Ok(new HateoasDTO()
        {
            Links = [
                new HateoasDetalhesDTO("GET", "Listar Empresas", "api/empresa"),
                new HateoasDetalhesDTO("GET", "Listar Ações Possíveis em Empresa", "api/empresa/inicial"),
                new HateoasDetalhesDTO("GET", "Listar Produtos", "api/produto"),
                new HateoasDetalhesDTO("GET", "Listar Ações Possíveis em Produtos", "api/produto/inicial"),
                new HateoasDetalhesDTO("GET", "Listar Movimentações", "api/movimentacao"),
                new HateoasDetalhesDTO("GET", "Listar Ações Possíveis em Movimentações", "api/movimentacao/inicial")
            ]
        });
}