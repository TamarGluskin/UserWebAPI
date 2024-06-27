
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;



using UsersManagementConsist.Model;

namespace User_sManagementConsist.Model
{

   
        public class UserDbContext : DbContext
        {
            public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
            {
            }
            public DbSet<User> Users { get; set; }
        }
    
}

