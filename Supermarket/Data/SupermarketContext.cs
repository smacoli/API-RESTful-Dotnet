using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Supermarket.Domain.Models;

namespace Supermarket.Data
{
    public class SupermarketContext : DbContext
    {
        public SupermarketContext (DbContextOptions<SupermarketContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("categories-db");
        }

    }
}
