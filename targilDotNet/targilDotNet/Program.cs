// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace targilDotNet
{
    class Program
    {

      //  private static KeyPressContext context;

        static void Main(string[] args)
        {

            Console.WriteLine("let's start!!");
            Console.WriteLine("please press Esc to stop ");

            var Configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", true)
                  .Build();

            //context = new KeyPressContext(Configuration);
            // context.Database.EnsureCreated();
            //instance of class CountKeyPress
            //  var countKeyPress = new CountKeyPress(Configuration, context);
            // countKeyPress.CountPress();


            using var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>

                    services.AddDbContext<KeyPressContext>(o => o.UseSqlServer(Configuration.GetValue<string>("ConnectionString")))
                        .AddSingleton<ICountKeyPress, CountKeyPress>())
                      //.AddSingleton<IConfiguration>())
                    .Build();


            var s = host.Services.GetRequiredService<KeyPressContext>().Database.EnsureCreated();

            host.Services.GetRequiredService<ICountKeyPress>().CountPress();

        }

    }
}