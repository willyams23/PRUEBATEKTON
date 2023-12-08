using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TEKTON.Application.Contracts;
using TEKTON.Application.Dtos.Descuento;
using TEKTON.Application.Dtos.Producto;
using TEKTON.Application.QueryFilters.Producto;

namespace TEKTON.Service.Web.API.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoAppService _productoAppService;
        private readonly IMapper _mapper;
        private readonly IDescuentoAppService _descuentoAppService;

        public ProductoController(IProductoAppService productoAppService,   
              IMapper mapper,
              IDescuentoAppService descuentoAppService)
        {
            this._productoAppService = productoAppService;
            this._mapper = mapper;
            this._descuentoAppService = descuentoAppService;
        }

        [HttpGet]
        [Route("API/InicializarProductos")]
        public async Task<IActionResult> InicializarProductos()
        {
            ProductoListarResponseDto lista = new ProductoListarResponseDto();
            try
            {
                lista =  await _productoAppService.InicializarProductos();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se Inicializaron los Datos", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message, response = lista });
            }
        }
        

        [HttpGet]
        [Route("API/ListaProductos")]
        public async Task<ActionResult<ProductoListarResponseDto>> ListarProductos()
        {
            return await _productoAppService.ListarProductos();
        }

        [HttpGet]
        [Route("API/BuscarProducto/{IdProducto}")]
        public async Task<ActionResult<ProductoResponseDto>> BuscarRegistro(int IdProducto)
        {
            return await _productoAppService.BuscarRegistro(IdProducto);
        }

        [HttpDelete]
        [Route("API/EliminarProducto/{IdProducto}")]
        public async Task<ActionResult> EliminarRegistro(int IdProducto)
        {
            try
            {
                bool respuesta = await _productoAppService.EliminarRegistro(IdProducto);

                if (respuesta)
                {
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se elimino el registro.", response = respuesta });
                }
                else {
                    return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Error al momento de eliminar el registro." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });
            }
            
        }


        [HttpPost]
        [Route("API/GrabarProducto")]
        public async Task<ActionResult> GrabarRegistro(PostProductoGuardar PostGuardar)
        {
            try
            {
                //Llamar Api Descuentos
                DescuentoResponseDto oDescuento = await _descuentoAppService.BuscarRegistro(PostGuardar.ProductId);
                ProductoRequestDto Producto = _mapper.Map<ProductoRequestDto>(PostGuardar);
                Producto.PorcentajeDescuento = oDescuento.valor;

                int IdReg = await _productoAppService.GrabarRegistro(Producto);

                if (IdReg > 0)
                {
                    ProductoResponseDto item = await _productoAppService.BuscarRegistro(IdReg);

                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se grabo un nuevo registro.", response = item });
                }
                else {
                    return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Error al momento de grabar el registro." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("API/ActualizarRegistro")]
        public async Task<ActionResult> ActualizarRegistro(PostProductoEditar PostEditar)
        {
            try
            {
                ProductoRequestDto Producto = _mapper.Map<ProductoRequestDto>(PostEditar);

                int IdReg = await _productoAppService.ActualizarRegistro(Producto);

                if (IdReg > 0)
                {
                    ProductoResponseDto item = await _productoAppService.BuscarRegistro(IdReg);

                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "Se actualizo el registro.", response = item });
                }
                else {
                    return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Error al momento de actualizar el registro." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = ex.Message });
            }
        }

    }
}
