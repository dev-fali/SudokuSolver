using SudokuSolver.Domain;

namespace SudokuSolver.Heuristics.CellSelection;

public interface ICellSelectionStrategy
{
    Cell? SelectCell(Grid grid);
}
