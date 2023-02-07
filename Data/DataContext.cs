using Microsoft.EntityFrameworkCore;
using StoredProcedureImplementing.Models;

namespace StoredProcedureImplementing.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }
        public DbSet<Customer> Customers { get; set; }
    }
}
