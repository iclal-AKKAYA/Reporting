using Microsoft.EntityFrameworkCore;
using Reporting.Data; // Do�ru namespace'i ekledi�inizden emin olun
using Repositories.EFCore; // RepositoryContext i�in gerekli namespace
using Microsoft.AspNetCore.Identity;
using Services.Contracts; // ServiceManager i�in gerekli namespace
using Services; // Servislerin y�netimi i�in
using Repositories.Contracts;
using Microsoft.Azure.SignalR.Management;
using Repositories; // RepositoryManager i�in gerekli namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Veritaban� ba�lant�s� i�in DbContext'i ekliyoruz ve Identity yap�land�rmas�n� ekliyoruz.
builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("Reporting")));

// Identity hizmetlerini ekle
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<RepositoryContext>()
    .AddDefaultTokenProviders();

// ServiceManager ve RepositoryManager'� ekliyoruz
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Geli�tirme ortam� i�in hata sayfas�
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
