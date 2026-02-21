using SudokuSolver.Domain;

namespace SudokuSolver.Heuristics.CellSelection;

public sealed class FirstEmptyCellStrategy : ICellSelectionStrategy
{
    public Cell? SelectCell(Grid grid)
    {
        foreach (var cell in grid.Cells)
        {
            if (!cell.Value.HasValue)
                return cell;
        }

        return null;
    }
}
