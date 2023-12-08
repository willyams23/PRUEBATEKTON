using Newtonsoft.Json;
using StackExchange.Redis;
using TEKTON.Infrastructure.Crosscutting;
using TEKTON.Service.Web.API.Descuentos.Application;
using TEKTON.Service.Web.API.Descuentos.Infrastructure.Context;

namespace TEKTON.Service.Web.API.Descuentos.Domain
{
    public class DescuentoRepository : IDescuentoRepository
    {


        public List<DescuentoResponseDto> Inicializar()
        {
            List<DescuentoResponseDto> lista = new();
            Random rand = new Random();
            for (int i = 1; i <= 100; i++)
            {
                DescuentoResponseDto discount = new()
                {
                    id = i.ToString(),
                    valor = rand.Next(0, 100)
                };
                lista.Add(discount);
            }
            GuardarLista(lista);

            return lista;
        }

        public Task<List<DescuentoResponseDto>> ListarDescuentos()
        {
            List<DescuentoResponseDto>? lista = new();

            var redisDB = AppDbContext.Connection.GetDatabase();
            var lista_producto = redisDB.StringGet("ListaDescuentos");
            if (lista_producto != RedisValue.Null)
            {
                //Existe Descuentos
                lista = this.ObtenerLista();
                if (lista == null)
                {
                    lista = new();
                }
            }
            else
            {
                //Generar
                lista = Inicializar();
            }

            return Task.FromResult(lista);
        }

        public Task<DescuentoResponseDto> BuscarRegistro(int IdDescuento)
        {
            var redisDB = AppDbContext.Connection.GetDatabase();
            var lista_producto = redisDB.StringGet("ListaDescuentos");
            if (lista_producto == RedisValue.Null)
            {
                Inicializar();
            }

            DescuentoResponseDto? resultado = new();
            List<DescuentoResponseDto>? lista = this.ObtenerLista();

            if (lista != null)
            {
                if (lista.Find(x => x.id == IdDescuento.ToString()) != null)
                {
                    resultado = lista.Find(x => x.id == IdDescuento.ToString());
                }
            }

            return Task.FromResult(resultado);
        }

        #region Guadar Redis
        private List<DescuentoResponseDto>? ObtenerLista()
        {
            List<DescuentoResponseDto>? lista = new();
            var redisDB = AppDbContext.Connection.GetDatabase();
            var lista_producto = redisDB.StringGet("ListaDescuentos");
            if (lista_producto != RedisValue.Null)
            {
                lista = JsonConvert.DeserializeObject<List<DescuentoResponseDto>>(lista_producto);
                return lista;
            }
            else
            {
                return new List<DescuentoResponseDto>();
            }
        }

        private bool GuardarLista(List<DescuentoResponseDto> lista)
        {
            bool resultado = false;
            try
            {
                var redisDB = AppDbContext.Connection.GetDatabase();

                //StringSet
                redisDB.StringSet("ListaDescuentos", JsonConvert.SerializeObject(lista));
                redisDB.KeyExpire("ListaDescuentos", new TimeSpan(0, Constants.RediExpire.Minutos, 0));
                resultado = true;
            }
            catch (Exception)
            { }

            return resultado;
        }

        #endregion
    }
}
