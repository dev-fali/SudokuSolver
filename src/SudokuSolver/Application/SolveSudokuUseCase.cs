using System;
using SudokuSolver.Domain;
using SudokuSolver.Solvers;

namespace SudokuSolver.Application;

public sealed class SolveSudokuUseCase
{
    private readonly ISudokuSolver _solver;

    public SolveSudokuUseCase(ISudokuSolver solver)
    {
        _solver = solver ?? throw new ArgumentNullException(nameof(solver));
    }

    public void Execute(Grid grid)
    {
        if (grid == null)
            throw new ArgumentNullException(nameof(grid));

        if (!_solver.Solve(grid))
            throw new InvalidOperationException("La grille n’a pas de solution.");
    }
}
