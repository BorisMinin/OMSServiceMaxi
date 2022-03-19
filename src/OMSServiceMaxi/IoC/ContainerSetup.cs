using OMSServiceMaxi.Maps;
using OMSServiceMaxi.Maps.Interfaces;

namespace OMSServiceMaxi.IoC
{

    /// <summary>
    /// Класс для хранения регистрации служб
    /// </summary>
    public static class ContainerSetup
    {
        public static void Setup(IServiceCollection services)
        {
            ConfigureAutoMapper(services);
        }

        private static void ConfigureAutoMapper(IServiceCollection services)
        {
            // инициализация конфигурации
            var mapperConfig = AutoMapperConfigurator.Configure(); 
            // создание маппера для маппинга DTO на Entity и наоборот
            var mapper = mapperConfig.CreateMapper();
            // регистрация создания маппера, создание только одного экземпляра (AddSingleton)
            services.AddSingleton(x => mapper); 
            // регистрация зависимостей IAutoMapper и AutoMapperAdapter в DI
            services.AddTransient<IAutoMapper, AutoMapperAdapter>();  
        }
    }
}