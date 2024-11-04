// Data/AppDbContext.cs
using Microsoft.EntityFrameworkCore;

namespace RedditClone.Data 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Communities)
                .WithOne(c => c.Owner)
                .HasForeignKey(c => c.OwnerID);

            modelBuilder.Entity<Community>()
                .HasMany(c => c.Posts)
                .WithOne(p => p.Community)
                .HasForeignKey(p => p.CommunityID);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostID);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Votes)
                .WithOne(v => v.Post)
                .HasForeignKey(v => v.PostID);

            modelBuilder.Entity<Comment>()
                .HasMany(c => c.Votes)
                .WithOne(v => v.Comment)
                .HasForeignKey(v => v.CommentID);
        }
    }
}
