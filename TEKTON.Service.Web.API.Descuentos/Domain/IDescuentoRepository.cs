using TEKTON.Service.Web.API.Descuentos.Application;

namespace TEKTON.Service.Web.API.Descuentos.Domain
{
    public interface IDescuentoRepository
    {
        Task<List<DescuentoResponseDto>> ListarDescuentos();
        Task<DescuentoResponseDto> BuscarRegistro(int IdDescuento);
    }
}
