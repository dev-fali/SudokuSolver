using System;
using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Domain;
using SudokuSolver.Domain.Constraints;
using SudokuSolver.Domain.Values;
using Xunit;

public class CandidateSetTests
{
    private readonly Grid _grid;
    private readonly Cell _emptyCell;

    public CandidateSetTests()
    {
        var cells = new List<Cell>();

        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                cells.Add(new Cell(new Position(row, col)));
            }
        }

        _grid = new Grid(cells);
        _emptyCell = cells.First();
    }

    [Fact]
    public void GetCandidates_ReturnsEmpty_WhenCellHasValue()
    {
        _emptyCell.Value = 5;
        var candidateSet = new CandidateSet(_grid, new List<IConstraint>());

        var result = candidateSet.GetCandidates(_emptyCell);

        Assert.Empty(result);
    }

    [Fact]
    public void GetCandidates_Returns1To9_WhenNoConstraints()
    {
        var candidateSet = new CandidateSet(_grid, new List<IConstraint>());

        var result = candidateSet.GetCandidates(_emptyCell);

        Assert.Equal(9, result.Count);
        Assert.True(Enumerable.Range(1, 9).All(result.Contains));
    }

    [Fact]
    public void GetCandidates_FiltersValues_WhenConstraintBlocksValue()
    {
        var constraint = new BlockValueConstraint(5);
        var candidateSet = new CandidateSet(_grid, new List<IConstraint> { constraint });

        var result = candidateSet.GetCandidates(_emptyCell);

        Assert.DoesNotContain(5, result);
        Assert.Equal(8, result.Count);
    }

    // Fake constraint
    private class BlockValueConstraint : IConstraint
    {
        private readonly int _blockedValue;

        public BlockValueConstraint(int blockedValue)
        {
            _blockedValue = blockedValue;
        }

        public bool IsSatisfied(Grid grid, Cell cell, int value)
        {
            return value != _blockedValue;
        }
    }
}