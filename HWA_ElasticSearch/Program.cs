using HWA_ElasticSearch.Service.Abstract;
using HWA_ElasticSearch.Service.Concrete;
using Nest;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//ElasticSearch için konfigürasyon ayarları ekliyoruz.
var settings = new ConnectionSettings(new Uri("http://localhost:9200/"))
    .DefaultIndex("max")
    .BasicAuthentication(builder.Configuration["ElasticSearchConfig:Username"], builder.Configuration["ElasticSearchConfig:Password"]);
var client = new ElasticClient(settings);
builder.Services.AddSingleton(client);

builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
