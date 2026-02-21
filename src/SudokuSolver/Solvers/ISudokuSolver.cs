using SudokuSolver.Domain;

namespace SudokuSolver.Solvers;
public interface ISudokuSolver
{
    bool Solve(Grid grid);
}
