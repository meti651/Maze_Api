using MazeGenerator.Models;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazeGenerator.Models.Tests
{
    [TestClass()]
    public class CellTests
    {
        [TestMethod()]
        public void CellIsNotNull()
        {
            Cell newCell = new Cell(0, 0);
            Assert.IsNotNull(newCell);
        }

        [TestMethod()]
        public void MakeLinkWallsDesapear()
        {
            Cell firstCell = new Cell(0, 0);
            Cell secondCell = new Cell(0, 1);

            firstCell.MakeLink(secondCell);
            Assert.IsFalse(firstCell.EastWall);
        }

        [TestMethod()]
        public void MakeLinkCellAdded()
        {
            Cell firstCell = new Cell(0, 0);
            Cell linkCell = new Cell(0, 1);

            firstCell.MakeLink(linkCell);

            Assert.IsTrue(firstCell.Links.Count > 0);
        }

        [TestMethod()]
        public void AddSiblingAddCell()
        {
            Cell firstCell = new Cell(0, 0);
            Cell secondCell = new Cell(0, 1);

            firstCell.AddSibling(secondCell);

            Assert.IsTrue(firstCell.Siblings.Contains(secondCell));
        }

        [TestMethod()]
        public void GetRandomUnvisitedSiblingReturnsNull()
        {
            HashSet<Cell> visitedCells = new HashSet<Cell>();

            Cell newCell = new Cell(0, 0);
            Cell visitedSibling = new Cell(0, 1);

            newCell.AddSibling(visitedSibling);
            visitedCells.Add(visitedSibling);

            Cell unvisitedCell = newCell.GetRandomUnvisitedSibling<Cell>(visitedCells);

            Assert.IsNull(unvisitedCell);
        }

        [TestMethod()]
        public void GetRandomUnvisitedSiblingReturnsCell()
        {
            HashSet<Cell> visitedCells = new HashSet<Cell>();

            Cell newCell = new Cell(0, 0);
            Cell unvisitedSibling = new Cell(0, 1);

            newCell.AddSibling(unvisitedSibling);

            Cell unvisitedCell = newCell.GetRandomUnvisitedSibling<Cell>(visitedCells);

            Assert.AreEqual(unvisitedSibling, unvisitedCell);
        }
    }
}