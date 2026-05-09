using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Shared.Entities
{
    public class Loan
    {
        public int Id { get; set; }

        [Display(Name = "Codigo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Code { get; set; }

        [Display(Name = "FechaDevolucion")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime? ReturnDate { get; set; }

        [Display(Name = "Fecha Confirmacion Devolucion")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public DateTime? DateRefundConfirmation { get; set; }

        [Display(Name = "Estado Entregado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? StatusDelivered { get; set; }

        [Display(Name = "Estado Recibido")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? StatusReceived { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public bool? Status { get; set; }

        public DateTime? CreationDate { get; set; }

        public int LoanStatusId { get; set; }
        public LoanStatus? LoanStatus { get; set; }

        public int ReaderId { get; set; }
        public Reader? Reader { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }

    }
}