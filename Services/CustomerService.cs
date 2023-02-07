using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StoredProcedureImplementing.Data;
using StoredProcedureImplementing.Models;

namespace StoredProcedureImplementing.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }
        public async Task<int> CreateCustomer(Customer newCustomer)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Name", newCustomer.Name),
                new SqlParameter("@Company", newCustomer.Company),
                new SqlParameter("@Job", newCustomer.Job) //paramater names Job etc
            };
            //stored procedure name AddNewCustomer
            return await Task.Run(() => _context.Database
            .ExecuteSqlRawAsync(@"exec AddNewCustomer @Name,@Company,@Job", param.ToArray()));
        }

        public async Task<int> DeleteCustomer(int id)
        {
            //Name of the stored procedure is DeleteCustomerById
            return await Task.Run(() => _context.Database.ExecuteSqlInterpolatedAsync($"DeleteCustomerById {id}"));
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _context.Customers.FromSqlRaw<Customer>("GetAllProducts").ToListAsync();
            //GetAllProducts is name of stored procedure
        }

        public async Task<IEnumerable<Customer>> GetCustomerById(int id)
        {
            //GetCustomerById name of stored procedure and Id is the parameter name
            var param = new SqlParameter("@Id", id);
            return await Task.Run(() => _context.Customers.FromSqlRaw(@"exec GetCustomerById @Id", param)
            .ToListAsync());
        }

        public async Task<int> UpdateCustomer(Customer updatedCustomer)
        {
            var param = new List<SqlParameter>
            {
                new SqlParameter("@Id",updatedCustomer.Id),
                new SqlParameter("@Name",updatedCustomer.Name),
                new SqlParameter("@Company",updatedCustomer.Company),
                new SqlParameter("@Job",updatedCustomer.Job),
            };
            //UpdateProduct is the name of stored procedure
            return await Task.Run(() => _context.Database
            .ExecuteSqlRaw(@"exec UpdateProduct @Id,@Name,@Company,@Job", param.ToArray()));
        }
    }
}
