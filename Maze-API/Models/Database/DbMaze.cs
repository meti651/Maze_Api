using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maze_API.Models
{
    public class DbMaze
    {
        public int Id { get; set; }
        public List<DbCell> Cells { get; set; }
        public DbCell StartCell { get; set; }
        public DbCell FinishCell { get; set; }
    }
}
