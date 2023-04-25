using Phonebook_ASP_WEB.Models;

namespace Phonebook_ASP_WEB.Interfaces
{
    public interface IContactData
    {
        /// <summary>
        /// Получение всех контактов
        /// </summary>
        /// <returns></returns>
        IEnumerable<Contact> GetContacts();
        /// <summary>
        /// Получение контакта по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Contact GetContact(int id);
        /// <summary>
        /// Добавить контакт
        /// </summary>
        /// <param name="contact"></param>
        void AddContact(Contact contact);
        /// <summary>
        /// Удалить контакт
        /// </summary>
        /// <param name="id"></param>
        void DeleteContact(int id);
        /// <summary>
        /// Редактировать контакт
        /// </summary>
        /// <param name="contact"></param>
        void UpdateContact(Contact contact);
    }
}
