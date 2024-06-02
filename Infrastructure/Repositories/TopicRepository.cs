using Application.Contracts.IRepositories;
using ForumProject.Entities;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TopicRepository : BaseRepository<Topic>, ITopicRepository
    {
        private readonly ApplicationDbContext _context;
        public TopicRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Topic> Update(Topic entity)
        {
            var entityFromDb = await _context.Topics.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (entityFromDb != null)
            {
                entityFromDb.Title = entity.Title;
                entityFromDb.State = entity.State;
                entityFromDb.Status = entity.Status;
                entityFromDb.Body = entity.Body;
            }
            else
            {
                throw new ArgumentNullException();
            }
            _context.Topics.Update(entityFromDb);
            return entityFromDb;
        }
    }
}
