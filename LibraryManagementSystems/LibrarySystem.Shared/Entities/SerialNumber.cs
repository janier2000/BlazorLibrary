using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Shared.Entities
{
    public class SerialNumber
    {
        public int Id { get; set; }

        [Display(Name = "Prefijo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Prefix { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Type { get; set; }

        [Display(Name = "Ultimo Numero")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? LastNumber { get; set; }

        public DateTime? CreationDate { get; set; }
    }
}