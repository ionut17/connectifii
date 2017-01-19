namespace Core
{
    public interface IGroupRepository<T> : IRepository<T> where T : class, IEntity
    {
    }
}