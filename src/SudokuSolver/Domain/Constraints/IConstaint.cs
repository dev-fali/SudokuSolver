using SudokuSolver.Domain;

namespace SudokuSolver.Domain.Constraints;

public interface IConstraint
{
    bool IsSatisfied(Grid grid, Cell cell, int value);
}
