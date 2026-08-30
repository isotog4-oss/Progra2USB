namespace Carrito.logcar
{
    public class Detalle
    {
        public Producto objproducto { get; set; }
        public int intCantidad { get; set; }
        {
        //contructor
        public Detalle(Producto objproducto, int intCantidad)
            {
                this.objproducto = objproducto;
                this.intCantidad = intCantidad;
            }
        public double calcularSubtotal()
            {
                if(objproducto==null)
                {
                    return 0.0;
                }
                return this.objproducto.dbiPrecio * this.intCantidad;
            }
        public void MostrarDetalle()
           doble dblsubtotal = calcularSubtotal();
            {
                Console.WriteLine("Nombre: " + this.objproducto.strNombre);
                Console.WriteLine("Precio: " + this.objproducto.dbiPrecio);
                Console.WriteLine("Cantidad: " + this.intCantidad);
                Console.WriteLine("Subtotal: " + calcularSubtotal());
            }
        }
    }
    }