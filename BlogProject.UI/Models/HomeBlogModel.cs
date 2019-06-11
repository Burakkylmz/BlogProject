using BlogProject.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.UI.Models
{
    public class HomeBlogModel
    {
        public virtual List<Blog> SliderBlogs { get; set; }
        public virtual List<Blog> HomeBlogs { get; set; }
    }
}
