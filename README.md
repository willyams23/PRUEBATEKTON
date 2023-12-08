# PRUEBATEKTON
Hola a todos buenas noches. Esta es mi prueba para mi evalucacion en TEKTON. <BR /><BR />

# ARQUITECTURA USADA DDD
_PATRONES UTILIZADOS_ <BR/>
- Singleton <BR/>
- Inyeccion de Dependencia
- CQRS
<BR /><BR />
_PRINICIPIOS_ <BR/>
- SOLID <BR/>
- Clean Code.
<BR /><BR /><BR />
_SOLUCION EXISTE 2 WEB.API_ <BR/>
- 1- TEKTON.Service.Web.API <BR/>
Esta Api es la prueba TEKTON <BR/>
_METODOS: <BR/>
  InicializarProductos *_-->>>>CARGA LOS DATOS EN MEMORIA CACHE_<<<<<--* <BR/>
  ListaProductos  <BR/>
  BuscarProducto  <BR/>
  EliminarProducto  <BR/>
  GrabarProducto  <BR/>
  ActualizarRegistro  <BR/>
- 2.- TEKTON.Service.Web.API.Descuentos <BR/>
Esta Api es la que contiene los datos de DESCUENTO. <BR>
_METODOS: <BR/>
  ListaDescuentos  *_-->>>>CARGA LOS DATOS EN MEMORIA CACHE_<<<<<--* <BR/>
  BuscarDescuento  <BR/>
<BR /><BR />
_CONEXION BD_ <BR/>
- Para esta prueba utlice *LAZY CACHE* configurado para que expiere en 5 minutos<BR/>
- La Entidad "Producto" tienes los siguientes campos: <BR/>
  ProductId <BR/>
  Name <BR/>
  StatusId <BR/>
  StatusName <BR/>
  Stock <BR/>
  Description <BR/>
  Price <BR/>
  PorcentajeDescuento <BR/>
  Peso <BR/>
  Anio <BR/>
  Color <BR/>
  UsuarioRegistro <BR/>
  FechaRegistro <BR/>
  UsuarioActualizacion <BR/>
  DateTime <BR/><BR/>
  2 campos de solo Lectura
  Discount => (Price * PorcentajeDescuento) / 100; <BR/>
  FinalPrice => (Price * (100   PorcentajeDescuento)) / 100; <BR/><BR/>
- La Entidad "Descuento" tienes los siguientes campos: <BR/>
  id <BR/>
  valor <BR/>

  
