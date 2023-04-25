using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Phonebook_ASP_API.Models;

namespace Phonebook_ASP_API.Data
{
    public class DataContext : DbContext 
    {
        public DbSet<Contact> Contacts { get; set; } = null!; 
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }
    }
}
