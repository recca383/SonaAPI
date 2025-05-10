using Microsoft.EntityFrameworkCore;

namespace SonaAPI.Data
{
    public class MBTIDataContext : DbContext
    {
        public MBTIDataContext(DbContextOptions options) : base(options)
        {
        }

    }
}
