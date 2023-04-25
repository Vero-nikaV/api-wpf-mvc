using Microsoft.AspNetCore.Identity;

namespace Phonebook_ASP_WEB.Models
{
    public class User : IdentityUser
    {
        /// <summary>
        /// поле, определяющее является ли пользователь администратором 
        /// (необходимо для вывода статуса в панеле администратора)
        /// </summary>
        public int idRole { get; set; }
        public User()
        {
            idRole = 1;
        }

    }
}
