using SudokuSolver.Domain;

namespace SudokuSolver.Domain.Constraints;

public sealed class RowConstraint : IConstraint
{
    public bool IsSatisfied(Grid grid, Cell cell, int value)
    {
        int row = cell.Position.Row;

        for (int col = 0; col < 9; col++)
        {
            var current = grid.GetCellAt(row, col);
            if (current.Value == value)
                return false;
        }

        return true;
    }
}
