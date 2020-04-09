using MazeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MazePathFinder.Models
{
    public class PathFindingCell : Cell, IComparable
    {
        public PathFindingCell PreviousCell;
        private float DistanceFromStart;
        private float DistanceFromFinish;
        public float DistanceValue;
        private PathFindingCell m_FinishCell;

        public PathFindingCell(int row_pos, int column_pos) : base(row_pos, column_pos)
        {
            
        }

        public PathFindingCell() : base()
        {

        }

        public void InitializeDistances()
        {
            DistanceFromStart = X_Position + Y_Position;
            DistanceFromFinish = m_FinishCell.X_Position - X_Position + m_FinishCell.Y_Position - Y_Position;
            DistanceValue = DistanceFromStart + DistanceFromFinish;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            PathFindingCell otherCell = obj as PathFindingCell;
            if (otherCell != null)
            {
                return DistanceValue.CompareTo(otherCell.DistanceValue);
            }
            else
            {
                throw new ArgumentException("Object is not a PathFindingCell");
            }

        }
    }
}
