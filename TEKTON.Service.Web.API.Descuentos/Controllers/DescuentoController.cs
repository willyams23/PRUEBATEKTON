using Microsoft.AspNetCore.Mvc;
using TEKTON.Service.Web.API.Descuentos.Application;
using TEKTON.Service.Web.API.Descuentos.Domain;

namespace TEKTON.Service.Web.API.Descuentos.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class DescuentoController : Controller
    {
        private readonly IDescuentoRepository _descuentoApp;

        public DescuentoController(IDescuentoRepository descuentoApp)
        {
            this._descuentoApp = descuentoApp;
        }


        [HttpGet]
        public async Task<ActionResult<List<DescuentoResponseDto>>> ListarDescuentos()
        {
            return await _descuentoApp.ListarDescuentos();
        }


        [HttpGet("{IdDescuento}")]
        public async Task<ActionResult<DescuentoResponseDto>> BuscarRegistro(int IdDescuento)
        {
            return await _descuentoApp.BuscarRegistro(IdDescuento);
        }
    }
}
