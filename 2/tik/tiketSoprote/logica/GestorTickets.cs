// Agregado: necesario para usar .Count(predicado) en generarResumenControl.
using System.Linq;

namespace TicketsSoporte.logica
{
    // Renombrado: en el pizarrón decía "GestorTicket" (sin "s") y
    // Program.cs usa "GestorTickets" (con "s"). Tienen que ser idénticos.
    public class GestorTickets
    {
        public List<Ticket> lstTickets { get; set; }

        // Renombrado: en el pizarrón decía "lstTecnico" (singular) y
        // Program.cs usa "lstTecnicos" (plural).
        public List<Tecnico> lstTecnicos { get; set; }
        public List<Solicitante> lstSolicitantes { get; set; }

        public GestorTickets()
        {
            lstTecnicos = new List<Tecnico>();
            lstTickets = new List<Ticket>();
            lstSolicitantes = new List<Solicitante>();
        }

        // Firma cambiada: en el pizarrón tenía 7 parámetros (incluía intNumero
        // y Tecnico objTecnico ya elegidos). Program.cs la llama con 5:
        // crearTicket(strTitulo, strDescripcion, strCategoria, strPrioridad, objSolicitante)
        // Quitado: intNumero como parámetro (se genera aquí adentro).
        // Quitado: Tecnico objTecnico como parámetro (aquí abajo se busca solo,
        // porque el menú dice "Crear ticket y asignar automáticamente").
        public Ticket crearTicket(string strTitulo, string strDescripcion, string strCategoria, string strPrioridad, Solicitante objSolicitante)
        {
            int intNumero = lstTickets.Count + 1;

            // Orden correcto según el constructor real de Ticket.cs:
            // (intNumero, strTitulo, strDescripcion, strCategoria, strPrioridad, objSolicitante)
            Ticket objTicket = new Ticket(intNumero, strTitulo, strDescripcion, strCategoria, strPrioridad, objSolicitante);

            // Asignación automática: busca el primer técnico que pueda atender la categoría.
            Tecnico objTecnico = lstTecnicos.Find(t => t.puedeAtender(strCategoria));
            if (objTecnico != null)
            {
                objTicket.asignarTecnico(objTecnico);
            }
            else
            {
                objTicket.registrarBitacora("Sin técnico disponible para la categoría " + strCategoria);
            }

            lstTickets.Add(objTicket);
            return objTicket;
        }

        // Igual que en el pizarrón (imagen 4), solo se agrega la validación
        // de "no encontrado", porque Program.cs usa el resultado directo
        // (objTicket.mostrarResumen()) sin revisar null antes.
        public Ticket buscarTicket(int intNumero)
        {
            Ticket objTicket = lstTickets.Find(t => t.intNumero == intNumero);
            if (objTicket == null)
            {
                throw new InvalidOperationException("No existe un ticket con ese número.");
            }
            return objTicket;
        }

        // Agregado por completo: no estaba en las fotos, pero Program.cs
        // lo llama en la opción 4 del menú ("Ver tickets").
        public void mostrarTickets()
        {
            if (lstTickets.Count == 0)
            {
                Console.WriteLine("No hay tickets registrados.");
                return;
            }

            foreach (Ticket objTicket in lstTickets)
            {
                objTicket.mostrarResumen();
                Console.WriteLine();
            }
        }

        // Agregado por completo: no estaba en las fotos, pero Program.cs
        // lo llama en la opción 8 del menú ("Generar resumen de control").
        public void generarResumenControl()
        {
            Console.WriteLine("\n=== RESUMEN DE CONTROL ===");
            Console.WriteLine($"Total de tickets: {lstTickets.Count}");
            Console.WriteLine($"Abiertos: {lstTickets.Count(t => t.strEstado == "Abierto")}");
            Console.WriteLine($"Asignados: {lstTickets.Count(t => t.strEstado == "Asignado")}");
            Console.WriteLine($"Resueltos: {lstTickets.Count(t => t.strEstado == "Resuelto")}");
            Console.WriteLine($"Cerrados: {lstTickets.Count(t => t.strEstado == "Cerrado")}");
            Console.WriteLine($"Escalados: {lstTickets.Count(t => t.blnEscalado)}");

            foreach (Tecnico objTecnico in lstTecnicos)
            {
                Console.WriteLine($" Técnico {objTecnico.strNombre}: carga {objTecnico.intCargaActual}/{objTecnico.intCapacidadMaxima}");
            }
        }
    }
}
