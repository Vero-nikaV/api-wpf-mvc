using Microsoft.AspNetCore.Mvc;
using Phonebook_ASP_WEB.Interfaces;
using Phonebook_ASP_WEB.Models;
using System.Diagnostics;

namespace Phonebook_ASP_WEB.Controllers
{   /// <summary>
    /// Контроллер, определяющий логику главной страницы 
    /// </summary>
    public class HomeController : Controller
    {
        IContactData db;
        public HomeController(IContactData contactData)
        {
            db = contactData;
        }

        /// <summary>
        /// Передача в представление списка контактов из репозитория
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {

            return View(db.GetContacts());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}