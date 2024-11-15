using Microsoft.EntityFrameworkCore;
using PatikaPratikJwt.Entities;

namespace PatikaPratikJwt.Context
{
    public class PatikaPratikJwtDbContext : DbContext
    {
        public PatikaPratikJwtDbContext(DbContextOptions<PatikaPratikJwtDbContext> options) : base(options)
        {

        }

        public DbSet<UserEntity> Users => Set<UserEntity>();
    }
}
