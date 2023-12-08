using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEKTON.Application.Dtos.Descuento;
using TEKTON.Application.Dtos.Producto;
using TEKTON.Application.QueryFilters.Producto;
using TEKTON.Domain.Aggregates.DescuentoAgg;
using TEKTON.Domain.Aggregates.ProductoAgg;

namespace TEKTON.Application.MapperProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Entity to Dto
            CreateMap<ProductoListarRequestReadOnly, ProductoListarRequestDto>();
            CreateMap<ProductoListarResponseReadOnly, ProductoListarResponseDto>();
            CreateMap<ProductoRequestReadOnly, ProductoRequestDto>();
            CreateMap<ProductoResponseReadOnly, ProductoResponseDto>();

            CreateMap<ProductoResponseReadOnly, ProductoRequestReadOnly>();
            CreateMap<ProductoRequestReadOnly, ProductoResponseReadOnly>();
            
            //--Descuento
            CreateMap<DescuentoListarResponseReadOnly, DescuentoListarResponseDto>();
            CreateMap<DescuentoRequestReadOnly, DescuentoRequestDto>();
            CreateMap<DescuentoResponseReadOnly, DescuentoResponseDto>();
            #endregion

            #region Dto to Entity
            CreateMap<ProductoListarRequestDto, ProductoListarRequestReadOnly>();
            CreateMap<ProductoListarResponseDto, ProductoListarResponseReadOnly>();
            CreateMap<ProductoRequestDto, ProductoRequestReadOnly>();
            CreateMap<ProductoResponseDto, ProductoResponseReadOnly>();

            CreateMap<ProductoResponseDto, ProductoRequestDto>();
            CreateMap<ProductoRequestDto, ProductoResponseDto>();

            //--Descuento
            CreateMap<DescuentoListarResponseDto, DescuentoListarResponseReadOnly>();
            CreateMap<DescuentoRequestDto, DescuentoRequestReadOnly>();
            CreateMap<DescuentoResponseDto, DescuentoResponseReadOnly>();
            #endregion

            #region Post to Dto
            CreateMap<PostProductoGuardar, ProductoRequestDto>();
            CreateMap<PostProductoEditar, ProductoRequestDto>();

            #endregion
        }
    }
}
