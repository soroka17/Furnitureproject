
namespace Mapping
{
    public class Program
    {
        //Точка входа в программу запуска сервиса маппинга
        public static void Main(string[] args)
        {
            var host = CreateDefaultHost(args).Build();

            host.Run();
        }

        public static IHostBuilder CreateDefaultHost(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webHost =>
                {
                    webHost.UseStartup<Startup>();
                });
    }
}