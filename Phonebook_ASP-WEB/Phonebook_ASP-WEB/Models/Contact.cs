using Phonebook_ASP_WEB.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Xml.Linq;

namespace Phonebook_ASP_WEB.Models
{   /// <summary>
    /// Класс, описывающий контакт из телефонной книги
    /// </summary>
    public class Contact : IContact
    {

        public int Id { get; set; }

        [Display(Name = "Введите фамилию")]
        [Required(ErrorMessage = "Поле является обязательным")]
        public string? Surname { get; set; }

        [Display(Name = "Введите имя")]
        [Required(ErrorMessage = "Поле является обязательным")]
        public string? Name { get; set; }

        [Display(Name = "Введите отчество")]
        public string? Patronimic { get; set; }

        [Display(Name = "Введите телефон")]
        [Required(ErrorMessage = "Поле является обязательным")]
        public string? Phone { get; set; }

        [Display(Name = "Введите адрес")]
        public string? Address { get; set; }

        [Display(Name = "Описание")]
        public string? Description { get; set; }
    }
}
