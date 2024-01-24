using Data;

namespace Api
{
    public class Startup
    {
        //Конфигурация (appsettings.json)
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //Настройка http пайплайна
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });
        }

        //Регистрация сервисов в DI контейнере(контейнер зависимостей)
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(); // Добавляем контроллеры
            services.AddEndpointsApiExplorer(); // Добавляем эндпоинты
            services.AddSwaggerGen(); // Добавляем генерацию Swagger(автодокументация)
            services.AddPersistance(Configuration);// Добавляем базу данных
            services.AddHttpClient(); // Добавляем HttppClient
        }
    }
}
