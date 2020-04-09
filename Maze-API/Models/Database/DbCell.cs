using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maze_API.Models
{
    public class DbCell
    {
        public int Id { get; set; }
        public int X_Position { get; set; }
        public int Y_Position { get; set; }
        public bool NortWall { get; set; }
        public bool EastWall { get; set; }
        public bool SouthWall { get; set; }
        public bool WestWall { get; set; }
        public bool IsFinish { get; set; }
        public bool IsPlayerIn { get; set; }
        public List<DbMaze> Maze { get; set; }
        public List<DbCell> Siblings { get; set; }
        public List<DbCell> Links { get; set; }
    }
}
