using Microsoft.Extensions.Logging.Configuration;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using Serilog.Configuration;
using Serilog.Formatting.Json;
using Microsoft.AspNetCore;
using ApiImob.IOC;


var builder = WebApplication.CreateBuilder(args);

#if DEBUG
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();
#else   
    Log.Logger = new LoggerConfiguration()
        .MinimumLevel.ControlledBy(LogLevelSwitcher.Switcher)
        .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .WriteTo.Console(new JsonFormatter())
        .CreateLogger();    
#endif

// Add services to the container.
// Aqui seria o Configure Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>{c.SwaggerDoc("v1", new OpenApiInfo { Title = "ApiImob.WebApi", Version = "v1" });});
builder.Services.AddDependencyInjection();
var app = builder.Build();

// Configure the HTTP request pipeline.
// Aqui seria o Metodo Configure
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiImob.WebApi v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

// habilita o cors para qualquer metodo
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllers();

app.Run();
