using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiTest.Models {
    public class _dbContext: DbContext {
        public _dbContext(DbContextOptions<_dbContext> options) : base( options ) {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
                    }
    }
}
