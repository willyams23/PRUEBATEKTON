using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKTON.Application.Contracts;
using TEKTON.Application.Dtos.Descuento;
using TEKTON.Domain.Aggregates.DescuentoAgg;
using TEKTON.Infrastructure.Crosscutting.ExceptionsTypes;
using TEKTON.Infrastructure.Crosscutting.Resources;

namespace TEKTON.Application.Implementations
{
    public class DescuentoAppService : IDescuentoAppService
    {
        private IDescuentoRepository _DescuentoRepository;
        private readonly IMapper _mapper;
        public DescuentoAppService(IDescuentoRepository DescuentoRepository, IMapper mapper)
        {
            this._DescuentoRepository = DescuentoRepository;
            this._mapper = mapper;
        }

        public async Task<DescuentoListarResponseDto> ListarDescuentos()
        {
            DescuentoListarResponseReadOnly ListaDescuentos = await this._DescuentoRepository.ListarDescuentos();

            if (ListaDescuentos != null)
            {
                return _mapper.Map<DescuentoListarResponseDto>(ListaDescuentos);
            }
            throw new NotFoundException(Messages.NotFoundResource);
        }

        public async Task<DescuentoResponseDto> BuscarRegistro(int IdDescuento)
        {
            if (IdDescuento > 0)
            {
                DescuentoResponseReadOnly oDescuento = await this._DescuentoRepository.BuscarRegistro(IdDescuento);

                if (oDescuento != null)
                {
                    return _mapper.Map<DescuentoResponseDto>(oDescuento);
                }
                throw new NotFoundException(Messages.NotFoundResource);
            }

            throw new ArgumentNullException(IdDescuento.ToString());
        }
    }
}
