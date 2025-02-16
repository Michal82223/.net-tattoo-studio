using Microsoft.EntityFrameworkCore;
using NetTattoos.Web.Models.Entities;

namespace NetTattoos.Web.Data

{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {   
        }

        public DbSet<Visit> Visits { get; set; }
    }
}
