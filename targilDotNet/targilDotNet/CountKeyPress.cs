using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection.Extensions;
namespace targilDotNet
{
    public class CountKeyPress
    {

        private static readonly Dictionary<char, int> _KeyDictionery = new Dictionary<char, int>();
        private KeyPressContext _context { get; set; }
        private readonly int _duration;

        public CountKeyPress(IConfiguration config, KeyPressContext context)
        {
            _context = context;
            // config.GetConnectionString;
            _duration = config.GetValue<int>("DurationBySeconds");
           // CountPress(duration);

        }


        public void CountPress()
        {

           Stopwatch timer = new Stopwatch();
            timer.Start();
            var thisTime = DateTime.Now;
          //   while (DateTime.Now <= thisTime.AddSeconds(_duration))
           while (timer.Elapsed.TotalSeconds < _duration)
            {
               var input = Console.ReadKey();
                char inputChar = input.KeyChar;
                if (input.Key == ConsoleKey.Escape)
                    break;

                if (_KeyDictionery.ContainsKey(inputChar))
                    _KeyDictionery[inputChar]++;
                else
                    _KeyDictionery.Add(inputChar, 1);
            }
           // timer.Stop();

            InsertToDb(thisTime);

        }
        private void InsertToDb(DateTime thisTime)
        {
            // using (var context = new KeyPressContext())
            {
                foreach (KeyValuePair<char, int> entry in _KeyDictionery)
                {
                    var Key = new Key()
                    {
                        _count = entry.Value,
                        _keyName = entry.Key,
                        _startTimeastamp = thisTime
                    };

                    _context.Add(Key);
                };

                
                _context.SaveChanges();
            }

        }

    }
}
