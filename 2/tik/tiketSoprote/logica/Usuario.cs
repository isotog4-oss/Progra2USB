namespace TicketsSoporte.logica
{
    // Se marca "abstract" porque tiene un método abstract adentro (obtenerRol).
    // En el pizarrón decía "public class Usuario" sin abstract: eso no compila
    // si el método obtenerRol es abstract.
    public abstract class Usuario
    {
        public string strNombre { get; set; }
        public string strCodigo { get; set; }
        public string strCorreo { get; set; }

        // Agregado: Tecnico.estaDisponible() usa "blnActivo" y no existía en ningún lado.
        public bool blnActivo { get; set; }

        // Constructor: igual al del pizarrón, solo se agrega blnActivo = true por defecto.
        public Usuario(string strCodigo, string strNombre, string strCorreo)
        {
            this.strCodigo = strCodigo;
            this.strCorreo = strCorreo;
            this.strNombre = strNombre;
            this.blnActivo = true;
        }

        // Quitado: el cuerpo "{ }" que tenía en el pizarrón. Un método abstract
        // no puede tener cuerpo, ni vacío; debe terminar en punto y coma.
        // Agregado: el tipo de retorno "string", porque Tecnico y Solicitante
        // devuelven "Tecnico" y "Solicitante" con override.
        public abstract string obtenerRol();

        // Agregado por completo: no estaba en el pizarrón, pero Tecnico y
        // Solicitante hacen "base.mostrarInformacion()", así que tiene que
        // existir aquí como método virtual para poder sobrescribirlo.
        public virtual void mostrarInformacion()
        {
            Console.WriteLine($"Código: {strCodigo} | Nombre: {strNombre} | Correo: {strCorreo} | Rol: {obtenerRol()}");
        }
    }
}
