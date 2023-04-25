using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phonebook_ASP_WEB.Interfaces;
using Phonebook_ASP_WEB.Models;

namespace Phonebook_ASP_WEB.Controllers
{  /// <summary>
   /// Контроллер для страницы создания контакта
   /// </summary>
    [Authorize]
    public class NewContactController : Controller
    {
        IContactData db;
        public NewContactController(IContactData contactData)
        {
            db = contactData;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Проверка для нового контактк
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Check(Contact contact)
        {
            if (ModelState.IsValid)
            {

                db.AddContact(contact);
                return Redirect("/");
            }
            return View("Index");
        }
    }
}
