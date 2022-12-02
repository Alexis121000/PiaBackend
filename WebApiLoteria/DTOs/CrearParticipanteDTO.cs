using System.ComponentModel.DataAnnotations;
using WebApiLoteria.Validaciones;

namespace WebApiLoteria.DTOs
{
    public class CrearParticipanteDTO
    {
        [Required(ErrorMessage = "Este campo es necesario")]
        [StringLength(maximumLength: 15, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [PrimeraLetraMayuscula]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es necesario")]
        [StringLength(maximumLength: 15, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        [PrimeraLetraMayuscula]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Este campo es necesario")]
        public int Edad { get; set; }

        [StringLength(maximumLength: 10, ErrorMessage = "El campo debe tener como maximo 10 caracteres")]
        public string Telefono { get; set; }
        public int IdRifa { get; set; }
        public DateTime FechaInscripcion { get; set; }
    }
}
