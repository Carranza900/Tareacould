using System;
using System.Collections.Generic;
using TiendaLibros.Entidades; // Asegúrate de tener la importación adecuada para la entidad CategoriaDestino.

namespace TiendaLibros.Repositorios
{
    public class CategoriasDestinoRepositorio
    {
        private readonly List<CategoriaDestino> categoriasDestino;

        public CategoriasDestinoRepositorio()
        {
            var categoriaDestino1 = new CategoriaDestino
            {
                Id = Guid.NewGuid(),
                Nombre = "Categoria Destino 1",
                Descripcion = "Alguna descripcion de la categoría destino 1"
            };
            var categoriaDestino2 = new CategoriaDestino
            {
                Id = Guid.NewGuid(),
                Nombre = "Categoria Destino 2",
                Descripcion = "Alguna descripcion de la categoría destino 2"
            };
            var categoriaDestino3 = new CategoriaDestino
            {
                Id = Guid.NewGuid(),
                Nombre = "Categoria Destino 3",
                Descripcion = "Alguna descripcion de la categoría destino 3"
            };

            categoriasDestino = new()
            {
                categoriaDestino1,
                categoriaDestino2,
                categoriaDestino3
            };
        }

        public void Crear(CategoriaDestino categoriaDestino)
        {
            categoriasDestino.Add(categoriaDestino);
        }

        public void Actualizar(CategoriaDestino categoriaDestino)
        {
            var categoriaExistente = categoriasDestino.FirstOrDefault(c => c.Id == categoriaDestino.Id);

            if (categoriaExistente != null)
            {
                categoriaExistente.Nombre = categoriaDestino.Nombre;
                categoriaExistente.Descripcion = categoriaDestino.Descripcion;
                
            }
            else
            {
                
            }
        }

        public void Eliminar(CategoriaDestino categoriaDestino)
        {
            categoriasDestino.Remove(categoriaDestino);
        }

        public CategoriaDestino? ObtenerPorId(Guid id)
        {
            return categoriasDestino.FirstOrDefault(c => c.Id == id);
        }

        public List<CategoriaDestino> Leer()
        {
            return categoriasDestino;
        }
    }
}