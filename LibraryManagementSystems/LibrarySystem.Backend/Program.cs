using LibrarySystem.Backend.Data;
using LibrarySystem.Backend.Repositories.Implementations;
using LibrarySystem.Backend.Repositories.Interface;
//using LibrarySystem.Backend.Utilities;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=LocalConnection"));

//builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddTransient<SeedDb>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

// inyection manual Tutorial 72 - Parte 19 - Alimentador de base de datos https://www.youtube.com/watch?v=VD1b8yAMC7o&list=PLuEZQoW9bRnRBThyGs208ZMrCYBRTvIg2&index=19 
SeedData(app);

void SeedData(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory!.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<SeedDb>();
        service!.SeedAsync().Wait();
    }
}



//para seguridad
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();