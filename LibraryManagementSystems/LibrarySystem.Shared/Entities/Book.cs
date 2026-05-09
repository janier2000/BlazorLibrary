using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Shared.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Display(Name = "Titulo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Title { get; set; }

        [Display(Name = "Stado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool? State { get; set; }

        [Display(Name = "Autor")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Author { get; set; }

        [Display(Name = "Editorial")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Editorial { get; set; }

        [Display(Name = "Localizacion")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Location { get; set; }

        [Display(Name = "Ejemplares")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int Exemplars { get; set; }

        [Display(Name = "Portada")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Home { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool Status { get; set; }

        //[Display(Name = "")]
        //[Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime? CreationDate { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}