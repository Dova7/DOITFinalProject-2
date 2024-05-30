using Application.Contracts.Interfaces;
using ForumProject.Entities;

namespace Application.Contracts.IRepositories
{
    public interface ITopicRepository : IBaseRepository<Topic>, IFullyUpdatable<Topic>, ISavable
    {

    }
}
