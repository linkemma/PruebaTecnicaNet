using Business.Entities;
using Business.Interfaces;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Model
{
    public class CustomerModel : ICustomerModel
    {
        /// <summary>
        /// Contexto
        /// </summary>
        JujuTestContext _context;
        /// <summary>
        /// Entidad
        /// </summary>

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public CustomerModel(JujuTestContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Consulta todas las entidades
        /// </summary>
        public IQueryable<Customer> GetAll()
        {
            return _context.Customer;
        }

        /// <summary>
        /// Consulta una entidad por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer FindById(object id)
        {
            return _context.Customer.Find(id);
        }

        /// <summary>
        /// Crea un entidad (Guarda)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Customer Create(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();

            return customer;
        }



        /// <summary>
        /// Actualiza la entidad (GUARDA)
        /// </summary>
        /// <param name="editedEntity">Entidad editada</param>
        /// <param name="originalEntity">Entidad Original sin cambios</param>
        /// <param name="changed">Indica si se modifico la entidad</param>
        /// <returns></returns>
        public Customer Update(Customer editedEntity, Customer originalEntity, out bool changed)
        {

            _context.Entry(originalEntity).CurrentValues.SetValues(editedEntity);

            changed = _context.Entry(originalEntity).State == EntityState.Modified;

            _context.SaveChanges();

            return originalEntity;
        }
        /// <summary>
        /// Consulta Si Tiene Post Asociados
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool CustomerPost(int Id)
        {
            var PostDelete = _context.Post.FirstOrDefault(x => x.CustomerId == Id);
            return PostDelete != null ? true : false;
        }


        /// <summary>
        /// Elimina Los Post Asociados
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeletePost(int Id)
        {
            var posts = _context.Post.Where(x => x.CustomerId == Id);
            if (posts != null)
            {
                foreach (var post in posts)
                {
                    _context.Remove(post);
                }
            }
            var regs = _context.SaveChanges();
            return (regs > 0);
        }



        /// <summary>
        /// Elimina una entidad (Guarda)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public  Customer Delete(Customer customer)
        {
            _context.Remove(customer);

            _context.SaveChanges();

            return customer;
        }


        /// <summary>
        /// Guardar cambios
        /// </summary>
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
