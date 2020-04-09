using MazeGenerator.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MazeGenerator.Models
{
    public class Maze<T> where T : Cell, new()
    {
        public T[,] Cells { get; set; }
        public T StartCell { get; set; }
        public T FinishCell { get; set; }

        public Maze(int row, int column)
        {
            Cells = new T[row, column];
            InitializeCells();
            InitializeSiblings();
        }

        public void InitializeSiblings()
        {
            for (int x = 0; x < Cells.GetLength(0); x++)
            {
                for (int y = 0; y < Cells.GetLength(1); y++)
                {
                    T currentCell = Cells[x, y];
                    if (x == 0 && y > 0)
                    {
                        T westCell = Cells[x, y - 1];
                        currentCell.AddSibling(westCell);
                    }
                    else if (x > 0 && y > 0)
                    {
                        T westCell = Cells[x, y - 1];
                        T northCell = Cells[x - 1, y];
                        currentCell.AddSibling(westCell);
                        currentCell.AddSibling(northCell);
                    }else if(x > 0 && y == 0)
                    {
                        T nortCell = Cells[x - 1, y];
                        currentCell.AddSibling(nortCell);
                    }
                }
            }
        }

        public void InitializeCells()
        {
            int row = Cells.GetLength(0);
            int column = Cells.GetLength(1);
            for (int x = 0; x < row; x++)
            {
                for(int y = 0; y < column; y++)
                {
                    T newCell = new T();
                    newCell.X_Position = x;
                    newCell.Y_Position = y;
                    Cells[x, y] = newCell;
                }
            }

            StartCell = Cells[0, 0];
            FinishCell = Cells[row - 1, column - 1];
        }

        public T GetRandomCell()
        {
            int x_pos = Utils.GetRandomNumber(0, Cells.GetLength(0));
            int y_pos = Utils.GetRandomNumber(0, Cells.GetLength(1));

            return Cells[x_pos, y_pos];
        }

    }
}
