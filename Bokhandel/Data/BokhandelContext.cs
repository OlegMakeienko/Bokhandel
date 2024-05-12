using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bokhandel.Models;

namespace Bokhandel.Data
{
    public class BokhandelContext : DbContext
    {
        public BokhandelContext (DbContextOptions<BokhandelContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}
