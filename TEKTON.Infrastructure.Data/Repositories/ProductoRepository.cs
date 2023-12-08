using AutoMapper;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Collections.Generic;
using TEKTON.Domain.Aggregates.DescuentoAgg;
using TEKTON.Domain.Aggregates.ProductoAgg;
using TEKTON.Infrastructure.Crosscutting;
using TEKTON.Infrastructure.Data.Context;

namespace TEKTON.Infrastructure.Data.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly IMapper _mapper;

        public ProductoRepository(IMapper mapper)
        {
            this._mapper = mapper;
        }

        public Task<ProductoListarResponseReadOnly> InicializarProductos()
        {
            List<ProductoResponseReadOnly> lista = new();

            string[] ArrayColor = new string[] { "Blanco", "Negro", "Azul", "Rojo", "Plata", "Gris", "Marrón", "Verde", "Amarillo", "Blanco", "Negro" };

            for (int i = 1; i <= 5; i++)
            {
                ProductoResponseReadOnly product = new();
                product.ProductId = i;
                product.Name = $"Nombre {i}";

                product.StatusId = Constants.EstadoRegistro.Active;
                product.StatusName = Constants.EstadoName.Active;

                product.Stock = 10 + i;
                product.Description = $"Descripción {i}";

                product.Price = 1850 * i;
                product.PorcentajeDescuento = 10 * i;

                product.Peso = 100 + (10 * i);
                product.Anio = 2023;
                product.Color = ArrayColor[i - 1];

                product.UsuarioRegistro = Constants.Usuario.Default;
                product.FechaRegistro = DateTime.Now;
                product.FechaActualizacion = null;

                lista.Add(product);
            }

            GuardarLista(lista);

            ProductoListarResponseReadOnly resultado = new ProductoListarResponseReadOnly()
            {
                Productos = lista,
                TotalRegistros = lista.Count()
            };

            return Task.FromResult(resultado);
        }

        public Task<ProductoListarResponseReadOnly> ListarProductos()
        {
            ProductoListarResponseReadOnly resultado = new();
            List<ProductoResponseReadOnly>? lista = this.ObtenerLista();

            if (lista != null)
            {
                resultado.Productos = lista;
                resultado.TotalRegistros = lista.Count();
            }
            else {
                resultado.Productos = new(); 
                resultado.TotalRegistros = 0;
            }

            return Task.FromResult(resultado);
        }

        public Task<ProductoResponseReadOnly> BuscarRegistro(int IdProducto)
        {
            ProductoResponseReadOnly? resultado = new();
            List<ProductoResponseReadOnly>? lista = this.ObtenerLista();

            if (lista != null)
            {
                if (lista.Find(x => x.ProductId == IdProducto) != null)
                {
                    resultado = lista.Find(x => x.ProductId == IdProducto);
                }
            }

            return Task.FromResult(resultado);
        }

        public Task<bool> EliminarRegistro(int IdProducto)
        {
            bool resultado = false;
            List<ProductoResponseReadOnly>? lista = this.ObtenerLista();

            if (lista != null)
            {
                if (lista.Find(x => x.ProductId == IdProducto) != null)
                {
                    //Existe
                    List<ProductoResponseReadOnly> listUpdate = lista.FindAll(x => x.ProductId != IdProducto);
                    GuardarLista(listUpdate);
                    resultado = true;
                }
            }
            return Task.FromResult(resultado);
        }


        public Task<int> GrabarRegistro(ProductoRequestReadOnly Producto)
        {
            ProductoResponseReadOnly oNuevoReg = new();
            List<ProductoResponseReadOnly>? lista = this.ObtenerLista();
            int irow = 0;
            int respuesta = 0;

            if (lista != null)
            {
                irow = lista.Count;
            }
            else {
                lista = new List<ProductoResponseReadOnly>();
            }

            try
            {
                oNuevoReg = _mapper.Map<ProductoResponseReadOnly>(Producto);
                //oNuevoReg.ProductId = irow + 1; //Generar ID
                oNuevoReg.StatusName = (oNuevoReg.StatusId == 1 ? Constants.EstadoName.Active : Constants.EstadoName.Inactive);
                oNuevoReg.FechaRegistro = DateTime.Now;
                lista.Add(oNuevoReg);

                GuardarLista(lista);

                respuesta = oNuevoReg.ProductId;
            }
            catch (Exception)
            {
                respuesta = 0;
            }

            return Task.FromResult(respuesta);
        }

        public Task<int> ActualizarRegistro(ProductoRequestReadOnly Producto)
        {
            ProductoResponseReadOnly oActualizarReg = new();
            List<ProductoResponseReadOnly>? lista = this.ObtenerLista();
            List<ProductoResponseReadOnly> listaUpdate = new();

            int respuesta = 0;
            bool existe = false;
            if (lista != null)
            {
                try
                {
                    foreach (ProductoResponseReadOnly item in lista)
                    {
                        if (item.ProductId == Producto.ProductId)
                        {
                            existe = true;

                            oActualizarReg = item;
                            oActualizarReg = _mapper.Map<ProductoResponseReadOnly>(Producto);
                            oActualizarReg.StatusName = (oActualizarReg.StatusId == 1 ? Constants.EstadoName.Active : Constants.EstadoName.Inactive);
                            oActualizarReg.UsuarioRegistro = item.UsuarioRegistro;
                            oActualizarReg.FechaRegistro = item.FechaRegistro;
                            oActualizarReg.FechaActualizacion = DateTime.Now;
                            listaUpdate.Add(oActualizarReg);

                            respuesta = Producto.ProductId;
                        }
                        else {
                            listaUpdate.Add(item);
                        }
                    }

                    GuardarLista(listaUpdate);
                }
                catch (Exception)
                {
                    respuesta = 0;
                }
            }

            if (!existe)
            {
                respuesta = 0;
            }

            return Task.FromResult(respuesta);
        }


        #region Guadar Redis
        private List<ProductoResponseReadOnly>? ObtenerLista()
        {
            List<ProductoResponseReadOnly>? lista = new();

            var redisDB = AppDbContext.Connection.GetDatabase();
            var lista_producto = redisDB.StringGet("ListaProducto");
            if (lista_producto != RedisValue.Null)
            {
                lista = JsonConvert.DeserializeObject<List<ProductoResponseReadOnly>>(lista_producto);
                return lista;
            }
            else {
                return new List<ProductoResponseReadOnly>();
            }
        }

        private bool GuardarLista(List<ProductoResponseReadOnly> lista)
        {
            bool resultado = false;
            try
            {
                var redisDB = AppDbContext.Connection.GetDatabase();
                redisDB.StringSet("ListaProducto", JsonConvert.SerializeObject(lista));
                redisDB.KeyExpire("ListaProducto", new TimeSpan(0, Constants.RediExpire.Minutos, 0));
                resultado = true;
            }
            catch (Exception)
            { }

            return resultado;
        }
       
        #endregion
    }
}
