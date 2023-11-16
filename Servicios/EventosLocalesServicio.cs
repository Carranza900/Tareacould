using TiendaLibros.Entidades;
using TiendaLibros.Repositorios;

namespace TiendaLibros.Servicios
{
    public enum Operaciones
    {
        Crear = 1,
        Actualizar = 2,
        Eliminar = 3,
        Leer = 4,
        Salir
    }

    public class EventosLocalesServicio
    {
        private readonly EventosLocalesRepositorio eventosLocalesRepositorio;

        public EventosLocalesServicio()
        {
            eventosLocalesRepositorio = new EventosLocalesRepositorio();
        }

        public void MostrarMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("CRUD EventoLocal");
                Console.WriteLine("1. Crear: ");
                Console.WriteLine("2. Actualizar: ");
                Console.WriteLine("3. Eliminar");
                Console.WriteLine("4. Leer");
                Console.WriteLine("5. Salir");
                Console.WriteLine("Seleccione una opción: ");
                string opcion = Console.ReadLine() ?? "5";
                Operaciones operacion = Enum.Parse<Operaciones>(opcion);

                switch (operacion)
                {
                    case Operaciones.Crear:
                        Crear();
                        break;
                    case Operaciones.Actualizar:
                        Actualizar();
                        break;
                    case Operaciones.Eliminar:
                        Eliminar();
                        break;
                    case Operaciones.Leer:
                        Leer();
                        break;
                    case Operaciones.Salir: return;

                    default: return;
                }
            } while (true);
        }

        public void Crear()
        {
            Console.WriteLine("Creando el eventoLocal");
            Console.WriteLine("Ingrese el nombre del evento: ");
            string nombreEvento = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Ingrese la fecha del evento (YYYY-MM-DD): ");
            DateTime fechaEvento;
            if (!DateTime.TryParse(Console.ReadLine(), out fechaEvento))
            {
                Console.WriteLine("Formato de fecha incorrecto. Se establecerá la fecha actual.");
                fechaEvento = DateTime.Now;
            }
            Console.WriteLine("Ingrese la descripción del evento: ");
            string descripcionEvento = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Ingrese la ubicación del evento: ");
            string ubicacionEvento = Console.ReadLine() ?? string.Empty;

            Guid id = Guid.NewGuid();

            var eventoLocal = new EventoLocal
            {
                Id = id,
                NombreEvento = nombreEvento,
                FechaEvento = fechaEvento,
                DescripcionEvento = descripcionEvento,
                UbicacionEvento = ubicacionEvento
            };

            eventosLocalesRepositorio.Crear(eventoLocal);

            Console.WriteLine("EventoLocal creado...");
            Console.WriteLine("Id: " + eventoLocal.Id);
            Console.WriteLine("Nombre del evento: " + eventoLocal.NombreEvento);
            Console.WriteLine("Fecha del evento: " + eventoLocal.FechaEvento.ToString("yyyy-MM-dd"));
            Console.WriteLine("Descripción del evento: " + eventoLocal.DescripcionEvento);
            Console.WriteLine("Ubicación del evento: " + eventoLocal.UbicacionEvento);
            Console.ReadLine();
        }

        private void Actualizar()
        {
            Console.WriteLine("Ingrese el Id del eventoLocal a actualizar:");
            Guid id = Guid.Parse(Console.ReadLine() ?? "");
            EventoLocal eventoLocal = eventosLocalesRepositorio.ObtenerPorId(id);

            if (eventoLocal is null)
            {
                Console.WriteLine("El eventoLocal no existe");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Ingrese el nuevo nombre del evento (o presione Enter para dejarlo sin cambios):");
            string nuevoNombreEvento = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoNombreEvento))
            {
                eventoLocal.NombreEvento = nuevoNombreEvento;
            }

            Console.WriteLine("Ingrese la nueva fecha del evento (o presione Enter para dejarla sin cambios - formato YYYY-MM-DD):");
            string nuevaFechaEventoStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaFechaEventoStr) && DateTime.TryParse(nuevaFechaEventoStr, out DateTime nuevaFechaEvento))
            {
                eventoLocal.FechaEvento = nuevaFechaEvento;
            }

            Console.WriteLine("Ingrese la nueva descripción del evento (o presione Enter para dejarla sin cambios):");
            string nuevaDescripcionEvento = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaDescripcionEvento))
            {
                eventoLocal.DescripcionEvento = nuevaDescripcionEvento;
            }

            Console.WriteLine("Ingrese la nueva ubicación del evento (o presione Enter para dejarla sin cambios):");
            string nuevaUbicacionEvento = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaUbicacionEvento))
            {
                eventoLocal.UbicacionEvento = nuevaUbicacionEvento;
            }

            eventosLocalesRepositorio.Actualizar(eventoLocal);
            Console.WriteLine("EventoLocal actualizado...");
            Console.WriteLine("Id: " + eventoLocal.Id);
            Console.WriteLine("Nuevo nombre del evento: " + eventoLocal.NombreEvento);
            Console.WriteLine("Nueva fecha del evento: " + eventoLocal.FechaEvento.ToString("yyyy-MM-dd"));
            Console.WriteLine("Nueva descripción del evento: " + eventoLocal.DescripcionEvento);
            Console.WriteLine("Nueva ubicación del evento: " + eventoLocal.UbicacionEvento);
            Console.ReadLine();
        }

        private void Eliminar()
        {
            Console.WriteLine("Ingrese el Id del eventoLocal:");
            Guid id = Guid.Parse(Console.ReadLine() ?? "");
            EventoLocal? eventoLocal = eventosLocalesRepositorio.ObtenerPorId(id);
            if (eventoLocal is null)
            {
                Console.WriteLine("El eventoLocal no existe");
                Console.ReadLine();
                return;
            }

            eventosLocalesRepositorio.Eliminar(eventoLocal);
            Console.WriteLine("El eventoLocal fue eliminado");
            Console.ReadLine();
        }

        private void Leer()
        {
            List<EventoLocal> eventosLocales = eventosLocalesRepositorio.Leer();
            foreach (EventoLocal eventoLocal in eventosLocales)
            {
                Console.WriteLine("======================================");
                Console.WriteLine("Id: " + eventoLocal.Id);
                Console.WriteLine("Nombre del evento: " + eventoLocal.NombreEvento);
                Console.WriteLine("Fecha del evento: " + eventoLocal.FechaEvento.ToString("yyyy-MM-dd"));
                Console.WriteLine("Descripción del evento: " + eventoLocal.DescripcionEvento);
                Console.WriteLine("Ubicación del evento: " + eventoLocal.UbicacionEvento);
            }

            Console.ReadLine();
        }
    }
}