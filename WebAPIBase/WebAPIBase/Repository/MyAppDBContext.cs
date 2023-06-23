using Microsoft.EntityFrameworkCore;
using WebAPIBase.Models;

namespace WebAPIBase.Repository
{
    public class MyAppDBContext : DbContext
    {
        public MyAppDBContext()
        {
            
        }

        public MyAppDBContext(DbContextOptions<MyAppDBContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
