using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bokhandel.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Bokhandel.Data
{
    public class BokhandelContext : IdentityDbContext<DefaultUser>
    {
        public BokhandelContext (DbContextOptions<BokhandelContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        
    }
}
