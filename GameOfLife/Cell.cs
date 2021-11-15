using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public struct Cell
    {
        public int X;
        public int Y;

        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public IEnumerable<Cell> Neighbours()
        {
            yield return new Cell(X - 1, Y - 1);
            yield return new Cell(X, Y - 1);
            yield return new Cell(X + 1, Y - 1);
            yield return new Cell(X + 1, Y);
            yield return new Cell(X + 1, Y + 1);
            yield return new Cell(X, Y + 1);
            yield return new Cell(X - 1, Y + 1);
            yield return new Cell(X - 1, Y);
        }

        public override string ToString()
        {
            return $"<{GetType().Name}({X}, {Y})>";
        }
    }
}
