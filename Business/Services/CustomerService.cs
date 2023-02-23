using Business.Entities;
using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Services
{
    public class CustomerService : ICustomerService
    {
        protected ICustomerModel _CustomerModel;

        public CustomerService(ICustomerModel CustomerModel)
        {
            _CustomerModel = CustomerModel;
        }

        #region Repository


        /// <summary>
        /// Consulta todas las entidades
        /// </summary>
        public IQueryable<Customer> GetAll()
        {
            return _CustomerModel.GetAll();
        }
        /// <summary>
        /// Consulta si el cliente tiene Post
        /// </summary>
        public bool CustomerPost(int Id)
        {
            return _CustomerModel.CustomerPost(Id);
        }
        /// <summary>
        /// Elimina los Post Asociados
        /// </summary>
        public bool DeletePost(int Id)
        {
            return _CustomerModel.DeletePost(Id);
        }

        /// <summary>
        /// Crea un entidad (Guarda)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Customer Create(Customer entity)
        {
            return _CustomerModel.Create(entity);
        }


        /// <summary>
        /// Actualiza la entidad (GUARDA)
        /// </summary>
        /// <param name="editedEntity">Entidad editada</param>
        /// <param name="originalEntity">Entidad Original sin cambios</param>
        /// <param name="changed">Indica si se modifico la entidad</param>
        /// <returns></returns>
        public Customer Update(object id, Customer editedEntity, out bool changed)
        {
            Customer originalEntity = _CustomerModel.FindById(id);
            return _CustomerModel.Update(editedEntity, originalEntity, out changed);
        }


        /// <summary>
        /// Elimina una entidad (Guarda)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Customer Delete(Customer customer)
        {
            return _CustomerModel.Delete(customer);
        }

        /// <summary>
        /// Guardar cambios
        /// </summary>
        public void SaveChanges()
        {
            _CustomerModel.SaveChanges();
        }
        #endregion


    }
}
