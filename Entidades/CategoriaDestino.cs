using System;

namespace Entidades.CategoriaDestino
{
    public class CategoriaDestino
    {
        public Guid ID { get; set; }
        public String Nombre { get; set; } = string.Empty;
        public String Descripcion { get; set; } = string.Empty;

        void Crear() { }

        void Eliminar() { }
    }
}