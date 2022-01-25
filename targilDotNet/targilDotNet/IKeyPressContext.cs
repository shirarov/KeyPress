using Microsoft.EntityFrameworkCore;

namespace targilDotNet
{
    public interface IKeyPressContext
    {
        DbSet<Key> Keys { get; set; }
    }
}