using Business.Entities;
using Business.Interfaces;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Model
{
    public class PostModel : IPostModel
    {
        /// <summary>
        /// Contexto
        /// </summary>
        JujuTestContext _context;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public PostModel(JujuTestContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Consulta todas las entidades
        /// </summary>
        public IQueryable<Post> GetAll()
        {
            return _context.Post;
        }

        /// <summary>
        /// Consulta una entidad por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Post FindById(object id)
        {
            return _context.Post.Find(id);
        }

        /// <summary>
        /// Crea un entidad (Guarda)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Post Create(Post post)
        {
            _context.Add(post);
            _context.SaveChanges();

            return post;
        }
        /// <summary>
        /// Crea un entidad Masiva
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool CreateMassive(IEnumerable<Post> posts)
        {
            foreach (var post in posts)
            {
                _context.Add(post);
            }
            _context.SaveChanges();

            return true;
        }

        /// <summary>
        /// Actualiza la entidad (GUARDA)
        /// </summary>
        /// <param name="editedEntity">Entidad editada</param>
        /// <param name="originalEntity">Entidad Original sin cambios</param>
        /// <param name="changed">Indica si se modifico la entidad</param>
        /// <returns></returns>
        public Post Update(Post editedEntity, Post originalEntity, out bool changed)
        {

            _context.Entry(originalEntity).CurrentValues.SetValues(editedEntity);

            changed = _context.Entry(originalEntity).State == EntityState.Modified;

            _context.SaveChanges();

            return originalEntity;
        }


        /// <summary>
        /// Elimina una entidad (Guarda)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Post Delete(Post post)
        {
            _context.Remove(post);

            _context.SaveChanges();

            return post;
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
