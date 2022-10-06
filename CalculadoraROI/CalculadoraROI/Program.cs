using CalculadoraROI.Models;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.Configure<StringDeConexao>(builder.Configuration.GetSection("ConnectionStrings"));
builder.Services.AddTransient<MySqlConnection>(_ => new MySqlConnection(builder.Configuration["ConnectionStrings:Conexao"]));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
