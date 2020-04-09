using Datastructures.PriorityQueue;
using MazeGenerator.Models;
using MazePathFinder.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazePathFinder
{
    public class PathFinding
    {
        public Maze<PathFindingCell> Maze { get; set; }
        public Stack<PathFindingCell> Path { get; set; }
        private PathFindingCell StartCell { get; set; }
        private PathFindingCell FinishCell { get; set; }


        public void AStartPathFinding()
        {
            StartCell = Maze.StartCell;
            FinishCell = Maze.FinishCell;

            PriorityQueue<PathFindingCell> cells = new PriorityQueue<PathFindingCell>();
            HashSet<PathFindingCell> closedCells = new HashSet<PathFindingCell>();

            cells.Enqueue(StartCell);
            closedCells.Add(StartCell);

            PathFindingCell currentCell;
            while (cells.Count() > 0)
            {
                currentCell = cells.Dequeue();
                if (currentCell.Equals(FinishCell))
                {
                    Path = GetPath(currentCell);
                    //ShowPath(path);
                    break;
                }
                foreach (PathFindingCell pathCell in currentCell.Links)
                {
                    if (!closedCells.Contains(pathCell))
                    {
                        pathCell.InitializeDistances();
                        closedCells.Add(pathCell);
                        pathCell.PreviousCell = currentCell;
                        cells.Enqueue(pathCell);
                    }
                }

            }
        }

        //private void ShowPath(Stack<PathFindingCell> path)
        //{
        //    foreach (PathFindingCell cell in path)
        //    {
        //        int children = cell.transform.childCount;
        //        GameObject floor = cell.transform.GetChild(children - 1).gameObject;
        //        floor.GetComponent<MeshRenderer>().material = PathMaterial;
        //    }
        //}

        private Stack<PathFindingCell> GetPath(PathFindingCell currentCell)
        {
            Stack<PathFindingCell> pathCells = new Stack<PathFindingCell>();
            PathFindingCell nextPathCell = currentCell.PreviousCell;
            pathCells.Push(currentCell);
            while (nextPathCell != null)
            {
                pathCells.Push(nextPathCell);
                nextPathCell = nextPathCell.PreviousCell;
            }
            return pathCells;
        }

    }
}
