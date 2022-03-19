using AutoMapper;
using OMSServiceMaxi.Maps.Interfaces;

namespace OMSServiceMaxi.Maps
{
    public class AutoMapperAdapter : IAutoMapper
    {
        private readonly IMapper _mapper;

        public AutoMapperAdapter(IMapper mapper)
        {
            _mapper = mapper;
        }
        public AutoMapper.IConfigurationProvider Configuration => _mapper.ConfigurationProvider;

        public T Map<T>(object objectToMap)
        {
            return _mapper.Map<T>(objectToMap);
        }

        public void Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            _mapper.Map(source, destination);
        }

        public TResult[] Map<TSource, TResult>(IEnumerable<TSource> sourceQuery)
        {
            return sourceQuery.Select(x => _mapper.Map<TResult>(x)).ToArray();
        }

        // Добавить IQueryable, ведь ProjectTo это https://docs.automapper.org/en/stable/Dependency-injection.html#queryable-extensions
    }
}