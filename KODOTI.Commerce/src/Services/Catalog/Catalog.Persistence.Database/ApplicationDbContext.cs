using Catalog.Domain;
using Catalog.Persistence.Database.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Catalog.Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInStock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //El ApplicationDbContext va a trabajar con un esquema personalizado
            //Solo va a trabajar con el esquema Catalog en base de datos. Todas la tablas con esquema Catalog
            //No va a poder acceder a la infromación de otros esquemas. Para esto lo debe hacer utilizando un proxy
            modelBuilder.HasDefaultSchema("Catalog");
            ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new ProductConfiguration(modelBuilder.Entity<Product>());
            new ProductInStockConfiguration(modelBuilder.Entity<ProductInStock>());
        }
    }
}
