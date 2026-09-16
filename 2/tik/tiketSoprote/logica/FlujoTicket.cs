namespace TicketsSoporte.logica
{
    // Clase nueva por completo. Program.cs la usa así:
    // - objFlujoTicket.mostrarFlujo()
    // - objFlujoTicket.puedeCambiarEstado(objTicket.strEstado, "Resuelto")
    // - objFlujoTicket.puedeCambiarEstado(objTicket.strEstado, "Cerrado")
    public class FlujoTicket
    {
        // Define qué transiciones de estado son válidas.
        private readonly Dictionary<string, string> dicTransicionesValidas = new Dictionary<string, string>
        {
            { "Abierto", "Asignado" },
            { "Asignado", "Resuelto" },
            { "Resuelto", "Cerrado" }
        };

        public bool puedeCambiarEstado(string strEstadoActual, string strEstadoDestino)
        {
            return dicTransicionesValidas.TryGetValue(strEstadoActual, out string strSiguiente)
                   && strSiguiente == strEstadoDestino;
        }

        public void mostrarFlujo()
        {
            Console.WriteLine("\n=== FLUJO DE ESTADOS DEL TICKET ===");
            Console.WriteLine("Abierto -> Asignado -> Resuelto -> Cerrado");
        }
    }
}
