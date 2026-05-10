using CurrieTechnologies.Razor.SweetAlert2;
using LibrarySystem.Frontend.Services.Interface;
using LibrarySystem.Frontend.Utilidad;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using e=LibrarySystem.Shared.Entities;

namespace LibrarySystem.Frontend.Pages.Book
{
    public partial class BookIndex  
    {
        public List<e.Book>? listBook { get; set; }
        private string searchString1 = "";
        private e.Book selectedItem1 = null;
        private bool loading = true;
        [Inject] private IBookServices BookServices { get; set; } = null!;
        [Inject] private IDialogService _dialogServicio { get; set; } = null!;
        [Inject] private MenuService MenuServicio { get; set; } = null!;
        [Inject] private SweetAlertService SweetAlertService { get; set; } = null!;
        [Inject] private NavigationManager NavigationManager { get; set; } = null!;
        [Inject] private ISnackbar SnackBar { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            MenuServicio.SetMenu(new BreadcrumbItem("Book", href: null));
            await GetBooks();
            loading = false;
        }

        private async Task GetBooks()
        {
            var result = await BookServices.GetFullList();
            if (result.status)
            {
                listBook = (List<e.Book>)result.value!;
            }
        }

        private async Task DeleteBook(e.Book bookENT)
        {
            SweetAlertResult result = await SweetAlertService.FireAsync(new SweetAlertOptions
            {
                Title = "Esta seguro?",
                Text = $"Eliminar libro: {bookENT.Title}",
                Icon = SweetAlertIcon.Warning,
                ShowCancelButton = true,
                ConfirmButtonText = "Si, eliminar",
                CancelButtonText = "No, volver"
            });
            var confirm = string.IsNullOrEmpty(result.Value);

            if (!confirm)
            {
                var results = await BookServices.DeleteAsync(bookENT.Id);
                if (results)
                {
                    SnackBar.Add("El libro fue eliminado con exito", Severity.Success, a => a.VisibleStateDuration = 600);
                    await GetBooks();
                }
                else
                {
                    SnackBar.Add("No se pudo eliminar", Severity.Error, a => a.VisibleStateDuration = 600);
                }
            }
        }

        private bool FilterFunc(e.Book element, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return true;
            }
            if (element.Title.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            if (element.Author.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            if (element.Category.Description.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            if (element.Editorial.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            if (element.Location.Contains(searchString, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            return false;
        }

        private bool FilterFunc1(e.Book element) => FilterFunc(element, searchString1);

    }
}