
using Business.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ICustomerService
    {
        bool CustomerPost(int Id);
        bool DeletePost(int Id);
        IQueryable<Customer> GetAll();
        Customer Create(Customer customer);
        Customer Update(object id, Customer editedCustomer, out bool changed);
        Customer Delete(Customer customer);
        void SaveChanges();
    }
}
