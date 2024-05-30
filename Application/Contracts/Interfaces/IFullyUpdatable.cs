namespace Application.Contracts.Interfaces
{
    public interface IFullyUpdatable<T> where T : class
    {
        Task<T> Update(T entity);
    }
}
