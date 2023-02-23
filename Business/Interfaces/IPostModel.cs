
using Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Interfaces
{
    public interface IPostModel
    {
        IQueryable<Post> GetAll();
        Post FindById(object id);
        Post Create(Post post);
        bool CreateMassive(IEnumerable<Post> post);
        Post Update(Post editedPost, Post originalPost, out bool changed);
        Post Delete(Post post);
        void SaveChanges();
    }
}
