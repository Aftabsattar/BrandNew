using Curate.Application;
using Curate.Application.Interface;
using Curate.Application.Interface.Auth;
using Curate.Application.IServices;
using Curate.Domain.Entities.EmailSetting;
using Curate.Infrastructre.Context;
using Curate.Infrastructre.Repository;
using Curate.Infrastructre.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.Configure<Email>(builder.Configuration.GetSection("SmtpSetting"));
builder.Services.Configure<Email>(builder.Configuration.GetSection("Jwt"));
builder.Services.AddScoped<IIdeaService, IdeaService>();
builder.Services.AddScoped<IIdeaRepository, IdeaRepository>();
builder.Services.AddScoped<IOtpService, OtpService>();
builder.Services.AddScoped<IOtpRepository, OtpRepository>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IJwtService, JwtService>();
//builder.Services.AddScoped<>
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IUserRegisterService, UserRegisterService>();
builder.Services.AddScoped<IUserRegisterRepository, UserRegisterRepository>();
builder.Services.AddApplication();
builder.Services.AddControllers();
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
app.UseStaticFiles();
app.Run();
