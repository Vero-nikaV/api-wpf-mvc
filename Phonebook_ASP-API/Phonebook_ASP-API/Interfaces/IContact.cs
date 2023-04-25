using System.ComponentModel.DataAnnotations;

namespace Phonebook_ASP_API.Interfaces
{
    public interface IContact
    {
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
        [Required]
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

