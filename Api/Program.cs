
namespace Api
{
    public class Program
    {
        //Точка входа в программу
        public static void Main(string[] args)
        {
            var host = CreateDefaultHost(args).Build(); // Создание хоста

            host.Run(); // Запуск хоста
        }

        public static IHostBuilder CreateDefaultHost(string[] args) => // Настройка хоста
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webHost =>
                {
                    webHost.UseStartup<Startup>(); // Настройка хоста по файлу Startup
                });
    }
}