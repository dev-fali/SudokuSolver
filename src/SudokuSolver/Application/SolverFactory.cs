using System;
using SudokuSolver.Domain.Constraints;
using SudokuSolver.Solvers;
using SudokuSolver.Domain.Values;
using SudokuSolver.Heuristics.CellSelection;
using SudokuSolver.Domain;

namespace SudokuSolver.Application;

public static class SolverFactory
{
    public static ISudokuSolver CreateNaiveSolver(Grid grid)
    {
        if (grid == null) 
            throw new ArgumentNullException(nameof(grid));

        var constraints = new IConstraint[]
        {
            new RowConstraint(),
            new ColumnConstraint(),
            new BlockConstraint()
        };

        var candidateSet = new CandidateSet(grid, constraints);
        var strategy = new FirstEmptyCellStrategy();

        return new BacktrackingSolver(strategy, candidateSet);
    }

    public static ISudokuSolver CreateMrvSolver(Grid grid)
    {
        if (grid == null) 
            throw new ArgumentNullException(nameof(grid));

        return new MrvBacktrackingSolver(grid);
    }
}
