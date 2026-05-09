using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Shared.Entities
{
    public class LoanStatus
    {
        public int Id { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Description { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool? State { get; set; }

        public DateTime? CreationDate { get; set; }
    }
}
