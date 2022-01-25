// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;

namespace targilDotNet
{
    class Program
    {

        private static KeyPressContext context;

        static void Main(string[] args)
        {

            Console.WriteLine("let's start!!");
            Console.WriteLine("please press Esc to stop ");

            var Configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json", true)
                  .Build();

            context = new KeyPressContext(Configuration);
            context.Database.EnsureCreated();
            //instance of class CountKeyPress
            var countKeyPress = new CountKeyPress(Configuration, context);

            countKeyPress.CountPress();
           
        }

    }
}