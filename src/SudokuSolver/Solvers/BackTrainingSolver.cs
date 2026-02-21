using SudokuSolver.Domain;
using SudokuSolver.Domain.Values;
using SudokuSolver.Heuristics.CellSelection;

namespace SudokuSolver.Solvers;

public sealed class BacktrackingSolver : ISudokuSolver
{
    private readonly ICellSelectionStrategy _cellSelectionStrategy;
    private readonly CandidateSet _candidateSet;

    public BacktrackingSolver(
        ICellSelectionStrategy cellSelectionStrategy,
        CandidateSet candidateSet)
    {
        _cellSelectionStrategy = cellSelectionStrategy;
        _candidateSet = candidateSet;
    }

    public bool Solve(Grid grid)
    {
        var cell = _cellSelectionStrategy.SelectCell(grid);

        if (cell == null)
            return true;

        foreach (var value in _candidateSet.GetCandidates(cell))
        {
            cell.Value = value;

            if (Solve(grid))
                return true;

            cell.Value = null;
        }

        return false;
    }
}
