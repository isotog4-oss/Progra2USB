namespace Carrito.logcar
{
    public class Producto
    {
        public int intStock { get; set; }
        public double dbiPrecio { get; set; }
        public string strNombre { get; set; }
        public string strCodigo { get; set; }

//contructor
        public Producto(string strNombre, double dbiPrecio, string strCodigo, int intStock)
        {
            this.strNombre = strNombre;
            this.dbiPrecio = dbiPrecio;
            this.strCodigo = strCodigo;
            this.intStock = intStock;
        }
        public bool verificarStok(int intCantidad)
        {
            return intCantidad >0 && this.intStock >= intCantidad;}
        public void descontarStock(int intCantidad)
        {
            if (verificarStok(intCantidad))
            {
                this.intStock -= intCantidad;
            }
        }
        
    }
   