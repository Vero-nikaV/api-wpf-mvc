using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Phonebook_ASP_WEB.Models;

namespace Phonebook_ASP_WEB.Data
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<User> User { get; set; } = null!;
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
    }
}
