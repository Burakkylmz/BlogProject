using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Model.Entity
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? AddDate { get; set; }
        public bool isActive { get; set; }
        public string ImageUrl { get; set; }
        public bool isHome { get; set; }
        public bool isSlider { get; set; }
        public string Body { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
