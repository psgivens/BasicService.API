using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using BasicService.Api.Models;

namespace BasicService.Api.Models
{
    public class BasicServiceDbContext : DbContext
    {
        public BasicServiceDbContext(DbContextOptions<BasicServiceDbContext> options)
            : base(options) { }
        public virtual DbSet<BasicServiceEntryModel> BasicServiceEntries { get; set; }
        public virtual DbSet<PersonEntity> People { get; set; }
        public virtual DbSet<GroupEntity> Groups { get; set; }
        public virtual DbSet<ActionItemModel> ActionItems { get; set; }
    }
}