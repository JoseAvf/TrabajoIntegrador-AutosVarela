using TallerMecanicoWeb.Data;
using TallerMecanicoWeb.Interfaces;
using TallerMecanicoWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Datos compartidos en memoria
builder.Services.AddSingleton<MockData>();

// Servicio de clientes
builder.Services.AddScoped<IClienteService, ClienteService>();

//Servicio de vehículos
builder.Services.AddScoped<IVehiculoService, VehiculoService>();

//Servicio de personal
builder.Services.AddScoped<IPersonalService, PersonalService>();

//Servicio de reparaciones
builder.Services.AddScoped<IReparacionService, ReparacionService>();    //Con esto, ASP.NET Core podrá construir automáticamente ReparacionService y proporcionarle las dependencias necesarias.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
