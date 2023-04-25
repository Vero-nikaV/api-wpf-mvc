using System.ComponentModel.DataAnnotations;

namespace Phonebook_ASP_WEB.Models
{
    /// <summary>
    /// Вход в систему
    /// </summary>
    public class UserLogin
    {
        [Required, MaxLength(20)]
        public string LoginProp { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

    }
}