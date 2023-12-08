using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using TEKTON.Domain.Aggregates.DescuentoAgg;
using System.Net.Http.Json;
using Microsoft.Extensions.Caching.Memory;

namespace TEKTON.Infrastructure.Data.Repositories
{
    public class DescuentoRepository : IDescuentoRepository
    {
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly MemoryCache _cache;

        public DescuentoRepository(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            this._cache = new MemoryCache(new MemoryCacheOptions());
            this._httpClientFactory = httpClientFactory;
            this._mapper = mapper;
        }

        public async Task<DescuentoListarResponseReadOnly> ListarDescuentos()
        {
            List<DescuentoResponseReadOnly> lista = new();

            //Comprobar si existe
            if (!_cache.TryGetValue(0, out lista))
            {
                //Conslutar el elemento en el microservicio
                lista = await AllDescuentoMicroservicio();
                _cache.Set(0, lista);

                DescuentoListarResponseReadOnly resultado = new DescuentoListarResponseReadOnly()
                {
                    Descuentos = lista,
                    TotalRegistros = lista.Count()
                };
                return resultado;
            }
            else
            {
                DescuentoListarResponseReadOnly resultado = new DescuentoListarResponseReadOnly()
                {
                    Descuentos = new List<DescuentoResponseReadOnly>(),
                    TotalRegistros = 0
                };

                return resultado;
            }
        }

        public async Task<DescuentoResponseReadOnly> BuscarRegistro(int IdDescuento)
        {
            DescuentoResponseReadOnly resultado = new ();

            //Comprobar si existe
            if (!_cache.TryGetValue(IdDescuento, out resultado))
            {
                //Conslutar el elemento en el microservicio
                resultado = await GetDescuentoMicroservicio(IdDescuento);
                _cache.Set(IdDescuento, resultado);
                return resultado;
            }
            else {
                return new DescuentoResponseReadOnly();
            }
        }

        private async Task<List<DescuentoResponseReadOnly>> AllDescuentoMicroservicio()
        {
            HttpClient client = _httpClientFactory.CreateClient("WebApiDescuento");

            return await client.GetFromJsonAsync<List<DescuentoResponseReadOnly>>("Descuento");
        }

        private async Task<DescuentoResponseReadOnly> GetDescuentoMicroservicio(int IdDescuento)
        {
            HttpClient client = _httpClientFactory.CreateClient("WebApiDescuento");


            return await client.GetFromJsonAsync<DescuentoResponseReadOnly>($"Descuento/{IdDescuento}");
        }
    }
}
