using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Domain;
using SudokuSolver.Domain.Constraints;
using SudokuSolver.Domain.Values;
using SudokuSolver.Heuristics.CellSelection;
using Xunit;

public class MrvCellSelectionStrategyTests
{
    private readonly Grid _grid;
    private readonly List<Cell> _cells;

    public MrvCellSelectionStrategyTests()
    {
        _cells = new List<Cell>();

        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                _cells.Add(new Cell(new Position(row, col)));
            }
        }

        _grid = new Grid(_cells);
    }

    [Fact]
    public void SelectCell_ReturnsCellWithOnlyOneCandidate()
    {
        for (int col = 0; col < 8; col++)
        {
            var cell = _cells.First(c => c.Position.Row == 0 && c.Position.Column == col);
            cell.Value = col + 1;
        }

        var constraints = new IConstraint[]
        {
            new RowConstraint(),
            new ColumnConstraint()
        };

        var candidateSet = new CandidateSet(_grid, constraints);
        var strategy = new MrvCellSelectionStrategy(candidateSet);

        var selected = strategy.SelectCell(_grid);

        Assert.NotNull(selected);
        Assert.Equal(0, selected.Position.Row);
        Assert.Equal(8, selected.Position.Column);
    }

    [Fact]
    public void SelectCell_ReturnsNull_WhenGridIsFull()
    {
        // Arrange
        foreach (var cell in _cells)
            cell.Value = 1;

        var constraints = new IConstraint[]
        {
            new RowConstraint(),
            new ColumnConstraint()
        };

        var candidateSet = new CandidateSet(_grid, constraints);
        var strategy = new MrvCellSelectionStrategy(candidateSet);

        // Act
        var selected = strategy.SelectCell(_grid);

        // Assert
        Assert.Null(selected);
    }
}