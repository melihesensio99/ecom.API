using ETicaretAPI.Persistence;
using FluentValidation.AspNetCore;
using FluentValidation;
using ETicaretAPI.Application.Validators.Products;
using ETicaretAPI.Infrastructure.Filters;
using ETicaretAPI.Infrastructure;
using ETicaretAPI.Infrastructure.Services.LocalStorage;
using ETicaretAPI.Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.InfrastructureServiceRegister();
builder.Services.ApplicationServiceRegister();
builder.Services.StorageServiceType<LocalStorage>();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddControllers(opt => opt.Filters.Add<ValidationFilter>()).ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true);
builder.Services.AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyMethod().AllowAnyHeader()));

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
