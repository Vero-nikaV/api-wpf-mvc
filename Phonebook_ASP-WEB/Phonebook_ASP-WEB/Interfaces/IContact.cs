namespace Phonebook_ASP_WEB.Interfaces
{
    /// <summary>
    /// Интерфейс, описывающий контакт из телефонной книги
    /// </summary>
    public interface IContact
    {
        /// <summary>
        /// id контакта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string? Surname { get; set; }


        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string? Patronimic { get; set; }

        /// <summary>
        /// Телефон
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Адрес
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }
    }
}



