using todo.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace toddo.Api.Context
{
    public class TodoContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}