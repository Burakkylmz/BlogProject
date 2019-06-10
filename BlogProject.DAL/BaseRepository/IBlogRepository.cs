using BlogProject.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogProject.DAL.BaseRepository
{
    public interface IBlogRepository
    {
        Blog GetById(int id);
        IQueryable<Blog> GetAll();
        void AddBlog(Blog entity);
        void UpdateBlog(Blog entity);
        void SaveBlog(Blog entity);
        void DeleteBlog(int id);
    }
}
