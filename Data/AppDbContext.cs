﻿using Microsoft.EntityFrameworkCore;
using Products.Data.Models;


namespace Products.Data
{
    public class AppDbContext : DbContext
    {
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           
        }
        public DbSet<Product> Products { get; set; }
    }

}