using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Model.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Blog> Blogs { get; set; }
    }
}
