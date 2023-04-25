using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phonebook_ASP_WEB.Interfaces;
using Phonebook_ASP_WEB.Models;
using System.Data;

namespace Phonebook_ASP_WEB.Controllers
{

        /// <summary>
        /// Контроллер, определяющий логику страницы с карточкой определенного контакта
        /// </summary>
        public class CertainContactController : Controller
        {
            IContactData db;
            public CertainContactController(IContactData contactData)
            {
                db = contactData;
            }

            /// <summary>
            /// Перевод на url-адрес определнной карточки, передача в представление выбранного контакта (определенного по id)
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            [Route("CertainContact/{Id:int}")]
            public IActionResult Index(int id)
            {
                return View(db.GetContact(id));
            }


            /// <summary>
            /// Метод для удаления контакта
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>

            [Authorize(Roles = "admin")]
            public async Task<IActionResult> Delete(int id)
            {
                db.DeleteContact(id);
                return Redirect("/");
            }
            /// <summary>
            /// Метод для открытия страницы для редактирования
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            [Authorize(Roles = "admin")]
            public async Task<IActionResult> Update(int id)
            {
                Contact contact = db.GetContact(id);
                if (contact != null)
                    return View(contact);
                return NotFound();
            }
            /// <summary>
            /// Метод для сохранения изменений
            /// </summary>
            /// <param name="contact"></param>
            /// <returns></returns>
            [HttpPost]
            public async Task<IActionResult> Update(Contact contact)
            {
                db.UpdateContact(contact);
                return Redirect("/");
            }

        }
    }
