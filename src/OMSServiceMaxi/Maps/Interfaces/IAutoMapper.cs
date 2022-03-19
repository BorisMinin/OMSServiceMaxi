namespace OMSServiceMaxi.Maps.Interfaces
{
    /// <summary>
    /// Интерфейс для классов, в которых происходит сопоставление
    /// </summary>
    public interface IAutoMapper
    {
        AutoMapper.IConfigurationProvider Configuration { get; } // 

        T Map<T>(object objectToMap);

        void Map<TSource, TDestination>(TSource source, TDestination destination);

        TResult[] Map<TSource, TResult>(IEnumerable<TSource> sourceQuery);
    }
}