using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Shared.Entities
{
    public class Reader
    {
        public int Id { get; set; }

        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Code { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Name { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? lastName { get; set; }

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Email { get; set; }

        [Display(Name = "Clave")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Password { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool Status { get; set; }

        //[Display(Name = "")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime? CreationDate { get; set; }
    }
}
