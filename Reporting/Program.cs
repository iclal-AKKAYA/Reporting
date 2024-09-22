using Microsoft.EntityFrameworkCore;
using Reporting.Data; // Doðru namespace'i eklediðinizden emin olun
using Repositories.EFCore; // RepositoryContext için gerekli namespace
using Microsoft.AspNetCore.Identity;
using Services.Contracts; // ServiceManager için gerekli namespace
using Services; // Servislerin yönetimi için
using Repositories.Contracts;
using Microsoft.Azure.SignalR.Management;
using Repositories; // RepositoryManager için gerekli namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Veritabaný baðlantýsý için DbContext'i ekliyoruz ve Identity yapýlandýrmasýný ekliyoruz.
builder.Services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("Reporting")));

// Identity hizmetlerini ekle
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<RepositoryContext>()
    .AddDefaultTokenProviders();

// ServiceManager ve RepositoryManager'ý ekliyoruz
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // Geliþtirme ortamý için hata sayfasý
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
