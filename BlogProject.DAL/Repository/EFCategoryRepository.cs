using BlogProject.DAL.BaseRepository;
using BlogProject.DAL.Context;
using BlogProject.Model.Entity;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogProject.DAL.Repository
{
    public class EFCategoryRepository:ICategoryRepository
    {
        private ProjectContext context;

        public EFCategoryRepository(ProjectContext _context)
        {
            context = _context;
        }

        public void AddCategory(Category entity)
        {
            context.Categories.Add(entity);
            context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = context.Categories.FirstOrDefault(x => x.Id == id);

            if (category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }

        public IQueryable<Category> GetAll()
        {
            return context.Categories;
        }

        public Category GetById(int id)
        {
            return context.Categories.FirstOrDefault(x => x.Id == id);
        }

        public void SaveCategory(Category entity)
        {
            if (entity.Id == 0)
            {
                context.Categories.Add(entity);
            }
            else
            {
                var category = GetById(entity.Id);
                if (category != null)
                {
                    category.Name = entity.Name;
                }
            }

            context.SaveChanges();
        }

        public void UpdateCategory(Category entity)
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
