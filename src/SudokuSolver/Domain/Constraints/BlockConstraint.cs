using SudokuSolver.Domain;

namespace SudokuSolver.Domain.Constraints;
public sealed class BlockConstraint : IConstraint
{
    public bool IsSatisfied(Grid grid, Cell cell, int value)
    {
        int blockRow = cell.Position.Row / 3;
        int blockColumn = cell.Position.Column / 3;

        int startRow = blockRow * 3;
        int startColumn = blockColumn * 3;

        for (int row = startRow; row < startRow + 3; row++)
        {
            for (int col = startColumn; col < startColumn + 3; col++)
            {
                var current = grid.GetCellAt(row, col);

                if (current.Value == value)
                    return false;
            }
        }

        return true;
    }
}
