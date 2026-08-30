using System;
using System.Collections.Generic;

namespace Carrito.logica
{
    public class carrito
    {
        public List<Detalle> lstDetalle { get; set; }
       //constructor
       public Carrito()
        {
            lstDetalle = new List<Detalle>();
        }
        public bool agregarProducto(Producto objproducto, int intCantidad)
        {
            //validasion

            if (!objProducto.verificarStok(intCantidad))
            {
                Console.WriteLine("No hay suficiente stock para el producto: " + objproducto.strNombre);
                return false;
            }
            //delo contrario, se agrega el producto al carrito
            lstDetalle.Add(new Detalle(intCantidad,objDetalle);
            {if(istDetalle.Count == 0)
            {
               //error
               Return;
            }
            foreach (Detalle objDetalle in lstDetalle)
            {
                objDetalle.objProducto.descontarStock(objDetalle.intCantidad);
            }
          }
        }
        
    }
}