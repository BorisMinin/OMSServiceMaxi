using AutoMapper;

namespace OMSServiceMaxi.Maps.Interfaces
{
    public interface IAutoMapperTypeConfigurator
    {
        void Configure(IMapperConfigurationExpression configuration);
    }
}