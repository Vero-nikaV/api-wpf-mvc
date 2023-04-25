using Microsoft.AspNetCore.Mvc;
using Phonebook_ASP_API.Interfaces;
using Phonebook_ASP_API.Models;

namespace Phonebook_ASP_API.Controllers
{
    [Route("api/[controller]")]
    public class ContactController : Controller
    {

        IContactRepository db;

        public ContactController(IContactRepository db)
        {
            this.db = db;
        }
        /// <summary>
        /// Получние всех контактов
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetAllContacts")]
        public IEnumerable<Contact> GetContacts()
        {
            return db.Getcontacts();
        }

        /// <summary>
        /// Получение контакта по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetContact")]
        public IActionResult GetContact(int id)
        {
            Contact contact = db.GetContact(id);

            if (contact == null)
            {
                return NotFound();
            }

            return new ObjectResult(contact);
        }

        /// <summary>
        /// Создание контакта
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create([FromBody] Contact contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }
            db.CreateContact(contact);
            return CreatedAtRoute("GetContact", new { id = contact.Id }, contact);
        }

        /// <summary>
        /// Редактирование контакта
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updatedContact"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Contact updatedContact)
        {
            if (updatedContact == null || updatedContact.Id != id)
            {
                return BadRequest();
            }

            Contact contact = db.GetContact(id);
            if (contact == null)
            {
                return NotFound();
            }

            db.UpdateContact(updatedContact);
            return new ObjectResult(contact);
        }

        /// <summary>
        /// Удаление контакта
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var deletedContact = db.DeleteContact(id);

            if (deletedContact == null)
            {
                return BadRequest();
            }
            return new ObjectResult(deletedContact);
        }
    }
}
