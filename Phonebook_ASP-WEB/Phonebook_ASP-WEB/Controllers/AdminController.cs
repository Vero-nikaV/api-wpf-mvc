using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phonebook_ASP_WEB.Data;
using Phonebook_ASP_WEB.Interfaces;
using Phonebook_ASP_WEB.Models;
using System.Data;

namespace Phonebook_ASP_WEB.Controllers
{
    /// <summary>
    /// Класс, описывающий функционал страницы администратора
    /// </summary>
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<User> userManager;
        DataContext db;
        public AdminController(DataContext context, UserManager<User> userManager)
        {
            db = context;
            this.userManager = userManager;
        }

        /// <summary>
        /// Представлние, показывающие всех пользователей
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            return View(await db.Users.ToListAsync());
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> Delete(string? id)
        {
            User user = db.Users.Find(id);
            db.Entry(user).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            return Redirect("/Admin/Index");
        }

        /// <summary>
        /// Кнопка "назначить администратором"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> AdminOn(string? id)
        {
            User user = db.Users.Find(id);
            userManager.AddToRoleAsync(user, "admin");
            user.idRole = 2;
            db.SaveChangesAsync();
            return Redirect("/Admin/Index");
        }
        /// <summary>
        /// Кнопка "Снять функции администратора"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> AdminOff(string? id)
        {
            User user = db.Users.Find(id);
            userManager.RemoveFromRoleAsync(user, "admin");
            user.idRole = 1;
            db.Users.Update(user);
            db.SaveChangesAsync();
            return Redirect("/Admin/Index");
        }
    }
}