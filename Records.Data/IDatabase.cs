using Records.Data.Entities;

namespace Records.Data
{
    public interface IDatabase<T> where T : BaseEntity
    {
        bool AddRange(IEnumerable<T> candidates);
        T? Get(string id);
        IEnumerable<T> GetAll();
        T Insert(T candidate);
        bool Remove(string id);
        void RemoveAll();
        void RemoveRange(params string[] ids);
        bool Update(string id, T candidate);
        bool Exist(string id);
    }
}