using System;
using System.Collections.Generic;
using TiendaLibros.Entidades; // Asegúrate de tener la importación adecuada para la entidad DestinoTuristico.

namespace TiendaLibros.Repositorios
{
    public class DestinosTuristicosRepositorio
    {
        private readonly List<DestinoTuristico> destinosTuristicos;

        public DestinosTuristicosRepositorio()
        {
            var destinoTuristico1 = new DestinoTuristico
            {
                Id = Guid.NewGuid(),
                Nombre = "Destino Turístico 1",
                Descripcion = "Alguna descripcion del destino turístico 1",
                Ubicacion = "Ubicacion 1"
            };
            var destinoTuristico2 = new DestinoTuristico
            {
                Id = Guid.NewGuid(),
                Nombre = "Destino Turístico 2",
                Descripcion = "Alguna descripcion del destino turístico 2",
                Ubicacion = "Ubicacion 2"
            };
            var destinoTuristico3 = new DestinoTuristico
            {
                Id = Guid.NewGuid(),
                Nombre = "Destino Turístico 3",
                Descripcion = "Alguna descripcion del destino turístico 3",
                Ubicacion = "Ubicacion 3"
            };

            destinosTuristicos = new()
            {
                destinoTuristico1,
                destinoTuristico2,
                destinoTuristico3
            };
        }

        public void Crear(DestinoTuristico destinoTuristico)
        {
            destinosTuristicos.Add(destinoTuristico);
        }

        public void Actualizar(DestinoTuristico destinoTuristico)
        {
            var destinoExistente = destinosTuristicos.FirstOrDefault(d => d.Id == destinoTuristico.Id);

            if (destinoExistente != null)
            {
                destinoExistente.Nombre = destinoTuristico.Nombre;
                destinoExistente.Descripcion = destinoTuristico.Descripcion;
                destinoExistente.Ubicacion = destinoTuristico.Ubicacion;
                
            }
            else
            {
                
            }
        }

        public void Eliminar(DestinoTuristico destinoTuristico)
        {
            destinosTuristicos.Remove(destinoTuristico);
        }

        public DestinoTuristico? ObtenerPorId(Guid id)
        {
            return destinosTuristicos.FirstOrDefault(d => d.Id == id);
        }

        public List<DestinoTuristico> Leer()
        {
            return destinosTuristicos;
        }
    }
}