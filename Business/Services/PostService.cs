using Business.Entities;
using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Business.Services
{
    public class PostService: IPostService
    {
        protected IPostModel _postModel;

        public PostService(IPostModel postModel)
        {
            _postModel = postModel;
        }

        #region Repository


        /// <summary>
        /// Consulta todas las entidades
        /// </summary>
        public IQueryable<Post> GetAll()
        {
            return _postModel.GetAll();
        }

        /// <summary>
        /// Crea un entidad (Guarda)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Post Create(Post post)
        {
            post.Body = post.Body.Length > 20 ? post.Body.Substring(0, 20) + "..." : post.Body;
            switch (post.Type)
            {
                case 1:
                    post.Category = "Farándula";
                    break;
                case 2:
                    post.Category = "Política";
                    break;
                case 3:
                    post.Category = "Futbol";
                    break;
                default:
                    post.Category = post.Category;
                    break;
            };
            return _postModel.Create(post);
        }
        /// <summary>
        /// Crea un entidad (Guarda)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool CreateMassive(IEnumerable<Post> post)
        {
            return _postModel.CreateMassive(post);
        }


        /// <summary>
        /// Actualiza la entidad (GUARDA)
        /// </summary>
        /// <param name="editedEntity">Entidad editada</param>
        /// <param name="originalEntity">Entidad Original sin cambios</param>
        /// <param name="changed">Indica si se modifico la entidad</param>
        /// <returns></returns>
        public virtual Post Update(object id, Post editedPost, out bool changed)
        {
            Post originalPost = _postModel.FindById(id);
            return _postModel.Update(editedPost, originalPost, out changed);
        }


        /// <summary>
        /// Elimina una entidad (Guarda)
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Post Delete(Post post)
        {
            return _postModel.Delete(post);
        }

        /// <summary>
        /// Guardar cambios
        /// </summary>
        public virtual void SaveChanges()
        {
            _postModel.SaveChanges();
        }
        #endregion


    }
}
