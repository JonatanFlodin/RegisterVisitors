using Microsoft.EntityFrameworkCore;
using RegisterVisitors.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegisterVisitors.Data
{
    public class RegisterVisitorsDbContext : DbContext
    {
        public RegisterVisitorsDbContext(DbContextOptions<RegisterVisitorsDbContext> options) : base(options)
        {

        }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
