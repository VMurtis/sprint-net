using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.ResponseCompression;
using Challenge.Infrastructure.Data;
using Challenge.Infrastructure.Data.Repository;
using Challenge.Infrastructure.Data.Interfaces;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// --- Logging detalhado para identificar erros ---
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

// --- DbContext (comente temporariamente se quiser testar sem Oracle) ---
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("Oracle"));
});

// --- Swagger com exemplos ---
builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.ExampleFilters(); // habilita exemplos do pacote
});

// Registrar exemplos (certifique-se de ter pelo menos um exemplo implementado)
builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();

// --- Compressão ---
builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<BrotliCompressionProvider>();
    options.Providers.Add<GzipCompressionProvider>();
});
builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
{
    options.Level = System.IO.Compression.CompressionLevel.Fastest;
});
builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = System.IO.Compression.CompressionLevel.Fastest;
});

// --- Injeção de dependência ---
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

// --- Controllers ---
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// --- Apenas uma chamada ao AddSwaggerGen ---
/* Já feita acima */

// --- Build ---
var app = builder.Build();

// --- Developer Exception Page para ver stack trace ---
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // mostra erros detalhados
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
