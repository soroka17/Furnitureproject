
namespace Api
{
    public class Program
    {
        //����� ����� � ���������
        public static void Main(string[] args)
        {
            var host = CreateDefaultHost(args).Build(); // �������� �����

            host.Run(); // ������ �����
        }

        public static IHostBuilder CreateDefaultHost(string[] args) => // ��������� �����
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webHost =>
                {
                    webHost.UseStartup<Startup>(); // ��������� ����� �� ����� Startup
                });
    }
}