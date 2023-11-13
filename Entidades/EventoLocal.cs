using System;

namespace Entidades.EventoLocal
{
    public class EventoLocal
    {
        public Guid ID { get; set; }
        public String Nombre { get; set; } = string.Empty;
        public DateTime Fecha { get; set; } = DateTime.MinValue;
        public String Descripcion { get; set; } = string.Empty;
        public String Ubicacion { get; set; } = string.Empty;

        void Crear() { }

        void Eliminar() { }
    }
}