using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver.Domain;

public sealed class Grid
{
    public IReadOnlyList<Cell> Cells { get; }

    public Grid(IReadOnlyList<Cell> cells)
    {
        if (cells.Count != 81)
            throw new ArgumentException("La grille doit contenir exactement 81 cellules.");

        Cells = cells;
    }

    public bool IsComplete() => Cells.All(c => c.Value.HasValue);

    public bool IsValid()
    {
        for (int row = 0; row < 9; row++)
        {
            var values = Cells.Where(c => c.Position.Row == row && c.Value.HasValue)
                              .Select(c => c.Value.Value)
                              .ToList();
            if (values.Count != values.Distinct().Count())
                return false;
        }

        for (int col = 0; col < 9; col++)
        {
            var values = Cells.Where(c => c.Position.Column == col && c.Value.HasValue)
                              .Select(c => c.Value.Value)
                              .ToList();
            if (values.Count != values.Distinct().Count())
                return false;
        }

        for (int blockRow = 0; blockRow < 3; blockRow++)
        {
            for (int blockCol = 0; blockCol < 3; blockCol++)
            {
                var values = Cells.Where(c => c.Position.Row / 3 == blockRow
                                           && c.Position.Column / 3 == blockCol
                                           && c.Value.HasValue)
                                  .Select(c => c.Value.Value)
                                  .ToList();
                if (values.Count != values.Distinct().Count())
                    return false;
            }
        }

        return true;
    }

    public Cell GetCellAt(int row, int column) => Cells.First(c => c.Position.Row == row && c.Position.Column == column);

    public IEnumerable<Cell> EmptyCells() => Cells.Where(c => !c.Value.HasValue);
}
