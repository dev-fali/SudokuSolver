using System.Collections.Generic;
using SudokuSolver.Domain;
using SudokuSolver.Heuristics.ValueOrdering;
using Xunit;

public class NaturalOrderStrategyTests
{
    private readonly NaturalOrderStrategy _strategy = new();

    [Fact]
    public void OrderValues_ReturnsValuesInAscendingOrder()
    {
        var cell = new Cell(new Position(0, 0));
        var candidates = new List<int> { 5, 2, 9, 1 };

        var ordered = _strategy.OrderValues(cell, candidates);

        Assert.Equal(new List<int> { 1, 2, 5, 9 }, ordered);
    }

    [Fact]
    public void OrderValues_DoesNotModifyOriginalCollection()
    {
        var cell = new Cell(new Position(0, 0));
        var candidates = new List<int> { 3, 1, 2 };

        var ordered = _strategy.OrderValues(cell, candidates);

        Assert.Equal(new List<int> { 3, 1, 2 }, candidates);
    }

    [Fact]
    public void OrderValues_ReturnsEmpty_WhenCandidatesEmpty()
    {
        var cell = new Cell(new Position(0, 0));
        var candidates = new List<int>();

        var ordered = _strategy.OrderValues(cell, candidates);

        Assert.Empty(ordered);
    }
}