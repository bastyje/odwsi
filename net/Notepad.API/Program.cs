using Microsoft.EntityFrameworkCore;
using Notepad.API.Identity;
using Notepad.API.Services;
using Notepad.API.Services.Interfaces;
using Notepad.Data.DbContexts;
using Notepad.Data.Repositories;
using Notepad.Data.Repositories.Interfaces;
using Notepad.Service.Services;
using Notepad.Service.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

const string corsPolicyName = "NotepadCorsPolicy";

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureIdentityServer();

builder.Services.AddDbContext<NotepadDbContext>(options =>
{
    options.UseSqlServer("Server=localhost,1400;Database=notepad;User ID=sa;Password=Password123;");
});

builder.Services.AddAuthentication("Bearer").AddJwtBearerConfiguration("http://localhost:5013");

// builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
// {
//     options.RequireHttpsMetadata = false;
//     options.Authority = "http://localhost:5001";
//     options.Audience = "NotepadAngularApp";    options.TokenValidationParameters = new()
//     {
//         ValidateAudience = false
//     };
// });


builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();

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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors(corsPolicyName);

app.MapControllers();

app.Run();
