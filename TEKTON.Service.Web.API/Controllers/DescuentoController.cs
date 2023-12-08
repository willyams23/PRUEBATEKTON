using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TEKTON.Application.Contracts;
using TEKTON.Application.Dtos.Descuento;

namespace TEKTON.Service.Web.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class DescuentoController : Controller
    {
        private readonly IDescuentoAppService _descuentoAppService;
        private readonly IMapper _mapper;

        public DescuentoController(IDescuentoAppService descuentoAppService,
              IMapper mapper)
        {
            this._descuentoAppService = descuentoAppService;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("API/ListaDescuentos")]
        public async Task<ActionResult<DescuentoListarResponseDto>> ListarDescuentos()
        {
            return await _descuentoAppService.ListarDescuentos();
        }


        [HttpGet]
        [Route("API/BuscarDescuento/{IdDescuento}")]
        public async Task<ActionResult<DescuentoResponseDto>> BuscarRegistro(int IdDescuento)
        {
            return await _descuentoAppService.BuscarRegistro(IdDescuento);
        }

    }
}
