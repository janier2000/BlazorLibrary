using CurrieTechnologies.Razor.SweetAlert2;
using LibrarySystem.Frontend;
using LibrarySystem.Frontend.Services.Implementations;
using LibrarySystem.Frontend.Services.Interface;
using LibrarySystem.Frontend.Utilidad;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;




var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//cambio temporal
builder.Services
       .AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7131/") });


builder.Services.AddSingleton<MenuService>();

builder.Services.AddScoped<IBookServices, BookServices>();
builder.Services.AddScoped<ICategoryServices, CategoryServices>();

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSweetAlert2();
builder.Services.AddMudServices();
await builder.Build().RunAsync();
