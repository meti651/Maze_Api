using Microsoft.VisualStudio.TestTools.UnitTesting;
using MazeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;
using MazeGenerator.Utility;

namespace MazeGenerator.Models.Tests
{
    [TestClass()]
    public class MazeTests
    {
        [TestMethod()]
        public void MazeHaveItsMatrix()
        {
            Maze<Cell> maze = new Maze<Cell>(3, 3);

            Assert.IsNotNull(maze.Cells);
        }

        [TestMethod()]
        public void IntializeCellsReturnsMatrixFullOfCells()
        {
            Maze<Cell> maze = new Maze<Cell>(3, 3);

            int randRow = Utils.GetRandomNumber(0, 3);
            int randColumn = Utils.GetRandomNumber(0, 3);

            Assert.IsNotNull(maze.Cells[randRow, randColumn]);
        }

        [TestMethod()]
        public void InitializeCellsCellsGotPosition()
        {
            Maze<Cell> maze = new Maze<Cell>(3, 3);

            Cell firstCell = maze.Cells[0, 0];

            Assert.AreEqual(0, firstCell.X_Position);
        }


        [TestMethod()]
        public void GetRandomCellReturnsCell()
        {
            Maze<Cell> maze = new Maze<Cell>(3, 3);

            Cell randomCell = maze.GetRandomCell();

            Assert.IsNotNull(randomCell);
        }

        [TestMethod()]
        public void InitializeSiblingsSiblingsIsNotNull()
        {
            Maze<Cell> maze = new Maze<Cell>(3, 3);

            maze.InitializeSiblings();

            Cell firstCell = maze.Cells[0, 0];

            Assert.IsTrue(firstCell.Siblings.Count > 0);
        }

        [TestMethod()]
        public void InitializeSiblingsAddCorrectCell()
        {
            Maze<Cell> maze = new Maze<Cell>(3, 3);

            maze.InitializeSiblings();

            Cell firstCell = maze.Cells[0, 0];
            Cell siblingCell = maze.Cells[0, 1];

            Assert.IsTrue(firstCell.Siblings.Contains(siblingCell));
        }

        [TestMethod()]
        public void InitializeSiblingsAddCorrectAmountOfCells()
        {
            Maze<Cell> maze = new Maze<Cell>(3, 3);

            Cell firstCell = maze.Cells[0, 0];

            Assert.IsTrue(firstCell.Siblings.Count == 2);
        }
    }
}