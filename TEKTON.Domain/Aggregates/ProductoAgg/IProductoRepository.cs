namespace TEKTON.Domain.Aggregates.ProductoAgg
{
    public interface IProductoRepository
    {
        Task<ProductoListarResponseReadOnly> InicializarProductos();
        Task<ProductoListarResponseReadOnly> ListarProductos();
        Task<ProductoResponseReadOnly> BuscarRegistro(int IdProducto);
        Task<bool> EliminarRegistro(int IdProducto);

        Task<int> GrabarRegistro(ProductoRequestReadOnly Producto);
        Task<int> ActualizarRegistro(ProductoRequestReadOnly Producto);

    }
}
