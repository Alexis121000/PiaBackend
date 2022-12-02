using System.ComponentModel.DataAnnotations;

namespace WebApiLoteria.DTOs
{
    public class EditarAdminDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
