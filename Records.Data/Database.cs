using Records.Data.Entities;
using System.Data;

namespace Records.Data
{
    public class Database<T> : IDatabase<T> where T : BaseEntity
    {

        private readonly Dictionary<string, T> _storage;
        public Database()=> _storage = new() { };
      
        public T Insert(T candidate)
        {

            while(Exist(candidate.Id.ToString()))
            {
                candidate.Id=Guid.NewGuid();
            }

            _storage.Add(candidate.Id.ToString(), candidate);
            return candidate;

        }
        public bool Update(string Id, T candidate)
        {

            var result=Get(Id) ?? throw new InvalidOperationException($"Could not find any record to update for Id:{Id}");
            candidate.Id = Guid.Parse(Id);
            candidate.CreatedAt=result.CreatedAt;
            _storage[Id]= candidate;
            return true;
        }
        public bool Remove(string Id)
        {
            return _storage.Remove(Id);

        }
        public T? Get(string Id)
        {
            _ = _storage.TryGetValue(Id, out T result);
            return result;
        }

        public IEnumerable<T> GetAll()
        {
            return _storage.Values;
        }
        public void RemoveRange(params string[] Ids)
        {
            foreach (var id in Ids)
            {
                Remove(id.ToString());
            }
        }
        public void RemoveAll()
        {
            _storage.Clear();
        }
        public bool AddRange(IEnumerable<T> candidates)
        {

            foreach (var item in candidates)
            {
                if (_storage.ContainsKey(item.Id.ToString()))
                {
                    continue;
                }
                Insert(item);
            }
            return true;

        }
        public bool Exist(string Id)
        {
            return _storage.ContainsKey(Id);

        }


    }


}