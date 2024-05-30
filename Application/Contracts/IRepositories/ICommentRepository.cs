using Application.Contracts.Interfaces;
using ForumProject.Entities;

namespace Application.Contracts.IRepositories
{
    public interface ICommentRepository : IBaseRepository<Comment>, IFullyUpdatable<Comment>, ISavable
    {

    }
}
