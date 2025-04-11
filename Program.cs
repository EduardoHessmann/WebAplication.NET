using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Runtime.CompilerServices;
using WebApplication1;
using WebApplication1.Context;
using WebApplication1.Mapeadores;
using WebApplication1.Modelos.DAO.CepDAO;
using WebApplication1.Modelos.DAO.ClienteDAO;
using WebApplication1.Modelos.DAO.EnderecoDAO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApiVersioning(options =>
{
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1);
    options.ReportApiVersions = true;
})
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddSwaggerGen(c =>
{
    c.EnableAnnotations();
    c.SupportNonNullableReferenceTypes();

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfiguracoesSwagger>();
builder.Services.AddSingleton<IServiceCep, ServiceCepImpl>();

builder.Services.AddDbContext<VHubContext>(
(serviceProvider, options) =>
{
options.UseNpgsql(
    builder.Configuration.GetConnectionString(nameof(VHubContext))
        ?? throw new Exception($"Não é possível determinar a string de conexão do {nameof(VHubContext)}"))
    .UseSnakeCaseNamingConvention();
    },
ServiceLifetime.Scoped);


var config = new MapperConfiguration(cfg => cfg.AddMaps(typeof(MapearCliente).Assembly));
config.AssertConfigurationIsValid();
config.CompileMappings();
builder.Services.AddSingleton<IMapper>(e => new Mapper(config));
builder.Services.AddMediator((Mediator.MediatorOptions options) =>
{
    options.Namespace = "WebApplication1";
    options.ServiceLifetime = ServiceLifetime.Scoped;
});




var app = builder.Build();
var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"{description.GroupName.ToUpperInvariant()}");
        }

        options.EnableFilter();
    });
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

var serviceProvider = app.Services.GetRequiredService<IServiceProvider>();

serviceProvider.CreateScope().ServiceProvider.GetRequiredService<VHubContext>().AplicarMigracoes();

app.Run();
