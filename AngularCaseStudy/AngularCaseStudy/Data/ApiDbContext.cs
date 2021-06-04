using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AngularCaseStudy.Models;

namespace AngularCaseStudy.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext (DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<AngularCaseStudy.Models.Employee> Employee { get; set; }

        public DbSet<AngularCaseStudy.Models.Categories> Categories { get; set; }

        public DbSet<AngularCaseStudy.Models.Query> Query { get; set; }

        public DbSet<AngularCaseStudy.Models.Solution> Solution { get; set; }
    }
}
