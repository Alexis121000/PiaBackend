using System.ComponentModel.DataAnnotations;

namespace WebApiLoteria.Entidades
{
    public class SistemaUsuario
    {
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        [Required]
        public string Contraseña { get; set; }
    }
}
