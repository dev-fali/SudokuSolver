using SudokuSolver.Domain;
using SudokuSolver.Heuristics.CellSelection;
using SudokuSolver.Domain.Values;
using SudokuSolver.Domain.Constraints;

namespace SudokuSolver.Solvers;

public sealed class MrvBacktrackingSolver : ISudokuSolver
{
    private readonly BacktrackingSolver _solver;

    public MrvBacktrackingSolver(Grid grid)
    {
        var constraints = new IConstraint[]
        {
            new RowConstraint(),
            new ColumnConstraint(),
            new BlockConstraint()
        };

        var candidateSet = new CandidateSet(grid, constraints);
        var selectionStrategy = new MrvCellSelectionStrategy(candidateSet);

        _solver = new BacktrackingSolver(selectionStrategy, candidateSet);
    }

    public bool Solve(Grid grid)
    {
        return _solver.Solve(grid);
    }
}
