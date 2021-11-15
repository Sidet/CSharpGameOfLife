using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class GameGrid
    {
        public ISet<Cell> AliveCells;

        public GameGrid(IEnumerable<Cell> aliveCells)
        {
            AliveCells = new HashSet<Cell>(aliveCells);
        }

        public bool IsAlive(Cell observedCell)
        {
            return AliveCells.Contains(observedCell);
        }

        public void Step()
        {
            var newAliveCells = new HashSet<Cell>();
            var deadNeighbours = new HashSet<Cell>();
            foreach (var cell in AliveCells)
            {
                var (alive, dead) = Neighbors(cell);
                deadNeighbours.UnionWith(dead);
                var aliveCount = alive.Count;
                if (2 <= aliveCount && aliveCount <= 3)
                {
                    newAliveCells.Add(cell);
                }
            }
            foreach (var deadCell in deadNeighbours)
            {
                if (AliveNeighborsCount(deadCell) == 3)
                {
                    newAliveCells.Add(deadCell);
                }
            }
            AliveCells = newAliveCells;
        }

        private (ISet<Cell> Alive, ISet<Cell> Dead) Neighbors(Cell cell)
        {
            var aliveNeighbors = new HashSet<Cell>();
            var deadNeighbors = new HashSet<Cell>();
            foreach (var neighbour in cell.Neighbours())
            {
                if (AliveCells.Contains(neighbour))
                {
                    aliveNeighbors.Add(neighbour);
                }
                else
                {
                    deadNeighbors.Add(neighbour);
                }
            }
            return (aliveNeighbors, deadNeighbors);
        }

        private int AliveNeighborsCount(Cell cell)
        {
            var aliveNeighbors = 0;
            foreach (var neighbour in cell.Neighbours())
            {
                if (AliveCells.Contains(neighbour))
                {
                    aliveNeighbors++;
                }
            }
            return aliveNeighbors;
        }

        public bool IsDead(Cell observedCell)
        {
            return !IsAlive(observedCell);
        }
    }
}
