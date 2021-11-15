using Xunit;
using System.Collections.Generic;

namespace GameOfLife.Tests
{
    public class MainTests
    {
        [Fact]
        public void CellWith0NeighboursDies()
        {
            var observedCell = new Cell(0, 0);
            var aliveCells = new List<Cell> { new Cell(0, 0) };
            var grid = new GameGrid(aliveCells);
            grid.Step();
            Assert.True(grid.IsDead(observedCell));
        }

        [Fact]
        public void CellWith1NeighboursDies()
        {
            var observedCell = new Cell(0, 0);
            var aliveCells = new List<Cell> { new Cell(0, 0), new Cell(1, 0) };
            var grid = new GameGrid(aliveCells);
            grid.Step();
            Assert.True(grid.IsDead(observedCell));
        }

        [Fact]
        public void CellWith2NeighborsStaysAlive()
        {
            var observedCell = new Cell(0, 0);
            var aliveCells = new List<Cell> { new Cell(-1, 0), new Cell(0, 0), new Cell(1, 0) };
            var grid = new GameGrid(aliveCells);
            grid.Step();
            Assert.True(grid.IsAlive(observedCell));
        }

        [Fact]
        public void CellWith3NeighborsStaysAlive()
        {
            var observedCell = new Cell(0, 0);
            var aliveCells = new List<Cell> { new Cell(-1, 0), new Cell(0, 0), new Cell(1, 0), new Cell(1, 1) };
            var grid = new GameGrid(aliveCells);
            grid.Step();
            Assert.True(grid.IsAlive(observedCell));
        }

        [Fact]
        public void CellWith4NeighborsDies()
        {
            var observedCell = new Cell(0, 0);
            var aliveCells = new List<Cell> { new Cell(-1, 0), new Cell(0, 0), new Cell(1, 0), new Cell(1, 1), new Cell(1, -1) };
            var grid = new GameGrid(aliveCells);
            grid.Step();
            Assert.True(grid.IsDead(observedCell));
        }

        [Fact]
        public void DeadCellWith3NeighborsComesToLife()
        {
            var observedCell = new Cell(0, 0);
            var aliveCells = new List<Cell> { new Cell(-1, 0), new Cell(1, 0) , new Cell(1, 1) };
            var grid = new GameGrid(aliveCells);
            grid.Step();
            Assert.True(grid.IsAlive(observedCell));
        }
    }
}