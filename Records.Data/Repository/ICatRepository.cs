namespace Records.Data.Repository
{
    public interface ICatRepository
    {
        void AddRange<TSource>(IEnumerable<TSource> source);
        TResult Get<TResult>(string id);
        IEnumerable<TResult> GetAll<TResult>();
        TResult Insert<TResult, TSource>(TSource item);
        bool Remove(string id);
        void RemoveAll();
        void RemoveRange(params string[] ids);
        bool Update<TSource>(string id, TSource item);
        bool Exits(string id);
       
    }
}