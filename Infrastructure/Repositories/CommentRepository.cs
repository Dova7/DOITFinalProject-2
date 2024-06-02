using Application.Contracts.IRepositories;
using ForumProject.Entities;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CommentRepository : BaseRepository<Comment>, ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Comment> Update(Comment entity)
        {
            var entityFromDb = await _context.Comments.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (entityFromDb != null)
            {
                entityFromDb.Body = entity.Body;                
            }
            else
            {
                throw new ArgumentNullException();
            }
            _context.Comments.Update(entity);
            return entityFromDb;
        }
    }
}
