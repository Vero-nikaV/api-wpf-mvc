using Phonebook_ASP_API.Models;

namespace Phonebook_ASP_API.Interfaces
{
    public interface IContactRepository
    {

        /// <summary>
        /// Получение всех контактов
        /// </summary>
        /// <returns></returns>
        IEnumerable<Contact> Getcontacts();
        /// <summary>
        /// Получение контакта по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Contact GetContact(int id);
        /// <summary>
        /// Создание контакта
        /// </summary>
        /// <param name="item"></param>
        void CreateContact(Contact item);
        /// <summary>
        /// Редактирование контакта
        /// </summary>
        /// <param name="item"></param>
        void UpdateContact(Contact item);
        /// <summary>
        /// Удаление контакта
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Contact DeleteContact(int id);
    }
}
