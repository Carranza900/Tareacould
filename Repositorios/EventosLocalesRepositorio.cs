using System;
using System.Collections.Generic;
using TiendaLibros.Entidades; // Asegúrate de tener la importación adecuada para la entidad EventoLocal.

namespace TiendaLibros.Repositorios
{
    public class EventosLocalesRepositorio
    {
        private readonly List<EventoLocal> eventosLocales;

        public EventosLocalesRepositorio()
        {
            var eventoLocal1 = new EventoLocal
            {
                Id = Guid.NewGuid(),
                Nombre = "Evento Local 1",
                Fecha = DateTime.Now.AddDays(7),
                Descripcion = "Alguna descripcion del evento local 1",
                Ubicacion = "Ubicacion 1"
            };
            var eventoLocal2 = new EventoLocal
            {
                Id = Guid.NewGuid(),
                Nombre = "Evento Local 2",
                Fecha = DateTime.Now.AddDays(14),
                Descripcion = "Alguna descripcion del evento local 2",
                Ubicacion = "Ubicacion 2"
            };
            var eventoLocal3 = new EventoLocal
            {
                Id = Guid.NewGuid(),
                Nombre = "Evento Local 3",
                Fecha = DateTime.Now.AddDays(21),
                Descripcion = "Alguna descripcion del evento local 3",
                Ubicacion = "Ubicacion 3"
            };

            eventosLocales = new()
            {
                eventoLocal1,
                eventoLocal2,
                eventoLocal3
            };
        }

        public void Crear(EventoLocal eventoLocal)
        {
            eventosLocales.Add(eventoLocal);
        }

        public void Actualizar(EventoLocal eventoLocal)
        {
            var eventoExistente = eventosLocales.FirstOrDefault(e => e.Id == eventoLocal.Id);

            if (eventoExistente != null)
            {
                eventoExistente.Nombre = eventoLocal.Nombre;
                eventoExistente.Fecha = eventoLocal.Fecha;
                eventoExistente.Descripcion = eventoLocal.Descripcion;
                eventoExistente.Ubicacion = eventoLocal.Ubicacion;
                
            }
            
            else
            {
                
            }
        }

        public void Eliminar(EventoLocal eventoLocal)
        {
            eventosLocales.Remove(eventoLocal);
        }

        public EventoLocal? ObtenerPorId(Guid id)
        {
            return eventosLocales.FirstOrDefault(e => e.Id == id);
        }

        public List<EventoLocal> Leer()
        {
            return eventosLocales;
        }
    }
}