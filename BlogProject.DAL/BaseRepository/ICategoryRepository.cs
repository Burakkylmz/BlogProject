using BlogProject.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogProject.DAL.BaseRepository
{
    public interface ICategoryRepository
    {
        Category GetById(int id);
        IQueryable<Category> GetAll();
        void AddCategory(Category entity);
        void UpadateCategory(Category entity);
        void DeleteCategory(int id);
        void SaveCategory(Category entity);
    }
}
