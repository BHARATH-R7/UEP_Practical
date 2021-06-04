using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularCaseStudy.Models
{
    public class Categories
    {
        [Key]
        public int CategoriesID { get; set; }
        public string CatName { get; set; }
    }
}
