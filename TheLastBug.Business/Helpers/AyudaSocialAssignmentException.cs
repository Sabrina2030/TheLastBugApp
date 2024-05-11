using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLastBug.Business.Helpers
{
    public class AyudaSocialAssignmentException : Exception
    {
        public AyudaSocialAssignmentException()
        {
        }

        public AyudaSocialAssignmentException(string message)
            : base(message)
        {
        }

        public AyudaSocialAssignmentException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public int UsuarioId { get; private set; }
        public string TipoAyuda { get; private set; }
        public int Anio { get; private set; }

        public AyudaSocialAssignmentException(int usuarioId, string tipoAyuda, int anio)
            : base($"No se puede asignar la ayuda social de tipo '{tipoAyuda}' al usuario con ID '{usuarioId}' para el año '{anio}'.")
        {
            UsuarioId = usuarioId;
            TipoAyuda = tipoAyuda;
            Anio = anio;
        }
    }
}
