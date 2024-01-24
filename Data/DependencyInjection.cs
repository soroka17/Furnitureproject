using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DependencyInjection
    {
        //Метод расширения, для внедерения зависимостей
        public static void AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection"); // Получаем стркоу подключения из конфигурации(appsettings.json)
            services.AddDbContext<AppDbContext>(options => // Добавляем контекст в контейнер
            {
                options.UseNpgsql(connectionString); // говорим использовать postgresql
            });

            services.AddScoped<IAppDbContext, AppDbContext>(); // регистрируем сервис IAppDbContext

            services.AddScoped<IRepository<Product>, BaseRepository<Product>>(); // Регистрируем сервисы репозиториев для сущностей
            services.AddScoped<IRepository<Category>, BaseRepository<Category>>();
        }
    }
}
