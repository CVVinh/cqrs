using cqrs_vhec.Data;
using cqrs_vhec.Service.Mongo;
using cqrs_vhec.Service.Postgre;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

builder.Services.AddSingleton<MongoDBContext>();
// Add PostgreSQL
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<PostgreDBContext>(option =>
option.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLDatabase")));

// postgre interface init
builder.Services.AddScoped<IDetailInformationTypeProductPgService, DetailInformationTypeProductPgService>();
builder.Services.AddScoped<IInformationProductPgService, InformationProductPgService>();
builder.Services.AddScoped<IInformationTypeProductPgService, InformationTypeProductPgService>();
builder.Services.AddScoped<IProductImgPgService, ProductImgPgService>();
builder.Services.AddScoped<IProductPgService, ProductPgService>();
builder.Services.AddScoped<ITypeProductPgService, TypeProductPgService>();

// interface mongodb
builder.Services.AddScoped<IProductMgService, ProductMgService>();


// Add services to the container.

builder.Services.AddControllers();

// Ignore cycle
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
