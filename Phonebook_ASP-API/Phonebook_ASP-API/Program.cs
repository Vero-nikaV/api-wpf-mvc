
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Phonebook_ASP_API.Data;
using Phonebook_ASP_API.Interfaces;
using Phonebook_ASP_API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IContactRepository, ContactRepository>();



string connection = "Data Source = (localdb)\\MSSQLLocalDB; AttachDBFilename =" +
            Path.Combine(Directory.GetCurrentDirectory(), "App_Data\\db21.mdf") + "; Trusted_Connection = True; Integrated Security = True";

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));



var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
