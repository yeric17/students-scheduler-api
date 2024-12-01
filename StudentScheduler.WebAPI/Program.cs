

using StudentScheduler.infrastructure;
using StudentScheduler.Application;
using StudentScheduler.Domain.Entities;
using StudentScheduler.WebAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication();

builder.Services
    .AddInfrastructureLayer(builder.Configuration)
    .AddApplicationLayer();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGroup("/api")
    .MapGroup("/account").MapUsers()
    .MapGroup("/enrollments").MapEnrollment();


app.MapIdentityApi<User>();

app.MapControllers();

app.Run();
