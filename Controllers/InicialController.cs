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
                new HateoasDetalhesDTO("GET", "Listar Produtos", "api/produto"),
                new HateoasDetalhesDTO("GET", "Listar Tipos de Movimentação", "api/movimentacao/tipos"),
                new HateoasDetalhesDTO("GET", "Listar Tipos de Valor de Movimentação", "api/movimentacao/tiposdevalor"),
                new HateoasDetalhesDTO("GET", "Listar Movimentações", "api/movimentacao"),
                new HateoasDetalhesDTO("POST", "Adicionar Movimentação", "api/movimentacao"),
                new HateoasDetalhesDTO("POST", "Adicionar Várias Movimentações", "api/movimentacao/varios"),
                new HateoasDetalhesDTO("DELETE", "Estornar Várias Movimentações", "api/movimentacao/varios")
            ]
        });
}