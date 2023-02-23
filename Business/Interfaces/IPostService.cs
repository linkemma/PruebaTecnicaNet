
using Business.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Interfaces
{
    public interface IPostService
    {
        IQueryable<Post> GetAll();
        Post Create(Post post);
        bool CreateMassive(IEnumerable<Post> post);
        Post Update(object id, Post editedPost, out bool changed);
        Post Delete(Post post);
        void SaveChanges();
    }
}
