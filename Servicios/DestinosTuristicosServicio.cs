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

    public class DestinosTuristicosServicio
    {
        private readonly DestinosTuristicosRepositorio destinosTuristicosRepositorio;

        public DestinosTuristicosServicio()
        {
            destinosTuristicosRepositorio = new DestinosTuristicosRepositorio();
        }

        public void MostrarMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("CRUD DestinoTuristico");
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
            Console.WriteLine("Creando el destinoTuristico");
            Console.WriteLine("Ingrese el nombre del destino turístico: ");
            string nombreDestino = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Ingrese la descripción del destino turístico: ");
            string descripcionDestino = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Ingrese la ubicación del destino turístico: ");
            string ubicacionDestino = Console.ReadLine() ?? string.Empty;

            Guid id = Guid.NewGuid();

            var destinoTuristico = new DestinoTuristico
            {
                Id = id,
                Nombre = nombreDestino,
                Descripcion = descripcionDestino,
                Ubicacion = ubicacionDestino
            };

            destinosTuristicosRepositorio.Crear(destinoTuristico);

            Console.WriteLine("DestinoTuristico creado...");
            Console.WriteLine("Id: " + destinoTuristico.Id);
            Console.WriteLine("Nombre del destino turístico: " + destinoTuristico.Nombre);
            Console.WriteLine("Descripción del destino turístico: " + destinoTuristico.Descripcion);
            Console.WriteLine("Ubicación del destino turístico: " + destinoTuristico.Ubicacion);
            Console.ReadLine();
        }

        private void Actualizar()
        {
            Console.WriteLine("Ingrese el Id del destinoTuristico a actualizar:");
            Guid id = Guid.Parse(Console.ReadLine() ?? "");
            DestinoTuristico destinoTuristico = destinosTuristicosRepositorio.ObtenerPorId(id);

            if (destinoTuristico is null)
            {
                Console.WriteLine("El destinoTuristico no existe");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Ingrese el nuevo nombre del destino turístico (o presione Enter para dejarlo sin cambios):");
            string nuevoNombreDestino = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoNombreDestino))
            {
                destinoTuristico.Nombre = nuevoNombreDestino;
            }

            Console.WriteLine("Ingrese la nueva descripción del destino turístico (o presione Enter para dejarla sin cambios):");
            string nuevaDescripcionDestino = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaDescripcionDestino))
            {
                destinoTuristico.Descripcion = nuevaDescripcionDestino;
            }

            Console.WriteLine("Ingrese la nueva ubicación del destino turístico (o presione Enter para dejarla sin cambios):");
            string nuevaUbicacionDestino = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaUbicacionDestino))
            {
                destinoTuristico.Ubicacion = nuevaUbicacionDestino;
            }

            destinosTuristicosRepositorio.Actualizar(destinoTuristico);
            Console.WriteLine("DestinoTuristico actualizado...");
            Console.WriteLine("Id: " + destinoTuristico.Id);
            Console.WriteLine("Nuevo nombre del destino turístico: " + destinoTuristico.Nombre);
            Console.WriteLine("Nueva descripción del destino turístico: " + destinoTuristico.Descripcion);
            Console.WriteLine("Nueva ubicación del destino turístico: " + destinoTuristico.Ubicacion);
            Console.ReadLine();
        }

        private void Eliminar()
        {
            Console.WriteLine("Ingrese el Id del destinoTuristico:");
            Guid id = Guid.Parse(Console.ReadLine() ?? "");
            DestinoTuristico? destinoTuristico = destinosTuristicosRepositorio.ObtenerPorId(id);
            if (destinoTuristico is null)
            {
                Console.WriteLine("El destinoTuristico no existe");
                Console.ReadLine();
                return;
            }

            destinosTuristicosRepositorio.Eliminar(destinoTuristico);
            Console.WriteLine("El destinoTuristico fue eliminado");
            Console.ReadLine();
        }

        private void Leer()
        {
            List<DestinoTuristico> destinosTuristicos = destinosTuristicosRepositorio.Leer();
            foreach (DestinoTuristico destinoTuristico in destinosTuristicos)
            {
                Console.WriteLine("======================================");
                Console.WriteLine("Id: " + destinoTuristico.Id);
                Console.WriteLine("Nombre del destino turístico: " + destinoTuristico.Nombre);
                Console.WriteLine("Descripción del destino turístico: " + destinoTuristico.Descripcion);
                Console.WriteLine("Ubicación del destino turístico: " + destinoTuristico.Ubicacion);
            }

            Console.ReadLine();
        }
    }
}