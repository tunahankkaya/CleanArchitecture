using Application;
using Core.CrossCuttingConcerns.Exceptions.Extensions;
using Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);

builder.Services.AddDistributedMemoryCache(); //cache i�in (InMemory)

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if(app.Environment.IsProduction())
    app.ConfigureCustomExceptionMiddleware(); //b�t�n yap�y� middleware'den ge�ir. bu method core'dan geliyor.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
