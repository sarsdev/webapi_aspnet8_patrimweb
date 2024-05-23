using webapi_aspnet8_patrimweb.Models.Entidade;
using webapi_aspnet8_patrimweb.Models.Enumerable;
namespace webapi_aspnet8_patrimweb.Models.DataTransferObject;
public class Movimentacao
{
    public long Sequencial { get; set; }
    public required DateOnly Data { get; set; }
    public required Enumerable.TipoDeMovimentacao Tipo { get; set; }
    public required Produto Produto { get; set; }
    public required bool IndicadorTotal { get; set; }
    public required Enumerable.TipoDeValorMovimentacao TipoDeValor { get; set; }
    public required float Valor { get; set; }
}