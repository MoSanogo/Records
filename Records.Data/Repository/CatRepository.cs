using AutoMapper;
using Records.Data.Entities;
namespace Records.Data.Repository
{
    public class CatRepository : ICatRepository
    {
        private readonly IDatabase<Cat> _catDatabase;
        private readonly IMapper _mapper;

        public CatRepository(IDatabase<Cat> catDatabase, IMapper mapper) => (_catDatabase, _mapper) = (catDatabase, mapper);
        public IEnumerable<TResult> GetAll<TResult>()
        {
            var result = _catDatabase.GetAll();

            return _mapper.Map<List<TResult>>(result);
        }

        public TResult Get<TResult>(string id)
        {
            var result= _catDatabase.Get(id);
            return _mapper.Map<TResult>(result);
        }

        public bool Remove(string id)
        {
            return _catDatabase.Remove(id);
        }

        public TResult Insert<TResult, TSource>(TSource item) 
        {
            var candidate = _mapper.Map<Cat>(item);
            var result = _catDatabase.Insert(candidate);
            return _mapper.Map<TResult>(result);
        }


    
        public bool Update<TSource>(string id, TSource item)
        {
              var candidate=_mapper.Map<Cat>(item);
            var result = _catDatabase.Update(id, candidate);

            return result;
        }
        public void RemoveRange(params string[] ids)
        {
            _catDatabase.RemoveRange(ids);
        }
        public void RemoveAll()
        {
            _catDatabase.RemoveAll();
        }
        public void AddRange<TSource>(IEnumerable<TSource> candidates)
        {
            var result=_mapper.Map<List<Cat>>(candidates);
            _catDatabase.AddRange(result);
        }

        public bool Exits(string id)
        {
           return _catDatabase.Exist(id);
        }

  
    }
}
