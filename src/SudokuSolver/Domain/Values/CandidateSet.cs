
using System;
using System.Collections.Generic;
using SudokuSolver.Domain;
using SudokuSolver.Domain.Constraints;

namespace SudokuSolver.Domain.Values;
public sealed class CandidateSet
{
    private readonly Grid _grid;
    private readonly IReadOnlyCollection<IConstraint> _constraints;

    public CandidateSet(Grid grid, IReadOnlyCollection<IConstraint> constraints)
    {
        _grid = grid ?? throw new ArgumentNullException(nameof(grid));
        _constraints = constraints ?? throw new ArgumentNullException(nameof(constraints));
    }

    public IReadOnlyCollection<int> GetCandidates(Cell cell)
    {
        if (cell.Value.HasValue)
            return Array.Empty<int>();

        var candidates = new List<int>(9);

        for (int value = 1; value <= 9; value++)
        {
            if (IsAllowed(cell, value))
                candidates.Add(value);
        }

        return candidates;
    }

    private bool IsAllowed(Cell cell, int value)
    {
        foreach (var constraint in _constraints)
        {
            if (!constraint.IsSatisfied(_grid, cell, value))
                return false;
        }

        return true;
    }
}
