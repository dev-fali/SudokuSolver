using SudokuSolver.Domain;
using SudokuSolver.Domain.Values;

namespace SudokuSolver.Heuristics.CellSelection;

public sealed class MrvCellSelectionStrategy : ICellSelectionStrategy
{
    private readonly CandidateSet _candidateSet;

    public MrvCellSelectionStrategy(CandidateSet candidateSet)
    {
        _candidateSet = candidateSet;
    }

    public Cell? SelectCell(Grid grid)
    {
        Cell? bestCell = null;
        int minCandidates = int.MaxValue;

        foreach (var cell in grid.Cells)
        {
            if (cell.Value.HasValue)
                continue;

            var candidates = _candidateSet.GetCandidates(cell);
            int count = candidates.Count;

            if (count == 0)
                return cell;

            if (count < minCandidates)
            {
                minCandidates = count;
                bestCell = cell;

                if (count == 1)
                    break;
            }
        }

        return bestCell;
    }
}
