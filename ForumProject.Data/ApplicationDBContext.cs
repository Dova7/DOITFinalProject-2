using Microsoft.EntityFrameworkCore;

namespace ForumProject.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {

        }
    }
}
