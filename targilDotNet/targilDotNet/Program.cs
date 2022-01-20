// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;

namespace targilDotNet
{
    class Program
    {
        
        
        
        
        private static KeyPressContext context=new KeyPressContext();
        static void Main(string[] args)
        {
            context.Database.EnsureCreated();
               var Configuration = new ConfigurationBuilder()

              .AddJsonFile("appsettings.json", false)
                  .Build();
            Console.WriteLine("let's start!!");
            //instance of class CountKeyPress
            var CountKeyPress =new CountKeyPress(Configuration);
        }

    }
}