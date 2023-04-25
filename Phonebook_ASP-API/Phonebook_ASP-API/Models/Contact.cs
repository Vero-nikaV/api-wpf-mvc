using Phonebook_ASP_API.Interfaces;

namespace Phonebook_ASP_API.Models
{
    public class Contact : IContact
    {
        public int Id { get; set; }

        public string? Surname { get; set; }

        public string? Name { get; set; }

        public string? Patronimic { get; set; }

        public string Phone { get; set; }

        public string? Address { get; set; }

        public string? Description { get; set; }
    }
}
