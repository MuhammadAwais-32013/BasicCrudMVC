﻿using BasicCrudMVC.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BasicCrudMVC.Models
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options): base(options) 
        { }

        public DbSet<Product> Products { get; set; }
    }
}
