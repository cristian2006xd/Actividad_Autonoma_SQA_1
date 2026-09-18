using Actividad_Autonoma_SQA_1.Services;

var builder = WebApplication.CreateBuilder(args);

// Registrar el servicio HTTP para la PokeAPI
builder.Services.AddHttpClient<PokemonService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Ruta por defecto apuntando al controlador Pokemon
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pokemon}/{action=Index}/{id?}");

app.Run();