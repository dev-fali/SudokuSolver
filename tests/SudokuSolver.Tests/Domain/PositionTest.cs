using SudokuSolver.Domain;
using Xunit;

public class PositionTests
{
    [Fact]
    public void Valid_Position_Should_Be_Created()
    {
        var position = new Position(3, 4);

        Assert.Equal(3, position.Row);
        Assert.Equal(4, position.Column);
    }

    [Theory]
    [InlineData(-1, 0)]
    [InlineData(9, 0)]
    [InlineData(0, -1)]
    [InlineData(0, 9)]
    public void Invalid_Position_Should_Throw(int row, int column)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new Position(row, column));
    }

    [Fact]
    public void Two_Positions_With_Same_Row_And_Column_Should_Be_Equal()
    {
        var p1 = new Position(2, 5);
        var p2 = new Position(2, 5);

        Assert.Equal(p1, p2);
    }

    [Fact]
    public void ToString_Should_Return_Correct_Format()
    {
        var position = new Position(1, 2);

        Assert.Equal("(1, 2)", position.ToString());
    }
}
