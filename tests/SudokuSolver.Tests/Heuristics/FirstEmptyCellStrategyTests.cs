using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Domain;
using SudokuSolver.Heuristics.CellSelection;
using Xunit;

public class FirstEmptyCellStrategyTests
{
    private readonly Grid _grid;
    private readonly List<Cell> _cells;
    private readonly FirstEmptyCellStrategy _strategy;

    public FirstEmptyCellStrategyTests()
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
        _strategy = new FirstEmptyCellStrategy();
    }

    [Fact]
    public void SelectCell_ReturnsFirstEmptyCell()
    {
        // Arrange
        var firstEmpty = _cells[0];
        firstEmpty.Value = null;
        _cells[1].Value = 5; // Remplie pour tester qu'on skip
        _cells[2].Value = null;

        // Act
        var selected = _strategy.SelectCell(_grid);

        // Assert
        Assert.NotNull(selected);
        Assert.Equal(firstEmpty, selected);
    }

    [Fact]
    public void SelectCell_ReturnsNull_WhenAllCellsFilled()
    {
        // Arrange
        foreach (var cell in _cells)
            cell.Value = 1; // toutes les cellules remplies

        // Act
        var selected = _strategy.SelectCell(_grid);

        // Assert
        Assert.Null(selected);
    }
}