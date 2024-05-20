using ForumProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public static class Constraints
    {
        public static void TopicConstraints(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topic>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Topic>().HasMany(x=>x.Comments).WithOne(x => x.Topic).OnDelete(DeleteBehavior.Cascade);
        }
        public static void CommentConstraints(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            });
            modelBuilder.Entity<Comment>().HasOne(x=>x.Topic).WithMany(x=>x.Comments).HasForeignKey(x=>x.TopicId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
