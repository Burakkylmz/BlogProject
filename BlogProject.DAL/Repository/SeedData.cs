using BlogProject.DAL.Context;
using BlogProject.Model.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogProject.DAL.Repository
{
    public class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            ProjectContext context = app.ApplicationServices.GetRequiredService<ProjectContext>();

            context.Database.Migrate();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category() { Name= "Category1"},
                    new Category() { Name = "Category2" },
                    new Category() { Name = "Category3" }
                    );

                context.SaveChanges();
            }

            if (!context.Blogs.Any())
            {
                context.Blogs.AddRange(
                    new Blog() { Title="Blog Title 1", Description="Blog Description", Body="Blog Body 1", ImageUrl="1.jpeg", AddDate=DateTime.Now.AddDays(-5), isActive=true, CategoryId=1},
                    new Blog() { Title = "Blog Title 2", Description = "Blog Description", Body = "Blog Body 2", ImageUrl = "2.jpeg", AddDate = DateTime.Now.AddDays(-5), isActive = true, CategoryId = 2},
                    new Blog() { Title = "Blog Title 3", Description = "Blog Description", Body = "Blog Body 3", ImageUrl = "3.jpeg", AddDate = DateTime.Now.AddDays(-5), isActive = true, CategoryId = 3 },
                    new Blog() { Title = "Blog Title 4", Description = "Blog Description", Body = "Blog Body 4", ImageUrl = "4.jpeg", AddDate = DateTime.Now.AddDays(-5), isActive = true, CategoryId = 4 }
                    );

                context.SaveChanges();
            }
        }
    }
}
