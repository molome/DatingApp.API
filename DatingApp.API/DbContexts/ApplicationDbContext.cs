using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.DbContexts
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options){}

        public DbSet<Record> Records { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
