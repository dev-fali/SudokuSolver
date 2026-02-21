using SudokuSolver.Domain;
using Xunit;

public class CellTests
{
    [Fact]
    public void New_Cell_Should_Have_Position_And_Null_Value_By_Default()
    {
        var position = new Position(0, 0);
        var cell = new Cell(position);

        Assert.Equal(position, cell.Position);
        Assert.Null(cell.Value);
    }

    [Fact]
    public void Cell_Should_Store_Value()
    {
        var position = new Position(0, 0);
        var cell = new Cell(position, 5);

        Assert.Equal(5, cell.Value);
    }

    [Fact]
    public void Cell_Value_Should_Be_Mutable()
    {
        var cell = new Cell(new Position(0, 0));

        cell.Value = 7;

        Assert.Equal(7, cell.Value);
    }
}
