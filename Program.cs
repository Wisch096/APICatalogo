using System.Text.Json.Serialization;
using APICatalogo.Context;
using APICatalogo.DTOs.Mappings;
using APICatalogo.Extensions;
using APICatalogo.Filters;
using APICatalogo.Repositories;
using APICatalogo.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
    {
        options.Filters.Add(typeof(ApiExceptionFilter));
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
        

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

builder.Services.AddAutoMapper(typeof(ProdutoDTOMappingProfile));

var app = builder.Build();

builder.Services.AddTransient<IMeuServico, MeuServico>();
builder.Services.AddScoped<ApiLoggingFilter>();
builder.Services.AddScoped<ICategoriaRepository, CategoriasRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ConfigureExceptionHandler();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
