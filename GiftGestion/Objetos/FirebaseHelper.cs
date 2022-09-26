using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GiftGestion.Objetos;
namespace GiftGestion.Objetos
{
    public class FirebaseHelper
    {
        //FirebaseClient firebase = new FirebaseClient("https://gestion-gift-v3-default-rtdb.firebaseio.com");
        FirebaseClient firebase = new FirebaseClient("https://gestion-gift-default-rtdb.firebaseio.com");

        //------------------------PRODUCTOS-----------------------------------------------
        public async Task<List<Producto>> getAllProductos()
        {
            return (await firebase
              .Child("Productos")
              .OnceAsync<Producto>()).Select(item => new Producto
              {
                  id = item.Object.id,
                  nombre_articulo = item.Object.nombre_articulo,
                  descripcion = item.Object.descripcion,
                  estacion = item.Object.estacion,
                  grupo = item.Object.grupo,
                  talle = item.Object.talle,
                  color = item.Object.color,
                  proveedor = item.Object.proveedor,
                  cantidad = item.Object.cantidad,
                  precio_lista = item.Object.precio_lista,
                  precio_efectivo = item.Object.precio_efectivo,
                  costo = item.Object.costo,

                  //----nuevo 
                  deposito = item.Object.deposito,
                  general = item.Object.general,
                  puey = item.Object.puey,
                  stgo = item.Object.stgo,
                  
              }).ToList();
        }

        public async Task updateProductos(List<Producto> productos, string tipo)
        {
            foreach (var producto in productos)
            {
                var toUpdateProducto = (await firebase
                 .Child("Productos")
                 .OnceAsync<Producto>()).Where(a => a.Object.id == producto.id).FirstOrDefault();

                int cant = 0;
                cant = Int32.Parse(toUpdateProducto.Object.cantidad);
                if (tipo.Equals("Entrada")) //aumenta 
                {
                    cant = cant + Int32.Parse(producto.cantidad);
                }
                else if (tipo.Equals("Salida"))
                {
                    cant = cant - Int32.Parse(producto.cantidad);
                }
                await firebase
                  .Child("Productos")
                  .Child(toUpdateProducto.Key)
                  .PutAsync(new Producto()
                  {
                      id = producto.id,
                      nombre_articulo = producto.nombre_articulo,
                      descripcion = producto.descripcion,
                      estacion = producto.estacion,
                      grupo = producto.grupo,
                      talle = producto.talle,
                      color = producto.color,
                      proveedor = producto.proveedor,
                      precio_lista = producto.precio_lista,
                      precio_efectivo = producto.precio_efectivo,
                      costo = producto.costo,
                      cantidad = cant.ToString()
                  });   //chequear      
            }
        }
        //_________________________________________________________________________________________________________________________________
        //_________________________________________________________________________________________________________________________________
        //_________________________________________________________________________________________________________________________________
        public async Task updateProductosV2(List<Producto> productos)
        {
            foreach (var producto in productos)
            {
                var toUpdateProducto = (await firebase
                 .Child("ProductosV2")
                 .OnceAsync<Producto>()).Where(a => a.Object.id == producto.id).FirstOrDefault();


                await firebase
                  .Child("ProductosV2")
                  .Child(toUpdateProducto.Key)
                  .PutAsync(new Producto()
                  {
                      id = producto.id,
                      nombre_articulo = producto.nombre_articulo,
                      descripcion = producto.descripcion,
                      estacion = producto.estacion,
                      grupo = producto.grupo,
                      talle = producto.talle,
                      color = producto.color,
                      proveedor = producto.proveedor,
                      cantidad = producto.cantidad,
                      precio_lista = producto.precio_lista,
                      precio_efectivo = producto.precio_efectivo,
                      costo = producto.costo,
                      deposito = producto.deposito,
                      general = producto.cantidad,
                      puey = producto.puey,
                      stgo = producto.stgo,
                  });   //chequear      
            }
        }

        public async Task<List<Producto>> getAllProductosV2()
        {
            return (await firebase
              .Child("ProductosV2")
              .OnceAsync<Producto>()).Select(item => new Producto
              {
                  id = item.Object.id,
                  nombre_articulo = item.Object.nombre_articulo,
                  descripcion = item.Object.descripcion,
                  estacion = item.Object.estacion,
                  grupo = item.Object.grupo,
                  talle = item.Object.talle,
                  color = item.Object.color,
                  proveedor = item.Object.proveedor,
                  cantidad = item.Object.cantidad,
                  precio_lista = item.Object.precio_lista,
                  precio_efectivo = item.Object.precio_efectivo,
                  costo = item.Object.costo,

                  //----nuevo 
                  deposito = item.Object.deposito,
                  general = item.Object.general,
                  puey = item.Object.puey,
                  stgo = item.Object.stgo,

              }).ToList();
        }
        public async Task addProductos(List<Producto> productos, string general,string deposito,string sucursal,string tipoSucursal)
        {
            foreach (var producto in productos)
            {
                var toUpdateProducto = (await firebase
                 .Child("ProductosV2")
                 .OnceAsync<Producto>()).Where(a => a.Object.id == producto.id).FirstOrDefault();
                int gral = 0;
                int dep = 0;
                int stgo = 0;
                int puey = 0;

                if (toUpdateProducto!=null)
                {
                    gral = Int32.Parse(toUpdateProducto.Object.general);              
                    dep = Int32.Parse(toUpdateProducto.Object.deposito);

                    if (general.Equals("+"))
                    {
                        gral = gral + Int32.Parse(producto.general);
                    }
                    else if (general.Equals("-"))
                    {
                        gral = gral - Int32.Parse(producto.general);
                    }

                    if (deposito.Equals("+"))
                    {
                        dep = dep + Int32.Parse(producto.deposito);
                    }
                    else if (deposito.Equals("-"))
                    {
                        dep = dep - Int32.Parse(producto.deposito);
                    }
                    puey = Int32.Parse(toUpdateProducto.Object.puey);
                    stgo = Int32.Parse(toUpdateProducto.Object.stgo);
                    switch (sucursal)
                    {
                        case "Pueyrredon":
                          
                            if (tipoSucursal.Equals("+"))
                            {
                                puey = puey + Int32.Parse(producto.puey);
                            }
                            else if (tipoSucursal.Equals("-"))
                            {
                                puey = puey - Int32.Parse(producto.puey);
                            }
                            break;
                        case "Stgo del Estero":
                           
                            if (tipoSucursal.Equals("+"))
                            {
                                stgo = stgo + Int32.Parse(producto.stgo);
                            }
                            else if (tipoSucursal.Equals("-"))
                            {
                                stgo = stgo - Int32.Parse(producto.stgo);
                            }
                            break;
                    }
                }
                else
                {
                    puey = Int32.Parse(producto.puey);
                    stgo = Int32.Parse(producto.stgo);
                    gral = Int32.Parse(producto.general);
                    dep = Int32.Parse(producto.deposito);
                }

                if (!general.Equals("+") || !general.Equals("-"))
                {
                   
                }
                if (!deposito.Equals("+") || !deposito.Equals("-"))
                {
                    
                }
               

                if (toUpdateProducto != null)
                {
                    await firebase
                     .Child("ProductosV2")
                     .Child(toUpdateProducto.Key)
                     .PutAsync(new Producto()
                     {
                         id = producto.id,
                         nombre_articulo = producto.nombre_articulo,
                         descripcion = producto.descripcion,
                         estacion = producto.estacion,
                         grupo = producto.grupo,
                         talle = producto.talle,
                         color = producto.color,
                         proveedor = producto.proveedor,
                         cantidad = producto.cantidad,
                         precio_lista = producto.precio_lista,
                         precio_efectivo = producto.precio_efectivo,
                         costo = producto.costo,

                        //----nuevo 
                         deposito = dep.ToString(),
                         general = gral.ToString(),
                         puey = puey.ToString(),
                         stgo = stgo.ToString(),
                     });
                }
                else
                {
                    await firebase
                     .Child("ProductosV2")
                     .PostAsync(new Producto()
                     {
                         id = producto.id,
                         nombre_articulo = producto.nombre_articulo,
                         descripcion = producto.descripcion,
                         estacion = producto.estacion,
                         grupo = producto.grupo,
                         talle = producto.talle,
                         color = producto.color,
                         proveedor = producto.proveedor,
                         cantidad = producto.cantidad,
                         precio_lista = producto.precio_lista,
                         precio_efectivo = producto.precio_efectivo,
                         costo = producto.costo,

                         //----nuevo 
                         deposito = dep.ToString(),
                         general = gral.ToString(),
                         puey = puey.ToString(),
                         stgo = stgo.ToString(),
                     });
                }
            }
        }
        //_________________________________________________________________________________________________________________________________
        //_________________________________________________________________________________________________________________________________
        //_________________________________________________________________________________________________________________________________
        public async Task addProducto(Producto producto)    //si existe el producto lo updatea, si no existe crea uno nuevo
        {
            var toUpdateProducto = (await firebase
              .Child("Productos")
              .OnceAsync<Producto>()).Where(a => a.Object.id == producto.id).FirstOrDefault();

            if (toUpdateProducto != null)
            {
                await firebase
                 .Child("Productos")
                 .Child(toUpdateProducto.Key)
                 .PutAsync(new Producto()
                 {
                     id = producto.id,
                     nombre_articulo = producto.nombre_articulo,
                     descripcion = producto.descripcion,
                     estacion = producto.estacion,
                     grupo = producto.grupo,
                     talle = producto.talle,
                     color = producto.color,
                     proveedor = producto.proveedor,
                     cantidad = producto.cantidad,
                     precio_lista = producto.precio_lista,
                     precio_efectivo = producto.precio_efectivo,
                     costo = producto.costo,

                     //----nuevo 
                     deposito = producto.deposito,
                     general = producto.general,
                     puey = producto.puey,
                     stgo = producto.stgo,
                 });
            }
            else
            {
                await firebase
                 .Child("Productos")
                 .PostAsync(new Producto()
                 {
                     id = producto.id,
                     nombre_articulo = producto.nombre_articulo,
                     descripcion = producto.descripcion,
                     estacion = producto.estacion,
                     grupo = producto.grupo,
                     talle = producto.talle,
                     color = producto.color,
                     proveedor = producto.proveedor,
                     cantidad = producto.cantidad,
                     precio_lista = producto.precio_lista,
                     precio_efectivo = producto.precio_efectivo,
                     costo = producto.costo,

                      //----nuevo 
                      deposito = producto.deposito,
                     general = producto.general,
                     puey = producto.puey,
                     stgo = producto.stgo,
                 });
            }  
        }

        public async Task<Producto> getProducto(string id)
        {
            var allProductos = await getAllProductos();
            await firebase
              .Child("Productos")
              .OnceAsync<Producto>();
            return allProductos.Where(a => a.id == id).FirstOrDefault();
        }


        public async Task updateProducto(string id, string nombre_articulo, string descripcion, string estacion, string grupo,
       string talle, string color, string proveedor, string cantidad, string precio_lista, string precio_efectivo, string costo)
        {
            var toUpdateProducto = (await firebase
              .Child("Productos")
              .OnceAsync<Producto>()).Where(a => a.Object.id == id).FirstOrDefault();

            if (toUpdateProducto != null)
            {
                await firebase
                 .Child("Productos")
                 .Child(toUpdateProducto.Key)
                 .PutAsync(new Producto()
                 {
                     id = id,
                     nombre_articulo = nombre_articulo,
                     descripcion = descripcion,
                     estacion = estacion,
                     grupo = grupo,
                     talle = talle,
                     color = color,
                     proveedor = proveedor,
                     cantidad = cantidad,
                     precio_lista = precio_lista,
                     precio_efectivo = precio_efectivo,
                     costo = costo
                 });
            }
            else
            {

            }
        }

        public async Task deleteProducto(string id)
        {
            var toDeleteProducto = (await firebase
              .Child("Productos")
              .OnceAsync<Producto>()).Where(a => a.Object.id == id).FirstOrDefault();
            await firebase.Child("Productos").Child(toDeleteProducto.Key).DeleteAsync();
        }





        public async Task<List<Producto>> getAllProductosSucursal(string sucursal)
        {

            return (await firebase
              .Child("Sucursales")
              .Child(sucursal)
              .Child("Productos")
              .OnceAsync<Producto>()).Select(item => new Producto
              {
                  id = item.Object.id,
                  nombre_articulo = item.Object.nombre_articulo,
                  descripcion = item.Object.descripcion,
                  estacion = item.Object.estacion,
                  grupo = item.Object.grupo,
                  talle = item.Object.talle,
                  color = item.Object.color,
                  proveedor = item.Object.proveedor,
                  cantidad = item.Object.cantidad,
                  precio_lista = item.Object.precio_lista,
                  precio_efectivo = item.Object.precio_efectivo,
                  costo = item.Object.costo,
              }).ToList();
        }

     

        public async Task updateProductoDetalleGRUPO(Producto producto, string grupo)
        {
            var toUpdateProducto = (await firebase
              .Child("DetalleVenta")
              .OnceAsync<Producto>()).Where(a => a.Object.id == producto.id).FirstOrDefault();

            if (toUpdateProducto != null)
            {
                await firebase
                 .Child("DetalleVenta")
                 .Child(toUpdateProducto.Key)
                 .PutAsync(new Producto()
                 {
                     id = producto.id,
                     nombre_articulo = producto.nombre_articulo,
                     descripcion = producto.descripcion,
                     estacion = producto.estacion,
                     grupo = grupo,
                     talle = producto.talle,
                     color = producto.color,
                     proveedor = producto.proveedor,
                     cantidad = producto.cantidad,
                     precio_lista = producto.precio_lista,
                     precio_efectivo = producto.precio_efectivo,
                     costo = producto.costo,
                     precio = producto.precio,
                     foranea = producto.foranea,
                 });
            }
            else
            {

            }
        }

        public async Task updateProductoGRUPO(Producto producto, string grupo)
        {
            var toUpdateProducto = (await firebase
              .Child("Productos")
              .OnceAsync<Producto>()).Where(a => a.Object.id == producto.id).FirstOrDefault();

            if (toUpdateProducto != null)
            {
                await firebase
                 .Child("Productos")
                 .Child(toUpdateProducto.Key)
                 .PutAsync(new Producto()
                 {
                     id = producto.id,
                     nombre_articulo = producto.nombre_articulo,
                     descripcion = producto.descripcion,
                     estacion = producto.estacion,
                     grupo = grupo,
                     talle = producto.talle,
                     color = producto.color,
                     proveedor = producto.proveedor,
                     cantidad = producto.cantidad,
                     precio_lista = producto.precio_lista,
                     precio_efectivo = producto.precio_efectivo,
                     costo = producto.costo
                 });
            }
            else
            {

            }
        }
        public async Task updateProductoOC(string id, string nombre_articulo, string descripcion, string estacion, string grupo,
           string talle, string color, string proveedor, string cantidad, string precio_lista, string precio_efectivo, string costo)
        {
            var toUpdateProducto = (await firebase
              .Child("Productos")
              .OnceAsync<Producto>()).Where(a => a.Object.id == id).FirstOrDefault();

            if (toUpdateProducto != null)
            {
                await firebase
                 .Child("Productos")
                 .Child(toUpdateProducto.Key)
                 .PutAsync(new Producto()
                 {
                     id = id,
                     nombre_articulo = nombre_articulo,
                     descripcion = descripcion,
                     estacion = estacion,
                     grupo = grupo,
                     talle = talle,
                     color = color,
                     proveedor = proveedor,
                     cantidad = toUpdateProducto.Object.cantidad,
                     precio_lista = precio_lista,
                     precio_efectivo = precio_efectivo,
                     costo = costo
                 });
            }
            else
            {
                await firebase
                  .Child("Productos")
                  .PostAsync(new Producto()
                  {
                      id = id,
                      nombre_articulo = nombre_articulo,
                      descripcion = descripcion,
                      estacion = estacion,
                      grupo = grupo,
                      talle = talle,
                      color = color,
                      proveedor = proveedor,
                      cantidad = "0",
                      precio_lista = precio_lista,
                      precio_efectivo = precio_efectivo,
                      costo = costo
                  });
            }
        }

        public async Task updateDeposit(string id, string nombre_articulo, string descripcion, string estacion, string grupo,
          string talle, string color, string proveedor, string cantidad, string precio_lista, string precio_efectivo, string costo)
        {
            var toUpdateProducto = (await firebase
              .Child("Deposito")
              .OnceAsync<Producto>()).Where(a => a.Object.id == id).FirstOrDefault();

            if (toUpdateProducto != null)
            {
                await firebase
                 .Child("Deposito")
                 .Child(toUpdateProducto.Key)
                 .PutAsync(new Producto()
                 {
                     id = id,
                     nombre_articulo = nombre_articulo,
                     descripcion = descripcion,
                     estacion = estacion,
                     grupo = grupo,
                     talle = talle,
                     color = color,
                     proveedor = proveedor,
                     cantidad = cantidad,
                     precio_lista = precio_lista,
                     precio_efectivo = precio_efectivo,
                     costo = costo
                 });
            }
            else
            {

            }
        }






        //----------------DEPOSITO---------------------
        public async Task<Producto> getDeposito(string id)
        {
            var allProductos = await getAllDeposito();
            await firebase
              .Child("Deposito")
              .OnceAsync<Producto>();
            return allProductos.Where(a => a.id == id).FirstOrDefault();
        }

        public async Task addDeposito(string id, string nombre_articulo, string descripcion, string estacion, string grupo,
           string talle, string color, string proveedor, string cantidad, string precio_lista, string precio_efectivo, string costo)
        {
            await firebase
              .Child("Deposito")
              .PostAsync(new Producto()
              {
                  id = id,
                  nombre_articulo = nombre_articulo,
                  descripcion = descripcion,
                  estacion = estacion,
                  grupo = grupo,
                  talle = talle,
                  color = color,
                  proveedor = proveedor,
                  cantidad = cantidad,
                  precio_lista = precio_lista,
                  precio_efectivo = precio_efectivo,
                  costo = costo
              });
        }

        public async Task<List<Producto>> getAllDeposito()
        {
            return (await firebase
              .Child("Deposito")
              .OnceAsync<Producto>()).Select(item => new Producto
              {
                  id = item.Object.id,
                  nombre_articulo = item.Object.nombre_articulo,
                  descripcion = item.Object.descripcion,
                  estacion = item.Object.estacion,
                  grupo = item.Object.grupo,
                  talle = item.Object.talle,
                  color = item.Object.color,
                  proveedor = item.Object.proveedor,
                  cantidad = item.Object.cantidad,
                  precio_lista = item.Object.precio_lista,
                  precio_efectivo = item.Object.precio_efectivo,
                  costo = item.Object.costo
              }).ToList();
        }


        public async Task updateDeposito(List<Producto> productos, string tipo)
        {
            foreach (var producto in productos)
            {
                var toUpdateProducto = (await firebase
                 .Child("Deposito")
                 .OnceAsync<Producto>()).Where(a => a.Object.id == producto.id).FirstOrDefault();
                if (toUpdateProducto != null)
                {
                    int cant = 0;
                    cant = Int32.Parse(toUpdateProducto.Object.cantidad);
                    if (tipo.Equals("Entrada"))
                    {
                        cant = cant + Int32.Parse(producto.cantidad);
                    }
                    else if (tipo.Equals("Salida"))
                    {
                        cant = cant - Int32.Parse(producto.cantidad);
                    }
                    await firebase
                      .Child("Deposito")
                      .Child(toUpdateProducto.Key)
                      .PutAsync(new Producto()
                      {
                          id = producto.id,
                          nombre_articulo = producto.nombre_articulo,
                          descripcion = producto.descripcion,
                          estacion = producto.estacion,
                          grupo = producto.grupo,
                          talle = producto.talle,
                          color = producto.color,
                          proveedor = producto.proveedor,
                          precio_lista = producto.precio_lista,
                          precio_efectivo = producto.precio_efectivo,
                          cantidad = cant.ToString(),
                          costo = producto.costo
                      });   //chequear 
                }
                else
                {
                    await firebase
                   .Child("Deposito")
                   .PostAsync(new Producto()
                   {
                       id = producto.id,
                       nombre_articulo = producto.nombre_articulo,
                       descripcion = producto.descripcion,
                       estacion = producto.estacion,
                       grupo = producto.grupo,
                       talle = producto.talle,
                       color = producto.color,
                       proveedor = producto.proveedor,
                       precio_lista = producto.precio_lista,
                       precio_efectivo = producto.precio_efectivo,
                       cantidad = producto.cantidad,
                       costo = producto.costo

                   });
                }
            }
        }


        public async Task updateProductoGRUPOSUCURSAL(Producto producto, string grupo, string sucursal)
        {
            var toUpdateProducto = (await firebase
               .Child("Sucursales")
              .Child(sucursal)
              .Child("Productos")
              .OnceAsync<Producto>()).Where(a => a.Object.id == producto.id).FirstOrDefault();

            if (toUpdateProducto != null)
            {
                await firebase
                .Child("Sucursales")
                  .Child(sucursal)
                  .Child("Productos")
                 .Child(toUpdateProducto.Key)
                 .PutAsync(new Producto()
                 {
                     id = producto.id,
                     nombre_articulo = producto.nombre_articulo,
                     descripcion = producto.descripcion,
                     estacion = producto.estacion,
                     grupo = grupo,
                     talle = producto.talle,
                     color = producto.color,
                     proveedor = producto.proveedor,
                     cantidad = producto.cantidad,
                     precio_lista = producto.precio_lista,
                     precio_efectivo = producto.precio_efectivo,
                     costo = producto.costo
                 });
            }
            else
            {

            }
        }

        public async Task updateProductoSucursal(string id, string nombre_articulo, string descripcion, string estacion, string grupo,
       string talle, string color, string proveedor, string cantidad, string precio_lista, string precio_efectivo, string costo, string sucursal)
        {
            var toUpdateProducto = (await firebase
              .Child("Sucursales")
              .Child(sucursal)
              .Child("Productos")
              .OnceAsync<Producto>()).Where(a => a.Object.id == id).FirstOrDefault();

            if (toUpdateProducto != null)
            {
                await firebase
                  .Child("Sucursales")
                  .Child(sucursal)
                  .Child("Productos")
                 .Child(toUpdateProducto.Key)
                 .PutAsync(new Producto()
                 {
                     id = id,
                     nombre_articulo = nombre_articulo,
                     descripcion = descripcion,
                     estacion = estacion,
                     grupo = grupo,
                     talle = talle,
                     color = color,
                     proveedor = proveedor,
                     cantidad = cantidad,
                     precio_lista = precio_lista,
                     precio_efectivo = precio_efectivo,
                     costo = costo
                 });
            }
        }

        public async Task updateProductosSucursal(string destino, List<Producto> productos, string tipo)
        {
            foreach (var producto in productos)
            {
                var toUpdateProducto = (await firebase
                    .Child("Sucursales")
                    .Child(destino)
                    .Child("Productos")
                    .OnceAsync<Producto>()).Where(a => a.Object.id == producto.id).FirstOrDefault();

                if (toUpdateProducto != null)
                {
                    int cant = Int32.Parse(toUpdateProducto.Object.cantidad);
                    if (tipo.Equals("Entrada"))
                    {
                        cant = cant + Int32.Parse(producto.cantidad);
                    }
                    else if (tipo.Equals("Salida"))
                    {
                        cant = cant - Int32.Parse(producto.cantidad);
                    }

                    await firebase
                      .Child("Sucursales")
                      .Child(destino)
                      .Child("Productos")
                      .Child(toUpdateProducto.Key)
                      .PutAsync(new Producto()
                      {
                          id = producto.id,
                          nombre_articulo = producto.nombre_articulo,
                          descripcion = producto.descripcion,
                          estacion = producto.estacion,
                          grupo = producto.grupo,
                          talle = producto.talle,
                          color = producto.color,
                          proveedor = producto.proveedor,
                          cantidad = cant.ToString(),
                          precio_lista = producto.precio_lista,
                          precio_efectivo = producto.precio_efectivo,
                          costo = producto.costo
                      });   //chequear
                }
                else
                {
                    await firebase
                     .Child("Sucursales")
                     .Child(destino)
                     .Child("Productos")
                     .PostAsync(new Producto()
                     {
                         id = producto.id,
                         nombre_articulo = producto.nombre_articulo,
                         descripcion = producto.descripcion,
                         estacion = producto.estacion,
                         grupo = producto.grupo,
                         talle = producto.talle,
                         color = producto.color,
                         proveedor = producto.proveedor,
                         cantidad = producto.cantidad,
                         precio_lista = producto.precio_lista,
                         precio_efectivo = producto.precio_efectivo,
                         costo = producto.costo
                     });
                }
            }
        }

        //----------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------
        public async Task<string> getVentaID(string id)
        {
            var toUpdateProducto = (await firebase
          .Child("Ventas")
          .OnceAsync<Venta>()).Where(a => a.Object.id == id).FirstOrDefault();

            return toUpdateProducto.Key;
        }
        public async Task<string> getProductoID(string id)
        {
            var toUpdateProducto = (await firebase
          .Child("ProductosV2")
          .OnceAsync<Producto>()).Where(a => a.Object.id == id).FirstOrDefault();

            return toUpdateProducto.Key;
        }

        public async Task updateProducto(Producto producto)
        {
            await firebase
                 .Child("ProductosV2")
                 .Child(producto.id)
                 .PutAsync(new Producto()
                 {
                     id = producto.id,
                     nombre_articulo = producto.nombre_articulo,
                     descripcion = producto.descripcion,
                     estacion = producto.estacion,
                     grupo = producto.grupo,
                     talle = producto.talle,
                     color = producto.color,
                     proveedor = producto.proveedor,
                     cantidad = producto.cantidad,
                     precio_lista = producto.precio_lista,
                     precio_efectivo = producto.precio_efectivo,
                     costo = producto.costo,
                     deposito = producto.deposito,
                     general = producto.general,
                     puey = producto.puey,
                     stgo = producto.stgo,
                 });
        } 
        public async Task<string> getProductoDetalleVenta(string id)
        {
            var toUpdateProducto = (await firebase
          .Child("DetalleVenta")
          .OnceAsync<Producto>()).Where(a => a.Object.foranea == id).FirstOrDefault();

            return toUpdateProducto.Key;
        }
        /*
        public async Task<string> getProductoIDDeposito(string id)
        {
            var toUpdateProducto = (await firebase
          .Child("Deposito")
          .OnceAsync<Producto>()).Where(a => a.Object.id == id).FirstOrDefault();

            return toUpdateProducto.Key;
        }*/
        public async Task<string> getProductoIDRemito(string id)
        {
            var toUpdateProducto = (await firebase
          .Child("DetalleRemito")
          .OnceAsync<Producto>()).Where(a => a.Object.id == id).FirstOrDefault();

            return toUpdateProducto.Key;
        }
        public async Task<String> getProductoSucursal(string id, string destino)
        {
            string retorno = "";
            var toUpdateProducto = (await firebase
         .Child("Sucursales")
         .Child(destino)
              .Child("Productos")
         .OnceAsync<Producto>()).Where(a => a.Object.id == id).FirstOrDefault();

            if (toUpdateProducto != null)
            {
                retorno = toUpdateProducto.Key;
            }
            return retorno;

        }
        //----------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------
   
        //-----------------------REMITOS-----------------------------------------------
        public async Task<List<Remito>> getAllRemitos()
        {

            return (await firebase
              .Child("Remitos")
              .OnceAsync<Remito>()).Select(item => new Remito
              {
                  id = item.Object.id,
                  fecha = item.Object.fecha,
                  hora = item.Object.hora,
                  tipo = item.Object.tipo,
                  observacion = item.Object.observacion,
                  destino = item.Object.destino,
                  estado = item.Object.estado,
                  observacion_eliminacion = item.Object.observacion_eliminacion,
                  foraneaOC = item.Object.foraneaOC

              }).ToList();
        }
        public async Task addDetalleRemito(string id, List<Producto> productos)
        {
            foreach (var producto in productos)
            {
                await firebase
                  .Child("DetalleRemito")
                  .PostAsync(new Producto()
                  {
                      id = producto.id,
                      foranea = id,
                      nombre_articulo = producto.nombre_articulo,
                      descripcion = producto.descripcion,
                      estacion = producto.estacion,
                      grupo = producto.grupo,
                      talle = producto.talle,
                      color = producto.color,
                      proveedor = producto.proveedor,
                      cantidad = producto.cantidad,
                      precio_lista = producto.precio_lista,
                      precio_efectivo = producto.precio_efectivo,
                      costo = producto.costo
                  });
            }
        }
        public async Task addRemito(string id, string fecha, string hora, string tipo, string observacion,
            string destino, string estado, string observacion_eliminacion, List<Producto> productos, string idOrdenCompra)
        {
            await firebase
              .Child("Remitos")
              .PostAsync(new Remito()
              {
                  id = id,
                  fecha = fecha,
                  hora = hora,
                  tipo = tipo,
                  observacion = observacion,
                  destino = destino,
                  estado = estado,
                  observacion_eliminacion = observacion_eliminacion,
                  foraneaOC = idOrdenCompra
              });
        }

        public async Task updateRemito(string id, string fecha, string hora, string tipo, string observacion,
            string destino, string estado)
        {
            var toUpdateProducto = (await firebase
              .Child("Remitos")
              .OnceAsync<Remito>()).Where(a => a.Object.id == id).FirstOrDefault();

            await firebase
              .Child("Remitos")
              .Child(toUpdateProducto.Key)
              .PutAsync(new Remito()
              {
                  id = id,
                  fecha = fecha,
                  hora = hora,
                  tipo = tipo,
                  observacion = observacion,
                  destino = destino,
                  estado = estado,
                  observacion_eliminacion = "",
                  foraneaOC = ""
              });
        }
        public async Task<Remito> getRemito(string id)
        {
            var allRemitos = await getAllRemitos();
            await firebase
              .Child("Remitos")
              .OnceAsync<Remito>();
            return allRemitos.Where(a => a.id == id).FirstOrDefault();
        }



        public async Task deleteRemito(string id)
        {
            var toDeleteProducto = (await firebase
              .Child("Remitos")
              .OnceAsync<Remito>()).Where(a => a.Object.id == id).FirstOrDefault();
            await firebase.Child("Remitos").Child(toDeleteProducto.Key).DeleteAsync();
        }
        //-------------------------DETALLE REMITO---------------------------------------------------
        public async Task<Producto> getDetalleRemito(string id)
        {
            var allRemitos = await getAllDetalleRemito();
            await firebase
              .Child("DetalleRemito")
              //.Child(id)
              .OnceAsync<Producto>();
            return allRemitos.Where(a => a.id == id).FirstOrDefault();
        }

        public async Task<List<Producto>> getAllDetalleRemito()
        {

            return (await firebase
              .Child("DetalleRemito")
              .OnceAsync<Producto>()).Select(item => new Producto
              {
                  id = item.Object.id,
                  foranea = item.Object.foranea,
                  nombre_articulo = item.Object.nombre_articulo,
                  descripcion = item.Object.descripcion,
                  estacion = item.Object.estacion,
                  grupo = item.Object.grupo,
                  talle = item.Object.talle,
                  color = item.Object.color,
                  proveedor = item.Object.proveedor,
                  cantidad = item.Object.cantidad,
                  precio_lista = item.Object.precio_lista,
                  precio_efectivo = item.Object.precio_efectivo,
                  costo = item.Object.costo

              }).ToList();
        }


        //---------------------------USUARIO-----------------------------------------------
        //---------------------------USUARIO-----------------------------------------------
        //---------------------------USUARIO-----------------------------------------------
        //---------------------------USUARIO-----------------------------------------------
        //---------------------------USUARIO-----------------------------------------------

        public async Task<List<Usuario>> getAllUsuario()
        {

            return (await firebase
              .Child("Usuarios")
              .OnceAsync<Usuario>()).Select(item => new Usuario
              {
                  dni = item.Object.dni,
                  nombre = item.Object.nombre,
                  apellido = item.Object.apellido,
                  rol = item.Object.rol,
                  sucursal = item.Object.sucursal,
                  contraseña = item.Object.contraseña,
                  mail = item.Object.mail

              }).ToList();
        }
        public async Task addUsuario(string dni, string nombre, string apellido, string rol, string sucursal, string contrseña, string mail)
        {
            await firebase
              .Child("Usuarios")
              .PostAsync(new Usuario()
              {
                  dni = dni,
                  nombre = nombre,
                  apellido = apellido,
                  rol = rol,
                  sucursal = sucursal,
                  contraseña = contrseña,
                  mail = mail,
              });
        }

        public async Task<Usuario> getUsuario(string dni)
        {
            var allProductos = await getAllUsuario();
            await firebase
              .Child("Usuarios")
              .OnceAsync<Usuario>();
            return allProductos.Where(a => a.dni == dni).FirstOrDefault();
        }

        public async Task updateUsuario(string dni, string nombre, string apellido, string rol, string sucursal, string contrseña, string mail)
        {
            var toUpdateUsuario = (await firebase
              .Child("Usuarios")
              .OnceAsync<Usuario>()).Where(a => a.Object.dni == dni).FirstOrDefault();

            if (toUpdateUsuario != null)
            {

                await firebase
                 .Child("Usuarios")
                 .Child(toUpdateUsuario.Key)
                 .PutAsync(new Usuario() {
                     dni = dni,
                     nombre = nombre,
                     apellido = apellido,
                     rol = rol,
                     sucursal = sucursal,
                     contraseña = contrseña,
                     mail = mail,
                 });
            }
            else
            {
                await firebase
                 .Child("Usuarios")
                 .PostAsync(new Usuario()
                 {
                     dni = dni,
                     nombre = nombre,
                     apellido = apellido,
                     rol = rol,
                     sucursal = sucursal,
                     contraseña = contrseña,
                     mail = mail
                 });
            }

        }

        public async Task deleteUsuario(string dni)
        {
            var toDeleteProducto = (await firebase
              .Child("Usuarios")
              .OnceAsync<Usuario>()).Where(a => a.Object.dni == dni).FirstOrDefault();
            await firebase.Child("Usuarios").Child(toDeleteProducto.Key).DeleteAsync();
        }

        //---------------------------CLIENTES-----------------------------------------------
        //---------------------------CLIENTES-----------------------------------------------
        //---------------------------CLIENTES-----------------------------------------------
        //---------------------------CLIENTES-----------------------------------------------
        //---------------------------CLIENTES-----------------------------------------------
        public async Task<List<Cliente>> getAllClientes()
        {

            return (await firebase
              .Child("Clientes")
              .OnceAsync<Cliente>()).Select(item => new Cliente
              {
                  dnicuit = item.Object.dnicuit,
                  nombre = item.Object.nombre,
                  telefono = item.Object.telefono,
                  email = item.Object.email,
                  situacion_fiscal = item.Object.situacion_fiscal,


              }).ToList();
        }
        public async Task addCliente(string dnicuit, string nombre, string telefono, string email, string situacion_fiscal)
        {
            await firebase
              .Child("Clientes")
              .PostAsync(new Cliente()
              {
                  dnicuit = dnicuit,
                  nombre = nombre,
                  telefono = telefono,
                  email = email,
                  situacion_fiscal = situacion_fiscal
              });
        }

        public async Task<Cliente> getCliente(string dnicuit)
        {
            var allProductos = await getAllClientes();
            await firebase
              .Child("Clientes")
              .OnceAsync<Cliente>();
            return allProductos.Where(a => a.dnicuit == dnicuit).FirstOrDefault();
        }

        public async Task updateCliente(string dnicuit, string nombre, string telefono, string email, string situacion_fiscal)
        {
            var toUpdateCliente = (await firebase
              .Child("Clientes")
              .OnceAsync<Cliente>()).Where(a => a.Object.dnicuit == dnicuit).FirstOrDefault();

            if (toUpdateCliente != null)
            {
                await firebase
                .Child("Clientes")
                .Child(toUpdateCliente.Key)
                .PutAsync(new Cliente()
                {
                    dnicuit = dnicuit,
                    nombre = nombre,
                    telefono = telefono,
                    email = email,
                    situacion_fiscal = situacion_fiscal
                });
            }
            else
            {
                await firebase
               .Child("Clientes")
               .PostAsync(new Cliente()
               {
                   dnicuit = dnicuit,
                   nombre = nombre,
                   telefono = telefono,
                   email = email,
                   situacion_fiscal = situacion_fiscal
               });
            }

        }

        public async Task deleteCliente(string dni)
        {
            var toDeleteProducto = (await firebase
              .Child("Clientes")
              .OnceAsync<Usuario>()).Where(a => a.Object.dni == dni).FirstOrDefault();
            await firebase.Child("Clientes").Child(toDeleteProducto.Key).DeleteAsync();
        }

        //---------------------------VENTA-----------------------------------------------
        //---------------------------VENTA-----------------------------------------------
        //---------------------------VENTA-----------------------------------------------
        //---------------------------VENTA-----------------------------------------------

        public async Task<List<Venta>> getAllVentas()
        {

            return (await firebase
              .Child("Ventas")
              .OnceAsync<Venta>()).Select(item => new Venta
              {
                  id = item.Object.id,
                  fecha = item.Object.fecha,
                  hora = item.Object.hora,
                  nombre_empleado = item.Object.nombre_empleado,
                  nombre_sucursal = item.Object.nombre_sucursal,
                  nombre_cliente = item.Object.nombre_cliente,
                  observacion = item.Object.observacion,
                  estado = item.Object.estado,
                  tipo_pago = item.Object.tipo_pago,
                  total = item.Object.total,
                  ganancia = item.Object.ganancia

              }).ToList();
        }
        public async Task addVenta(string id, string fecha, string hora, string nombre_empleado, string nombre_sucursal
            , string nombre_cliente, string observacion, string estado, string tipo_pago, string total, string ganancia)
        {
            await firebase
              .Child("Ventas")
              .PostAsync(new Venta()
              {
                  id = id,
                  fecha = fecha,
                  hora = hora,
                  nombre_empleado = nombre_empleado,
                  nombre_sucursal = nombre_sucursal,
                  nombre_cliente = nombre_cliente,
                  observacion = observacion,
                  estado = estado,
                  tipo_pago = tipo_pago,
                  total = total,
                  ganancia = ganancia,

              });
        }

        public async Task<Venta> getVenta(string id)
        {
            var allProductos = await getAllVentas();
            await firebase
              .Child("Ventas")
              .OnceAsync<Venta>();
            return allProductos.Where(a => a.id == id).FirstOrDefault();
        }

        public async Task updateVenta(string id, string fecha, string hora, string nombre_empleado, string nombre_sucursal
            , string nombre_cliente, string observacion, string estado, string tipo_pago, string total, string ganancia)
        {
            var toUpdateProducto = (await firebase
              .Child("Ventas")
              .OnceAsync<Venta>()).Where(a => a.Object.id == id).FirstOrDefault();

            await firebase
              .Child("Ventas")
              .Child(toUpdateProducto.Key)
              .PutAsync(new Venta()
              {
                  id = id,
                  fecha = fecha,
                  hora = hora,
                  nombre_empleado = nombre_empleado,
                  nombre_sucursal = nombre_sucursal,
                  nombre_cliente = nombre_cliente,
                  observacion = observacion,
                  estado = estado,
                  tipo_pago = tipo_pago,
                  total = total,
                  ganancia = ganancia,
              });
        }

        public async Task deleteVenta(string id)
        {
            var toDeleteProducto = (await firebase
              .Child("Ventas")
              .OnceAsync<Venta>()).Where(a => a.Object.id == id).FirstOrDefault();
            await firebase.Child("Ventas").Child(toDeleteProducto.Key).DeleteAsync();
        }


        //-------------------------------DETALLE ---------------------------------------------------
        public async Task<List<Producto>> getAllDetalleVenta()//string id
        {

            return (await firebase
              .Child("DetalleVenta")
              .OnceAsync<Producto>()).Select(item => new Producto
              {
                  foranea = item.Object.foranea,
                  id = item.Object.id,
                  nombre_articulo = item.Object.nombre_articulo,
                  descripcion = item.Object.descripcion,
                  estacion = item.Object.estacion,
                  grupo = item.Object.grupo,
                  talle = item.Object.talle,
                  color = item.Object.color,
                  proveedor = item.Object.proveedor,
                  precio = item.Object.precio,
                  cantidad = item.Object.cantidad,

                  costo = item.Object.costo,
                  precio_lista = item.Object.precio_lista,
                  precio_efectivo = item.Object.precio_efectivo,

              }).ToList();
        }
        public async Task addDetalleVenta(string id, List<Producto> productos)
        {
            foreach (var producto in productos)
            {
                await firebase
                  .Child("DetalleVenta")
                  //.Child(id)
                  .PostAsync(new Producto()
                  {
                      foranea = id,
                      id = producto.id,
                      nombre_articulo = producto.nombre_articulo,
                      descripcion = producto.descripcion,
                      estacion = producto.estacion,
                      grupo = producto.grupo,
                      talle = producto.talle,
                      color = producto.color,
                      proveedor = producto.proveedor,
                      precio = producto.precio,
                      cantidad = producto.cantidad,

                      costo = producto.costo,
                      precio_lista = producto.precio_lista,
                      precio_efectivo = producto.precio_efectivo,
                  });
            }
        }
        public async Task deleteDetalleVenta(string idVenta)
        {
            var toUpdateProducto = (await firebase
              .Child("DetalleVenta")
              .OnceAsync<Producto>()).Where(a => a.Object.foranea == idVenta).FirstOrDefault();
            if (toUpdateProducto != null)
            {
                await firebase.Child("DetalleVenta").Child(toUpdateProducto.Key).DeleteAsync();
            }

        }
        public async Task updateDetalleVenta(string id, List<Producto> productos)
        {
            foreach (var producto in productos)
            {
                await firebase
                  .Child("DetalleVentas")
                  .Child(id)
                  .PutAsync(new Producto()
                  {
                      id = producto.id,
                      nombre_articulo = producto.nombre_articulo,
                      descripcion = producto.descripcion,
                      estacion = producto.estacion,
                      grupo = producto.grupo,
                      talle = producto.talle,
                      color = producto.color,
                      proveedor = producto.proveedor,
                      precio = producto.precio,
                      cantidad = producto.cantidad,

                      costo = producto.costo,
                      precio_lista = producto.precio_lista,
                      precio_efectivo = producto.precio_efectivo,
                  });
            }
        }

        public async Task addDetalleFormaPago2(FormaPago formaPago) //ESTA HECHO PARA CTA CTE
        {
            await firebase
            .Child("DetallePago")
             .PostAsync(new FormaPago()
             {
                 foranea = formaPago.foranea,
                 nombre = formaPago.nombre,
                 fecha = formaPago.fecha,
                 monto = formaPago.monto,
                 comentario = formaPago.comentario,
                 sucursal = formaPago.sucursal
             });
        }

        public async Task addDetalleFormaPago(string id, List<FormaPago> formaPagos)
        {
            foreach (var formaPago in formaPagos)
            {
                await firebase
                  .Child("DetallePago")//forma pago
                                       //.Child(id)
                  .PostAsync(new FormaPago()
                  {
                      foranea = id,
                      nombre = formaPago.nombre,
                      fecha = formaPago.fecha,
                      monto = formaPago.monto,
                      comentario = formaPago.comentario,
                      sucursal = formaPago.sucursal,
                  });
            }
        }
        public async Task<List<FormaPago>> getAllDetalleFormaPago()//aca va string id
        {

            return (await firebase
              .Child("DetallePago")
              //.Child(id)
              .OnceAsync<FormaPago>()).Select(item => new FormaPago
              {
                  foranea = item.Object.foranea,
                  nombre = item.Object.nombre,
                  fecha = item.Object.fecha,
                  monto = item.Object.monto,//aca agregar foranea
                  comentario = item.Object.comentario,//aca agregar foranea
                  sucursal = item.Object.sucursal//aca agregar foranea
              }).ToList();
        }
        public async Task deleteDetalleFormaPago(string id)
        {
            var toUpdateProducto = (await firebase
              .Child("DetallePago")
              .OnceAsync<Producto>()).Where(a => a.Object.foranea == id).FirstOrDefault();
            if (toUpdateProducto != null)
            {
                await firebase.Child("DetallePago").Child(toUpdateProducto.Key).DeleteAsync();
            }
        }


        public async Task updateDetalleFormaPago(string id, List<FormaPago> formaPagos)
        {
            foreach (var formaPago in formaPagos)
            {
                await firebase
                  .Child("DetalleFormaPago")
                  .Child(id)
                  .PutAsync(new FormaPago()
                  {
                      nombre = formaPago.nombre,
                      foranea = formaPago.foranea,
                      fecha = formaPago.fecha,
                      monto = formaPago.monto,
                      comentario = formaPago.comentario,
                      sucursal = formaPago.sucursal,
                  });
            }
        }


        //---------------------------CAMBIOS-----------------------------------------------
        //---------------------------CAMBIOS-----------------------------------------------
        //---------------------------CAMBIOS-----------------------------------------------
        //---------------------------CAMBIOS-----------------------------------------------

        public async Task<List<Cambio>> getAllCambios()
        {

            return (await firebase
              .Child("Cambios")
              .OnceAsync<Cambio>()).Select(item => new Cambio
              {
                  id = item.Object.id,
                  fecha = item.Object.fecha,
                  hora = item.Object.hora,
                  nombre_empleado = item.Object.nombre_empleado,
                  nombre_sucursal = item.Object.nombre_sucursal,
                  nombre_cliente = item.Object.nombre_cliente,
                  observacion = item.Object.observacion,
                  estado = item.Object.estado,
                  tipo_pago = item.Object.tipo_pago,
                  total = item.Object.total,
                  ganancia = item.Object.ganancia

              }).ToList();
        }
        public async Task addCambio(string id, string fecha, string hora, string nombre_empleado, string nombre_sucursal
            , string nombre_cliente, string observacion, string estado, string tipo_pago, string total, string ganancia)
        {
            await firebase
              .Child("Cambios")
              .PostAsync(new Cambio()
              {
                  id = id,
                  fecha = fecha,
                  hora = hora,
                  nombre_empleado = nombre_empleado,
                  nombre_sucursal = nombre_sucursal,
                  nombre_cliente = nombre_cliente,
                  observacion = observacion,
                  estado = estado,
                  tipo_pago = tipo_pago,
                  total = total,
                  ganancia = ganancia,

              });
        }

        public async Task<Cambio> getCambio(string id)
        {
            var allProductos = await getAllCambios();
            await firebase
              .Child("Cambios")
              .OnceAsync<Cambio>();
            return allProductos.Where(a => a.id == id).FirstOrDefault();
        }

        public async Task updateCambio(string id, string fecha, string hora, string nombre_empleado, string nombre_sucursal
            , string nombre_cliente, string observacion, string estado, string tipo_pago, string total, string ganancia)
        {
            var toUpdateProducto = (await firebase
              .Child("Cambios")
              .OnceAsync<Cambio>()).Where(a => a.Object.id == id).FirstOrDefault();

            await firebase
              .Child("Cambios")
              .Child(toUpdateProducto.Key)
              .PutAsync(new Cambio()
              {
                  id = id,
                  fecha = fecha,
                  hora = hora,
                  nombre_empleado = nombre_empleado,
                  nombre_sucursal = nombre_sucursal,
                  nombre_cliente = nombre_cliente,
                  observacion = observacion,
                  estado = estado,
                  tipo_pago = tipo_pago,
                  total = total,
                  ganancia = ganancia,
              });
        }

        public async Task deleteCambio(string id)
        {
            var toDeleteProducto = (await firebase
              .Child("Cambios")
              .OnceAsync<Cambio>()).Where(a => a.Object.id == id).FirstOrDefault();
            await firebase.Child("Cambios").Child(toDeleteProducto.Key).DeleteAsync();
        }


        //-------------------------------DETALLE ---------------------------------------------------
        public async Task<List<Producto>> getAllDetalleCambio()//string id
        {

            return (await firebase
              .Child("DetalleCambio")
              .OnceAsync<Producto>()).Select(item => new Producto
              {
                  foranea = item.Object.foranea,
                  id = item.Object.id,
                  nombre_articulo = item.Object.nombre_articulo,
                  descripcion = item.Object.descripcion,
                  estacion = item.Object.estacion,
                  grupo = item.Object.grupo,
                  talle = item.Object.talle,
                  color = item.Object.color,
                  proveedor = item.Object.proveedor,
                  precio = item.Object.precio,
                  cantidad = item.Object.cantidad,

                  costo = item.Object.costo,
                  precio_lista = item.Object.precio_lista,
                  precio_efectivo = item.Object.precio_efectivo,

              }).ToList();
        }
        public async Task addDetalleCambio(string id, List<Producto> productos)
        {
            foreach (var producto in productos)
            {
                await firebase
                  .Child("DetalleCambio")
                  //.Child(id)
                  .PostAsync(new Producto()
                  {
                      foranea = id,
                      id = producto.id,
                      nombre_articulo = producto.nombre_articulo,
                      descripcion = producto.descripcion,
                      estacion = producto.estacion,
                      grupo = producto.grupo,
                      talle = producto.talle,
                      color = producto.color,
                      proveedor = producto.proveedor,
                      precio = producto.precio,
                      cantidad = producto.cantidad,

                      costo = producto.costo,
                      precio_lista = producto.precio_lista,
                      precio_efectivo = producto.precio_efectivo,
                  });
            }
        }
        public async Task deleteDetalleCambio(string idCambio)
        {
            var toUpdateProducto = (await firebase
              .Child("DetalleCambio")
              .OnceAsync<Producto>()).Where(a => a.Object.foranea == idCambio).FirstOrDefault();
            if (toUpdateProducto != null)
            {
                await firebase.Child("DetalleCambio").Child(toUpdateProducto.Key).DeleteAsync();
            }

        }
        public async Task updateDetalleCambio(string id, List<Producto> productos)
        {
            foreach (var producto in productos)
            {
                await firebase
                  .Child("DetalleCambios")
                  .Child(id)
                  .PutAsync(new Producto()
                  {
                      id = producto.id,
                      nombre_articulo = producto.nombre_articulo,
                      descripcion = producto.descripcion,
                      estacion = producto.estacion,
                      grupo = producto.grupo,
                      talle = producto.talle,
                      color = producto.color,
                      proveedor = producto.proveedor,
                      precio = producto.precio,
                      cantidad = producto.cantidad,

                      costo = producto.costo,
                      precio_lista = producto.precio_lista,
                      precio_efectivo = producto.precio_efectivo,
                  });
            }
        }

        //hasta aca llega CAMBIOS

        //-----------------------------------CLAVES-----------------------------------
        //-----------------------------------CLAVES-----------------------------------
        //-----------------------------------CLAVES-----------------------------------
        //-----------------------------------CLAVES-----------------------------------
        //-----------------------------------CLAVES-----------------------------------
        //-----------------------------------CLAVES-----------------------------------
        //-----------------------------------CLAVES-----------------------------------
        //-----------------------------------CLAVES-----------------------------------

        public async Task<List<Clave>> getAllClaves()
        {

            return (await firebase
              .Child("Claves")
              .OnceAsync<Clave>()).Select(item => new Clave
              {
                  clave = item.Object.clave,
                  id = item.Object.id,
                  nombre_empleado_alta = item.Object.nombre_empleado_alta,
                  fecha = item.Object.fecha,
              }).ToList();
        }
        public async Task addClave(string id, string clave, string nombre_empleado_alta,string fecha)
        {
            await firebase
              .Child("Claves")
              .PostAsync(new Clave()
              {
                  id = id,
                  clave = clave,
                  nombre_empleado_alta = nombre_empleado_alta,
                  fecha = fecha,
              });
        }

        public async Task<Clave> getClave(string clave)
        {
            var allProductos = await getAllClaves();
            await firebase
              .Child("Claves")
              .OnceAsync<Clave>();
            return allProductos.Where(a => a.clave == clave).FirstOrDefault();
        }

        public async Task updateClave(string id, string clave, string nombre_empleado_alta, string fecha)
        {
            var toUpdateCliente = (await firebase
              .Child("Claves")
              .OnceAsync<Clave>()).Where(a => a.Object.clave == clave).FirstOrDefault();

            if (toUpdateCliente != null)
            {
                await firebase
                .Child("Claves")
                .Child(toUpdateCliente.Key)
                .PutAsync(new Clave()
                {
                    clave = clave,
                    id = id,
                    nombre_empleado_alta = nombre_empleado_alta,
                });
            }
            else
            {
                await firebase
             .Child("Claves")
             .PostAsync(new Clave()
             {
                 id = id,
                 clave = clave,
                 nombre_empleado_alta = nombre_empleado_alta,
             });
            }
        }

        public async Task deleteClave(string id)
        {
            var toDeleteProducto = (await firebase
              .Child("Claves")
              .OnceAsync<Clave>()).Where(a => a.Object.id == id).FirstOrDefault();
            await firebase.Child("Claves").Child(toDeleteProducto.Key).DeleteAsync();
        }

        //-----------------------------------TARJETAS-----------------------------------
        //-----------------------------------TARJETAS-----------------------------------
        //-----------------------------------TARJETAS-----------------------------------
        //-----------------------------------TARJETAS-----------------------------------
        //-----------------------------------TARJETAS-----------------------------------

        public async Task<List<Tarjeta>> getAllFormasPagos()
        {

            return (await firebase
              .Child("FormasPagos")
              .OnceAsync<Tarjeta>()).Select(item => new Tarjeta
              {
                  id = item.Object.id,
                  nombre = item.Object.nombre,
                  comision = item.Object.comision,
              }).ToList();
        }
        public async Task addFormaPago(string id, string nombre, string comision)
        {
            await firebase
              .Child("FormasPagos")
              .PostAsync(new Tarjeta()
              {
                  id = id,
                  nombre = nombre,
                  comision = comision,
              });
        }

        public async Task<Tarjeta> getFormaPago(string id)
        {
            var allProductos = await getAllFormasPagos();
            await firebase
              .Child("FormasPagos")
              .OnceAsync<Tarjeta>();
            return allProductos.Where(a => a.id == id).FirstOrDefault();
        }

        public async Task updateFormaPago(string id, string nombre, string comision)
        {
            var toUpdateCliente = (await firebase
              .Child("FormasPagos")
              .OnceAsync<Tarjeta>()).Where(a => a.Object.id == id).FirstOrDefault();

            if (toUpdateCliente != null)
            {
                await firebase
                .Child("FormasPagos")
                .Child(toUpdateCliente.Key)
                .PutAsync(new Tarjeta()
                {
                    id = id,
                    nombre = nombre,
                    comision = comision,
                });
            }
            else
            {
                await firebase
                  .Child("FormasPagos")
                  .PostAsync(new Tarjeta()
                  {
                      id = id,
                      nombre = nombre,
                      comision = comision,
                  });
            }
        }

        public async Task deleteFormaPago(string id)
        {
            var toDeleteProducto = (await firebase
              .Child("Claves")
              .OnceAsync<Clave>()).Where(a => a.Object.id == id).FirstOrDefault();
            await firebase.Child("Claves").Child(toDeleteProducto.Key).DeleteAsync();
        }
        //-----------------------------------ARQUEO-----------------------------------
        //-----------------------------------ARQUEO-----------------------------------
        //-----------------------------------ARQUEO-----------------------------------
        //-----------------------------------ARQUEO-----------------------------------
        //-----------------------------------ARQUEO-----------------------------------
        //-----------------------------------ARQUEO-----------------------------------
        //-----------------------------------ARQUEO-----------------------------------
        public async Task<List<ArqueoCaja>> getAllArqueos(string sucursal)
        {

            return (await firebase
              .Child("Sucursales")
              .Child(sucursal)
              .Child("ArqueoCaja")
              .OnceAsync<ArqueoCaja>()).Select(item => new ArqueoCaja
              {
                  id = item.Object.id,
                  fecha = item.Object.fecha,
                  hora_cierre = item.Object.hora_cierre,
                  sucursal = item.Object.sucursal,
                  empleado = item.Object.empleado,

                  efectivo_sistema = item.Object.efectivo_sistema,
                  efectivo_empleado = item.Object.efectivo_empleado,
                  efectivo_apertura = item.Object.efectivo_apertura,
                  efectivo_TM = item.Object.efectivo_TM,
                  efectivo_Extraccion = item.Object.efectivo_Extraccion,
                  efectivo_Restante = item.Object.efectivo_Restante,
                  efectivo_Total = item.Object.efectivo_Total,

                  debito = item.Object.debito,
                  credito = item.Object.credito,
                  transferencia = item.Object.transferencia,
                  canje = item.Object.canje,
                  ctacte = item.Object.ctacte,
                  total = item.Object.total,
                  descuento = item.Object.descuento,
                  comentario = item.Object.comentario,
                  gasto_diario = item.Object.gasto_diario,
              }).ToList();
        }
        public async Task addArqueo(string id, string fecha, string hora_cierre, string sucursal, string empleado, string efectivo_sistema, string efectivo_empleado,
            string efectivo_apertura, string efectivo_TM, string efectivo_Extraccion, string efectivo_Restante, string efectivo_Total, string debito, string credito,
            string transferencia, string canje, string ctacte, string total, string descuento, string comentario, string gasto)
        {
            await firebase
                .Child("Sucursales")
                .Child(sucursal)
              .Child("ArqueoCaja")
              .PostAsync(new ArqueoCaja()
              {
                  id = id,
                  fecha = fecha,
                  hora_cierre = hora_cierre,
                  sucursal = sucursal,
                  empleado = empleado,

                  efectivo_sistema = efectivo_sistema,
                  efectivo_empleado = efectivo_empleado,
                  efectivo_apertura = efectivo_apertura,
                  efectivo_TM = efectivo_TM,
                  efectivo_Extraccion = efectivo_Extraccion,
                  efectivo_Restante = efectivo_Restante,
                  efectivo_Total = efectivo_Total,

                  debito = debito,
                  credito = credito,
                  transferencia = transferencia,
                  canje = canje,
                  ctacte = ctacte,
                  total = total,
                  descuento = descuento,
                  comentario = comentario,
                  gasto_diario = gasto,
              });
        }


        public async Task updateArqueo(string id, string fecha, string hora_cierre, string sucursal, string empleado, string efectivo_sistema, string efectivo_empleado,
            string efectivo_apertura, string efectivo_TM, string efectivo_Extraccion, string efectivo_Restante, string efectivo_Total, string debito, string credito,
            string transferencia, string canje, string ctacte, string total, string descuento, string comentario, string gasto)
        {
            var toUpdateProducto = (await firebase
              .Child("Sucursales")
              .Child(sucursal)
              .Child("ArqueoCaja")
              .OnceAsync<Producto>()).Where(a => a.Object.id == id).FirstOrDefault();

            if (toUpdateProducto != null)
            {
                await firebase
                    .Child("Sucursales")
                    .Child(sucursal)
                    .Child("ArqueoCaja")
                 .Child(toUpdateProducto.Key)
                 .PutAsync(new ArqueoCaja()
                 {
                     id = id,
                     fecha = fecha,
                     hora_cierre = hora_cierre,
                     sucursal = sucursal,
                     empleado = empleado,
                     efectivo_sistema = efectivo_sistema,
                     efectivo_empleado = efectivo_empleado,

                     efectivo_apertura = efectivo_apertura,
                     efectivo_TM = efectivo_TM,
                     efectivo_Extraccion = efectivo_Extraccion,
                     efectivo_Restante = efectivo_Restante,
                     efectivo_Total = efectivo_Total,

                     debito = debito,
                     credito = credito,
                     transferencia = transferencia,
                     canje = canje,
                     ctacte = ctacte,
                     total = total,
                     descuento = descuento,
                     comentario = comentario,
                     gasto_diario = gasto,
                 });
            }
            else
            {
                await firebase
                    .Child("Sucursales")
                    .Child(sucursal)
                    .Child("ArqueoCaja")
                .PostAsync(new ArqueoCaja()
                {
                    id = id,
                    fecha = fecha,
                    hora_cierre = hora_cierre,
                    sucursal = sucursal,
                    empleado = empleado,
                    efectivo_sistema = efectivo_sistema,
                    efectivo_empleado = efectivo_empleado,

                    efectivo_apertura = efectivo_apertura,
                    efectivo_TM = efectivo_TM,
                    efectivo_Extraccion = efectivo_Extraccion,
                    efectivo_Restante = efectivo_Restante,
                    efectivo_Total = efectivo_Total,


                    debito = debito,
                    credito = credito,
                    transferencia = transferencia,
                    canje = canje,
                    ctacte = ctacte,
                    total = total,
                    descuento = descuento,
                    comentario = comentario,
                    gasto_diario = gasto,
                });
            }
        }

        public async Task<ArqueoCaja> getArqueo(string id, string sucursal)
        {
            var allProductos = await getAllArqueos(sucursal);
            await firebase
                .Child("Sucursales")
               .Child(sucursal)
              .Child("ArqueoCaja")
              .OnceAsync<ArqueoCaja>();
            return allProductos.Where(a => a.id == id).FirstOrDefault();
        }



        public async Task deleteArqueo(string id, string sucursal)
        {
            var toDeleteProducto = (await firebase
                .Child("Sucursales")
              .Child(sucursal)
              .Child("ArqueoCaja")
              .OnceAsync<ArqueoCaja>()).Where(a => a.Object.id == id).FirstOrDefault();
            await firebase.Child("Claves").Child(toDeleteProducto.Key).DeleteAsync();
        }

        //---------------------------ORDEN COMPRA-----------------------------------------------
        //----------------------------ORDEN COMPRA------------------------------------------------
        //----------------------------ORDEN COMPRA------------------------------------------------
        //----------------------------ORDEN COMPRA------------------------------------------------

        public async Task<List<OrdenCompra>> getAllOrdenCompra()
        {

            return (await firebase
              .Child("OrdenesCompra")
              .OnceAsync<OrdenCompra>()).Select(item => new OrdenCompra
              {
                  id = item.Object.id,
                  fecha = item.Object.fecha,
                  hora = item.Object.hora,
                  empleado = item.Object.empleado,
                  observacion = item.Object.observacion,

                  validoHasta = item.Object.validoHasta,
                  proveedor = item.Object.proveedor,
                  total = item.Object.total,
                  ganancia = item.Object.ganancia,
                  prioridad = item.Object.prioridad,

                  estado = item.Object.estado,
                  remito = item.Object.remito,

              }).ToList();
        }

        public async Task updateOrdenCompra(string id, string fecha, string hora, string empleado, string observacion,
            string validoHasta, string proveedor, string total, string ganancia, string prioridad, string estado, string remito)
        {
            var toUpdateOC = (await firebase
              .Child("OrdenesCompra")
              .OnceAsync<OrdenCompra>()).Where(a => a.Object.id == id).FirstOrDefault();

            await firebase
                 .Child("OrdenesCompra")
                 .Child(toUpdateOC.Key)
                 .PutAsync(new OrdenCompra()
                 {
                     id = id,
                     fecha = fecha,
                     hora = hora,
                     empleado = empleado,
                     observacion = observacion,

                     validoHasta = validoHasta,
                     proveedor = proveedor,
                     total = total,
                     ganancia = ganancia,
                     prioridad = prioridad,

                     estado = estado,
                     remito = remito,
                 });
        }
        public async Task addOrdenCompra(string id, string fecha, string hora, string empleado, string observacion, string validoHasta, string proveedor, string total, string ganancia, string prioridad, string estado, string remito)
        {
            await firebase
              .Child("OrdenesCompra")
              .PostAsync(new OrdenCompra()
              {
                  id = id,
                  fecha = fecha,
                  hora = hora,
                  empleado = empleado,
                  observacion = observacion,

                  validoHasta = validoHasta,
                  proveedor = proveedor,
                  total = total,
                  ganancia = ganancia,
                  prioridad = prioridad,

                  estado = estado,
                  remito = remito,

              });
        }
        public async Task addDetalleOrdenCompra(string id, List<Producto> productos)
        {
            foreach (var producto in productos)
            {
                await firebase
                  .Child("DetalleOrdenCompra")
                  .PostAsync(new Producto()
                  {
                      foranea = id,
                      id = producto.id,
                      nombre_articulo = producto.nombre_articulo,
                      descripcion = producto.descripcion,
                      estacion = producto.estacion,
                      grupo = producto.grupo,
                      talle = producto.talle,
                      color = producto.color,
                      proveedor = producto.proveedor,
                      precio = producto.precio,
                      cantidad = producto.cantidad,
                      costo = producto.costo,
                      precio_lista = producto.precio_lista,
                      precio_efectivo = producto.precio_efectivo,
                  });
            }
        }
        public async Task<List<Producto>> getAllDetalleOrdenCompra()
        {

            return (await firebase
              .Child("DetalleOrdenCompra")
              .OnceAsync<Producto>()).Select(item => new Producto
              {
                  foranea = item.Object.foranea,
                  id = item.Object.id,
                  nombre_articulo = item.Object.nombre_articulo,
                  descripcion = item.Object.descripcion,
                  estacion = item.Object.estacion,
                  grupo = item.Object.grupo,
                  talle = item.Object.talle,
                  color = item.Object.color,
                  proveedor = item.Object.proveedor,
                  precio = item.Object.precio,
                  cantidad = item.Object.cantidad,

                  costo = item.Object.costo,
                  precio_lista = item.Object.precio_lista,
                  precio_efectivo = item.Object.precio_efectivo,

              }).ToList();
        }

        //---------------------------GASTO DIARIO-----------------------------------------------
        //---------------------------GASTO DIARIO-----------------------------------------------
        //---------------------------GASTO DIARIO-----------------------------------------------
        //---------------------------GASTO DIARIO-----------------------------------------------

        public async Task<List<GastoDiario>> getAllGastoDiario()
        {

            return (await firebase
              .Child("GastosDiarios")
              .OnceAsync<GastoDiario>()).Select(item => new GastoDiario
              {
                  id = item.Object.id,
                  fecha = item.Object.fecha,
                  sucursal = item.Object.sucursal,
                  empleado = item.Object.empleado,
                  motivo = item.Object.motivo,
                  monto = item.Object.monto,

              }).ToList();
        }
        public async Task addGastoDiario(GastoDiario gastoDiario)
        {
            await firebase
              .Child("GastosDiarios")
              .PostAsync(new GastoDiario()
              {
                  id = gastoDiario.id,
                  fecha = gastoDiario.fecha,
                  sucursal = gastoDiario.sucursal,
                  empleado = gastoDiario.empleado,
                  motivo = gastoDiario.motivo,
                  monto = gastoDiario.monto,
              });
        }
        //---------------------------GRUPO-----------------------------------------------
        //---------------------------GRUPO-----------------------------------------------
        //---------------------------GRUPO-----------------------------------------------
        //---------------------------GRUPO-----------------------------------------------
        //---------------------------GRUPO-----------------------------------------------

        public async Task<List<Grupo>> getAllGrupos()
        {
            return (await firebase
              .Child("Grupos")
              .OnceAsync<Grupo>()).Select(item => new Grupo
              {
                  id = item.Object.id,
                  nombre_grupo = item.Object.nombre_grupo,

              }).ToList();
        }
        public async Task addGrupo(Grupo grupo)
        {
            await firebase
              .Child("Grupos")
              .PostAsync(new Grupo()
              {
                  id = grupo.id,
                  nombre_grupo = grupo.nombre_grupo,
              });
        }

        //---------------------------ROL-----------------------------------------------
        //---------------------------ROL-----------------------------------------------
        //---------------------------ROL-----------------------------------------------
        //---------------------------ROL-----------------------------------------------


        public async Task<List<Rol>> getAllRol ()
        {
            return (await firebase
              .Child("Rols")
              .OnceAsync<Rol>()).Select(item => new Rol
              {
                  descripcion_rol = item.Object.descripcion_rol,
                  SI = item.Object.SI,
                  NO = item.Object.NO,
                  rol = item.Object.rol,

              }).ToList();
        }
        public async Task addRol(Rol rol)
        {
            await firebase
              .Child("Rols")
              .PostAsync(new Rol()
              {
                  descripcion_rol = rol.descripcion_rol,
                  SI = rol.SI,
                  NO = rol.NO,
                  rol = rol.rol,
              });
        }

        public async Task updateRol(Rol rol)
        {
            var toUpdateOC = (await firebase
              .Child("Rols")
              .OnceAsync<Rol>()).Where(a => a.Object.rol == rol.rol && a.Object.descripcion_rol == rol.descripcion_rol).FirstOrDefault();

            await firebase
                 .Child("Rols")
                 .Child(toUpdateOC.Key)
                 .PutAsync(new Rol()
                 {
                     descripcion_rol = rol.descripcion_rol,
                     SI = rol.SI,
                     NO = rol.NO,
                     rol = rol.rol,
                 });
        }
    }
}
