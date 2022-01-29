using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Context
{
    public class LibroContext : DbContext
    {
        public LibroContext(DbContextOptions<LibroContext> options) : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }
    }
}
