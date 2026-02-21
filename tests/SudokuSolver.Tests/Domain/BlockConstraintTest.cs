using SudokuSolver.Domain;
using SudokuSolver.Domain.Constraints;
using Xunit;
using System.Collections.Generic;

public class BlockConstraintTests
{
    [Fact]
    public void IsSatisfied_ReturnsFalse_WhenValueAlreadyInBlock()
    {
        // Arrange
        var cells = new List<Cell>();
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                cells.Add(new Cell(new Position(row, col)));
            }
        }

        var existingCell = cells.First(c => c.Position.Row == 1 && c.Position.Column == 1);
        existingCell.Value = 5;

        var grid = new Grid(cells);
        var constraint = new BlockConstraint();

        var targetCell = cells.First(c => c.Position.Row == 2 && c.Position.Column == 2);

        bool result = constraint.IsSatisfied(grid, targetCell, 5);

        Assert.False(result);
    }

    [Fact]
    public void IsSatisfied_ReturnsTrue_WhenValueNotInBlock()
    {
        var cells = new List<Cell>();
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                cells.Add(new Cell(new Position(row, col)));
            }
        }

        var grid = new Grid(cells);
        var constraint = new BlockConstraint();

        var targetCell = cells.First(c => c.Position.Row == 0 && c.Position.Column == 0);

        bool result = constraint.IsSatisfied(grid, targetCell, 7);

        Assert.True(result);
    }
}
