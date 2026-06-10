using Microsoft.EntityFrameworkCore;
using POC_Application.Interfaces;
using POC_Application.Services;
using POC_Domain.Interfaces;
using POC_Infrastructure.Data;
using POC_Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Configure EF Core DB Context with SQL Server
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

// 2. Register Application & Infrastructure Services for DI
builder.Services.AddScoped<IFinancialInstitution, FinancialInstitutionRepository>();
builder.Services.AddScoped<FinancialInstitutionService>();

// 3.Register New Institution Dependencies
builder.Services.AddScoped<IInstitution, InstitutionRepository>();
builder.Services.AddScoped<InstitutionService>();

// 4. Register Controllers and OpenAPI/Swagger Documentation tooling
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 5. Configure HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();