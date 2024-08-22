using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using ProductsApi.Data.Contexts;
using ProductsApi.Data.Entities;
using ProductsApi.v1.Auth.Services.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddIdentity<User,IdentityRole<Guid>>(opt =>
{
    opt.Password.RequiredLength = 7;
    opt.Password.RequireDigit = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireNonAlphanumeric = false;

    opt.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(Program)));

builder.Services.Configure<KestrelServerOptions>(x =>
{
    x.Limits.MaxRequestBodySize = 1000_000_000;
});
builder.Services.Configure<FormOptions>(x =>
{
    x.MultipartBodyLengthLimit = 50_000_000;
});
builder.Services.AddEntityFrameworkCore();

builder.Services.AddServiceConfiguration()
    .AddSwaggerService(builder.Configuration);
builder.Services.AddAuthorization();

var app = builder.Build();

//app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();


app.UseStaticFiles();
app.MapControllers();

app.Run();












/*app.Use(async (x, y) =>
{
    Console.Out.WriteLine(3);
    await y();
    Console.Out.WriteLine(4);
    //
});*/


/*app.Use(async (x, y) =>
{
    Console.Out.WriteLine(1);
    if (x.User.Identity.IsAuthenticated)
    {

    }
    Console.Out.WriteLine(2);
     await y();
    //
});*/