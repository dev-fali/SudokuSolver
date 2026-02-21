using SudokuSolver.Domain;
using SudokuSolver.Domain.Constraints;
using Xunit;
using System.Collections.Generic;
using System.Linq;

public class RowConstraintTests
{
 private readonly List<Cell> _cells;
    private readonly Grid _grid;
    private readonly RowConstraint _constraint;

    public RowConstraintTests()
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
        _constraint = new RowConstraint();
    }

    [Fact]
    public void IsSatisfied_ReturnsFalse_WhenValueAlreadyInRow()
    {
        // Arrange
        var existingCell = _cells.First(c => c.Position.Row == 0 && c.Position.Column == 3);
        existingCell.Value = 7;

        var targetCell = _cells.First(c => c.Position.Row == 0 && c.Position.Column == 5);

        // Act
        bool result = _constraint.IsSatisfied(_grid, targetCell, 7);

        // Assert
        Assert.False(result);
    }

     [Fact]
    public void IsSatisfied_ReturnsTrue_WhenValueNotInRow()
    {
        var targetCell = _cells.First(c => c.Position.Row == 0 && c.Position.Column == 0);

        bool result = _constraint.IsSatisfied(_grid, targetCell, 9);

        Assert.True(result);
    }
}
