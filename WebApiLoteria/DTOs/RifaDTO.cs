using System.ComponentModel.DataAnnotations;
using WebApiLoteria.Entidades;

namespace WebApiLoteria.DTOs
{
    public class RifaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es necesario")]
        [StringLength(maximumLength: 60, ErrorMessage = "El campo {0} no puede tener mas de {1} caracteres")]
        public string NombreRifa { get; set; }

        public List<Premio> Premio{ get; set; }
    }
}
