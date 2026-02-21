using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Domain;

namespace SudokuSolver.Heuristics.ValueOrdering;

public sealed class NaturalOrderStrategy : IValueOrderingStrategy
{
    public IReadOnlyCollection<int> OrderValues(Cell cell, IReadOnlyCollection<int> candidates)
    {
        return candidates.OrderBy(v => v).ToList();
    }
}
