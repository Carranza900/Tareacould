using System;

namespace Entidades.DestinoTuristico
{
    public class DestinoTuristico
    {
        public Guid ID { get; set; }
        public String Nombre { get; set; } = string.Empty;
        public String Descripcion { get; set; } = string.Empty;
        public String Ubicacion { get; set; } = string.Empty;

        void Crear() { }

        void Eliminar() { }
    }
}