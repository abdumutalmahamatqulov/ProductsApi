using System.Reflection;
using FluentValidation;
using ProductsApi.Data.Contexts;
using ProductsApi.v1.Auth.Services.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Program)));

builder.Services.AddControllersWithViews();

builder.Services.AddEntityFrameworkCore();

builder.Services.AddServiceConfiguration()
    .AddSwaggerService(builder.Configuration);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
