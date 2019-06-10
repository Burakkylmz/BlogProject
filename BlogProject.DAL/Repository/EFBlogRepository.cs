using BlogProject.DAL.BaseRepository;
using BlogProject.DAL.Context;
using BlogProject.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogProject.DAL.Repository
{
    public class EFBlogRepository:IBlogRepository
    {
        private ProjectContext context;

        public EFBlogRepository(ProjectContext _context)
        {
            context = _context;
        }

        public void AddBlog(Blog entity)
        {
            context.Blogs.Add(entity);
            context.SaveChanges();
        }

        public void DeleteBlog(int id)
        {
            var blog = context.Blogs.FirstOrDefault(x => x.Id == id);

            if (blog != null)
            {
                context.Blogs.Remove(blog);
                context.SaveChanges();
            }
        }

        public IQueryable<Blog> GetAll()
        {
            return context.Blogs;
        }

        public Blog GetById(int id)
        {
            return context.Blogs.FirstOrDefault(x => x.Id == id);
        }

        public void SaveBlog(Blog entity)
        {
            if (entity.Id == 0)
            {
                entity.AddDate = DateTime.Now;
                context.Blogs.Add(entity);
            }
            else
            {
                var blog = GetById(entity.Id);

                if (blog != null)
                {
                    blog.Title = entity.Title;
                    blog.Description = entity.Description;
                    blog.CategoryId = entity.CategoryId;
                    blog.ImageUrl = entity.ImageUrl;
                    blog.isHome = entity.isHome;
                    blog.isActive = entity.isActive;
                    blog.isSlider = entity.isSlider;
                    blog.Body = entity.Body;

                }
            }

            context.SaveChanges();
        }

        public void UpdateBlog(Blog entity)
        {
            var blog = GetById(entity.Id);

            if (blog != null)
            {
                blog.Title = entity.Title;
                blog.Description = entity.Description;
                blog.CategoryId = entity.CategoryId;
                blog.ImageUrl = entity.ImageUrl;

                context.SaveChanges();
            }

            context.SaveChanges();
        }
    }
}
