using StoredProcedureImplementing.Models;

namespace StoredProcedureImplementing.Services
{
    public interface ICustomerService
    {
        Task<int> CreateCustomer(Customer newCustomer);   
        Task<List<Customer>> GetAllCustomers();
        Task<IEnumerable<Customer>> GetCustomerById(int id);
        Task<int> DeleteCustomer(int id);
        Task<int> UpdateCustomer(Customer updatedCustomer);
    }
}
