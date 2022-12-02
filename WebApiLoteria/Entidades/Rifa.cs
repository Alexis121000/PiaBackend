using System.ComponentModel.DataAnnotations;

namespace WebApiLoteria.Entidades
{
    public class Rifa
    {
        //Datos
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo es requerido")]
        [StringLength(maximumLength: 60, ErrorMessage = "Este campo no puede tener mas caracteres")]
        public string NombreRifa { get; set; }

        //Relaciones
        public List<RifaParticipante> RifasParticipantes { get; set; }
        public List<Premio> Premio { get; set; }
    }
}
