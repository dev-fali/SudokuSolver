using SudokuSolver.Domain; 
namespace SudokuSolver.Domain.Constraints;

public sealed class ColumnConstraint : IConstraint
{
    public bool IsSatisfied(Grid grid, Cell cell, int value)
    {
        int column = cell.Position.Column;

        for (int row = 0; row < 9; row++)
        {
            var current = grid.GetCellAt(row, column);

            if (current.Value == value)
                return false;
        }

        return true;
    }
}
