using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Domain;
using SudokuSolver.Domain.Constraints;
using Xunit;

public class ColumnConstraintTests
{
    private readonly Grid _grid;
    private readonly List<Cell> _cells;
    private readonly ColumnConstraint _constraint;

    public ColumnConstraintTests()
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
        _constraint = new ColumnConstraint();
    }

    [Fact]
    public void IsSatisfied_ReturnsFalse_WhenValueAlreadyInColumn()
    {
        var existingCell = _cells.First(c => c.Position.Row == 3 && c.Position.Column == 2);
        existingCell.Value = 7;

        var targetCell = _cells.First(c => c.Position.Row == 6 && c.Position.Column == 2);

        bool result = _constraint.IsSatisfied(_grid, targetCell, 7);

        Assert.False(result);
    }

    [Fact]
    public void IsSatisfied_ReturnsTrue_WhenValueNotInColumn()
    {
        var targetCell = _cells.First(c => c.Position.Row == 4 && c.Position.Column == 1);

        bool result = _constraint.IsSatisfied(_grid, targetCell, 9);

        Assert.True(result);
    }

    [Fact]
    public void IsSatisfied_IgnoresOtherColumns()
    {
        var otherColumnCell = _cells.First(c => c.Position.Row == 3 && c.Position.Column == 5);
        otherColumnCell.Value = 8;

        var targetCell = _cells.First(c => c.Position.Row == 6 && c.Position.Column == 2);

        bool result = _constraint.IsSatisfied(_grid, targetCell, 8);

        Assert.True(result);
    }
}