
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Phonebook_ASP_WEB.Data;
using Phonebook_ASP_WEB.Interfaces;
using Phonebook_ASP_WEB.Models;

var builder = WebApplication.CreateBuilder(args);

string connection = "Data Source = (localdb)\\MSSQLLocalDB; AttachDBFilename =" + 
    Path.Combine(Directory.GetCurrentDirectory(),"App_Data\\UsersData.mdf")  + "; Trusted_Connection = True; Integrated Security = True";
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connection));


builder.Services.AddTransient<IContactData, ContactDataAPI>();

builder.Services.AddControllersWithViews();


builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<DataContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 6; // минимальное количество знаков в пароле

});

builder.Services.ConfigureApplicationCookie(options =>
{
    // конфигурация Cookie с целью использования их для хранения авторизации
    options.Cookie.HttpOnly = true;
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.SlidingExpiration = true;
});
var app = builder.Build();




if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
