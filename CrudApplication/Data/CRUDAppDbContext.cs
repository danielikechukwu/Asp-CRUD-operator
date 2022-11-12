using CrudApplication.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace CrudApplication.Data
{
    public class CRUDAppDbContext : DbContext
    {
        public CRUDAppDbContext(DbContextOptions<CRUDAppDbContext> options) 
            : base(options)
        {

        }

        public DbSet<Employee> employees { get; set; }
    }
}
