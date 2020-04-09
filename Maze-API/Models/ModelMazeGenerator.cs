using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MazeGenerator;
using MazeGenerator.Models;
using MazePathFinder.Models;

namespace Maze_API.Models
{
    public class ModelMazeGenerator
    {
        public Maze<Cell> NormalMaze { get; set; }
        public Maze<PathFindingCell> PathFindingMaze { get; set; }
        

        public void GenerateNormalMaze(int row, int column)
        {
            MazeGenerator<Cell> generator = new MazeGenerator<Cell>(row, column);

            generator.DeapthFirstMethod();

            NormalMaze = generator.Maze;
        }

        public void GeneratePathFindingMaze(int row, int column)
        {
            MazeGenerator<PathFindingCell> generator = new MazeGenerator<PathFindingCell>(row, column);

            generator.DeapthFirstMethod();

            PathFindingMaze = generator.Maze;
        }
    }
}
