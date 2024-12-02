

using StudentScheduler.infrastructure;
using StudentScheduler.Application;
using StudentScheduler.Domain.Entities;
using StudentScheduler.WebAPI.Endpoints;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using StudentScheduler.infrastructure.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddTransient<IClaimsTransformation, ClaimsTransformation>();

builder.Services
    .AddInfrastructureLayer(builder.Configuration)
    .AddApplicationLayer();


//add cors policy

string? allowedOrigins= builder.Configuration.GetValue<string>("AllowedOrigins");
string allowedHostsPolicyName = "AllowSpecificOrigin";

if(allowedOrigins is not null)
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(allowedHostsPolicyName,
            builder => builder.WithOrigins(allowedOrigins)
                              .AllowAnyHeader()
                              .AllowAnyMethod());
    });
}


var app = builder.Build();

app.UseCors(allowedHostsPolicyName);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add policy



app.UseHttpsRedirection();

app.UseAuthorization();

var apiGroup = app.MapGroup("/api");

apiGroup.MapGroup("/account").MapUsers();
apiGroup.MapGroup("/enrollments").MapEnrollment();
apiGroup.MapGroup("/subjects").MapSubjects();

apiGroup.MapIdentityApi<User>();

app.MapControllers();

app.Run();
