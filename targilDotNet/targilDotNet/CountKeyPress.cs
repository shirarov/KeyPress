using Microsoft.Extensions.Configuration;

namespace targilDotNet
{
    public class CountKeyPress
    {

        private readonly IConfiguration config;

        private static Dictionary<char, int> _KeyDictionery = new Dictionary<char, int>();


        public CountKeyPress(IConfiguration config)
        {
            this.config = config;
            var duration = config.GetValue<int>("Duration");
            CountPress(duration);
        }
        public static void CountPress(int duration)
        {
            var thisTime = DateTime.Now;
          while(DateTime.Now <= thisTime.AddMinutes( duration))
            {
                var s = Console.Read();
                char c = Convert.ToChar(s);

                if (_KeyDictionery.ContainsKey(c))
                    _KeyDictionery[c]++;
                else
                    _KeyDictionery.Add(c, 1);
            }

            insertToDb(thisTime);
        }
        private static void insertToDb(DateTime thisTime)
        {
            using (var context = new KeyPressContext())
            {
                foreach (KeyValuePair<char, int> entry in targilDotNet.CountKeyPress._KeyDictionery)
                {
                    var Key = new Key
                    {
                        Count = entry.Value,
                        KeyName = entry.Key,
                        startTimeastamp = thisTime
                    };

                    context.Add(Key);
                };

                context.SaveChanges();
            }

        }

    }
}
