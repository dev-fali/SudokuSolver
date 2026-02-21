using System.Collections.Generic;
using SudokuSolver.Domain;

namespace SudokuSolver.Heuristics.ValueOrdering;

public interface IValueOrderingStrategy
{
    IReadOnlyCollection<int> OrderValues(Cell cell, IReadOnlyCollection<int> candidates);
}
