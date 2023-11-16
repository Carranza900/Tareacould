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

    public class CategoriasDestinoServicio
    {
        private readonly CategoriasDestinoRepositorio categoriasDestinoRepositorio;

        public CategoriasDestinoServicio()
        {
            categoriasDestinoRepositorio = new CategoriasDestinoRepositorio();
        }

        public void MostrarMenu()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("CRUD CategoriaDestino");
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
            Console.WriteLine("Creando la categoriaDestino");
            Console.WriteLine("Ingrese el nombre de la categoría: ");
            string nombreCategoria = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Ingrese la descripción de la categoría: ");
            string descripcionCategoria = Console.ReadLine() ?? string.Empty;

            Guid id = Guid.NewGuid();

            var categoriaDestino = new CategoriaDestino
            {
                Id = id,
                Nombre = nombreCategoria,
                Descripcion = descripcionCategoria
            };

            categoriasDestinoRepositorio.Crear(categoriaDestino);

            Console.WriteLine("CategoriaDestino creada...");
            Console.WriteLine("Id: " + categoriaDestino.Id);
            Console.WriteLine("Nombre de la categoría: " + categoriaDestino.Nombre);
            Console.WriteLine("Descripción de la categoría: " + categoriaDestino.Descripcion);
            Console.ReadLine();
        }

        private void Actualizar()
        {
            Console.WriteLine("Ingrese el Id de la categoriaDestino a actualizar:");
            Guid id = Guid.Parse(Console.ReadLine() ?? "");
            CategoriaDestino categoriaDestino = categoriasDestinoRepositorio.ObtenerPorId(id);

            if (categoriaDestino is null)
            {
                Console.WriteLine("La categoriaDestino no existe");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Ingrese el nuevo nombre de la categoría (o presione Enter para dejarlo sin cambios):");
            string nuevoNombreCategoria = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevoNombreCategoria))
            {
                categoriaDestino.Nombre = nuevoNombreCategoria;
            }

            Console.WriteLine("Ingrese la nueva descripción de la categoría (o presione Enter para dejarla sin cambios):");
            string nuevaDescripcionCategoria = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(nuevaDescripcionCategoria))
            {
                categoriaDestino.Descripcion = nuevaDescripcionCategoria;
            }

            categoriasDestinoRepositorio.Actualizar(categoriaDestino);
            Console.WriteLine("CategoriaDestino actualizada...");
            Console.WriteLine("Id: " + categoriaDestino.Id);
            Console.WriteLine("Nuevo nombre de la categoría: " + categoriaDestino.Nombre);
            Console.WriteLine("Nueva descripción de la categoría: " + categoriaDestino.Descripcion);
            Console.ReadLine();
        }

        private void Eliminar()
        {
            Console.WriteLine("Ingrese el Id de la categoriaDestino:");
            Guid id = Guid.Parse(Console.ReadLine() ?? "");
            CategoriaDestino? categoriaDestino = categoriasDestinoRepositorio.ObtenerPorId(id);
            if (categoriaDestino is null)
            {
                Console.WriteLine("La categoriaDestino no existe");
                Console.ReadLine();
                return;
            }

            categoriasDestinoRepositorio.Eliminar(categoriaDestino);
            Console.WriteLine("La categoriaDestino fue eliminada");
            Console.ReadLine();
        }

        private void Leer()
        {
            List<CategoriaDestino> categoriasDestino = categoriasDestinoRepositorio.Leer();
            foreach (CategoriaDestino categoriaDestino in categoriasDestino)
            {
                Console.WriteLine("======================================");
                Console.WriteLine("Id: " + categoriaDestino.Id);
                Console.WriteLine("Nombre de la categoría: " + categoriaDestino.Nombre);
                Console.WriteLine("Descripción de la categoría: " + categoriaDestino.Descripcion);
            }

            Console.ReadLine();
        }
    }
}