using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maze_API.Models
{
    public class MazeDBContext : DbContext
    {
        public MazeDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<DbCell> Cells { get; set; }
        public DbSet<DbMaze> Mazes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
