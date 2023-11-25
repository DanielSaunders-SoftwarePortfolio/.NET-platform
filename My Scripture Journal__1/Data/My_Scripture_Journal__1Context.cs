using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using My_Scripture_Journal.Models;

namespace My_Scripture_Journal__1.Data
{
    public class My_Scripture_Journal__1Context : DbContext
    {
        public My_Scripture_Journal__1Context (DbContextOptions<My_Scripture_Journal__1Context> options)
            : base(options)
        {
        }

        public DbSet<My_Scripture_Journal.Models.Scripture> Scripture { get; set; } = default!;
    }
}
