using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BasicService.Api.Models;

namespace BasicService.Api.Models
{
    public class BasicServiceDbContext : DbContext
    {
        public BasicServiceDbContext(DbContextOptions<BasicServiceDbContext> options)
            : base(options) { }
        public virtual DbSet<ActionItemModel> ActionItems { get; set; }
    }
}