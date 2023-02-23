
using Business.Entities;
using System.Linq;

namespace Business.Interfaces
{
    public interface ICustomerModel
    {
        bool CustomerPost(int Id);
        bool DeletePost(int Id);
        IQueryable<Customer> GetAll();
        Customer FindById(object id);
        Customer Create(Customer entity);
        Customer Update(Customer editedEntity, Customer originalEntity, out bool changed);
        Customer Delete(Customer entity);
        void SaveChanges();
    }
}
