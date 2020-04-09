using MazeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazeGenerator
{
    public class MazeGenerator<T> where T : Cell, new()
    {
        public Maze<T> Maze { get; set; }


        public MazeGenerator(int row, int column)
        {
            Maze = new Maze<T>(row, column);
        }

        public void DeapthFirstMethod()
        {
            Stack<T> routeCells = new Stack<T>();
            HashSet<T> visitedCells = new HashSet<T>();

            T startingCell = GetGeneratorStartingCell();
            routeCells.Push(startingCell);
            visitedCells.Add(startingCell);
            while (routeCells.Count > 0)
            {
                T currentCell = routeCells.Peek();
                T linkCell = currentCell.GetRandomUnvisitedSibling(visitedCells);

                if (linkCell == null)
                {
                    routeCells.Pop();
                    continue;
                }
                visitedCells.Add(linkCell);
                routeCells.Push(linkCell);
                currentCell.MakeLink(linkCell);
            }
        }

        public T GetGeneratorStartingCell()
        {
            return Maze.GetRandomCell();
        }

    }
}
