using MazeGenerator.Utility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MazeGenerator.Models
{
    public class Cell
    {
        public int X_Position { get; set; }
        public int Y_Position { get; set; }
        [JsonIgnore]
        public HashSet<Cell> Siblings { get; set; } = new HashSet<Cell>();
        public bool NortWall { get; set; } = true;
        public bool EastWall { get; set; } = true;
        public bool SouthWall { get; set; } = true;
        public bool WestWall { get; set; } = true;
        public bool IsFinish { get; set; }
        public bool IsPlayerIn { get; set; }
        [JsonIgnore]
        public HashSet<Cell> Links { get; set; } = new HashSet<Cell>();

        public Cell(int x_Position, int y_Postion)
        {
            X_Position = x_Position;
            Y_Position = y_Postion;
            
        }

        public Cell()
        {
            
        }

        public T GetRandomUnvisitedSibling<T>(HashSet<T> visitedCells) where T : Cell
        {
            List<T> unvisitedCells = new List<T>();
            foreach (T sibling in Siblings)
            {
                if (!visitedCells.Contains(sibling))
                {
                    unvisitedCells.Add(sibling);
                }
            }
            if (unvisitedCells.Count < 1)
            {
                return null;
            }
            int num = Utils.GetRandomNumber(0, unvisitedCells.Count);

            return unvisitedCells.ElementAt(num);
        }


        public void MakeLink(Cell cell)
        {
            if (this.X_Position == cell.X_Position && this.Y_Position < cell.Y_Position)
            {
                EastWall = false;
                cell.WestWall = false;
                Links.Add(cell);
                cell.Links.Add(this);
            }
            else if (this.X_Position == cell.X_Position && this.Y_Position > cell.Y_Position)
            {
                WestWall = false;
                cell.EastWall = false;
                Links.Add(cell);
                cell.Links.Add(this);
            }
            else if (this.X_Position < cell.X_Position && this.Y_Position == cell.Y_Position)
            {
                SouthWall = false;
                cell.NortWall = false;
                Links.Add(cell);
                cell.Links.Add(this);
            }
            else if (this.X_Position > cell.X_Position && this.Y_Position == cell.Y_Position)
            {
                NortWall = false;
                cell.SouthWall = false;
                Links.Add(cell);
                cell.Links.Add(this);
            }
        }

        public void AddSibling(Cell cell)
        {
            if (cell != null)
            {
                Siblings.Add(cell);
                cell.Siblings.Add(this);
            }
        }

    }
}
