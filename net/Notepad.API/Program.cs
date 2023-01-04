using System.Net;
using Duende.IdentityServer.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Notepad.API.Identity;
using Notepad.API.Services;
using Notepad.API.Services.Interfaces;
using Notepad.Data.DbContexts;
using Notepad.Data.Repositories;
using Notepad.Data.Repositories.Interfaces;
using Notepad.Service.Services;
using Notepad.Service.Services.Interfaces;

const string corsPolicyName = "NotepadCorsPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel(options =>
{
    options.AddServerHeader = false;
}).UseUrls("http://*:80", "https://*:443");

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureIdentityServer();

builder.Services.AddDbContext<NotepadDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration["Data:ConnectionString"]);
});

builder.Services.AddAuthentication("Bearer").AddJwtBearerConfiguration(builder.Configuration["Authority"]);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

// builder.Services.Configure<ForwardedHeadersOptions>(options =>
// {
//     options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
// });
    

builder.Services.AddCors(options =>
{
    var urls = builder.Configuration
        .GetSection("Application:Urls")
        .GetChildren()
        .Select(x => x.Value)
        .ToArray();
    
    options.AddPolicy(corsPolicyName, builder => builder
        .WithOrigins(urls)
        .AllowAnyHeader()
        .AllowAnyMethod());
});


var app = builder.Build();

// app.UseForwardedHeaders();
app.UseHsts();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.Use((context, next) =>
// {
//     context.Request.Scheme = "https";
//     return next();
// });
app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(corsPolicyName);

app.MapControllers();

app.Run();
