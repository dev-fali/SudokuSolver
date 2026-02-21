using SudokuSolver.Domain;
using Xunit;

public class GridTests
{
    //Helper
    private static Grid CreateEmptyGrid()
    {
        var cells = new List<Cell>();

        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                cells.Add(new Cell(new Position(row, col), null));
            }
        }

        return new Grid(cells);
    }

    [Fact]
    public void Constructor_Should_Throw_When_Not_81_Cells()
    {
        var cells = new List<Cell>();

        Assert.Throws<ArgumentException>(() => new Grid(cells));
    }

    [Fact]
    public void Empty_Grid_Should_Not_Be_Complete()
    {
        var grid = CreateEmptyGrid();

        Assert.False(grid.IsComplete());
    }

    [Fact]
    public void Full_Grid_Should_Be_Complete()
    {
        var cells = new List<Cell>();

        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 9; col++)
            {
                cells.Add(new Cell(new Position(row, col), 1));
            }
        }

        var grid = new Grid(cells);

        Assert.True(grid.IsComplete());
    }

    [Fact]
    public void Duplicate_In_Row_Should_Make_Grid_Invalid()
    {
        var grid = CreateEmptyGrid();

        grid.GetCellAt(0, 0).Value = 5;
        grid.GetCellAt(0, 1).Value = 5;

        Assert.False(grid.IsValid());
    }

    [Fact]
    public void Duplicate_In_Column_Should_Make_Grid_Invalid()
    {
        var grid = CreateEmptyGrid();

        grid.GetCellAt(0, 0).Value = 5;
        grid.GetCellAt(1, 0).Value = 5;

        Assert.False(grid.IsValid());
    }

    [Fact]
    public void Duplicate_In_Block_Should_Make_Grid_Invalid()
    {
        var grid = CreateEmptyGrid();

        grid.GetCellAt(0, 0).Value = 5;
        grid.GetCellAt(1, 1).Value = 5 ;

        Assert.False(grid.IsValid());
    }

    [Fact]
    public void Valid_Grid_Should_Return_True()
    {
        var grid = CreateEmptyGrid();

        grid.GetCellAt(0, 0).Value = 5;
        grid.GetCellAt(0, 1).Value = 6;
        grid.GetCellAt(1, 0).Value = 7;

        Assert.True(grid.IsValid());
    }

    [Fact]
    public void GetCellAt_Should_Return_Correct_Cell()
    {
        var grid = CreateEmptyGrid();

        var cell = grid.GetCellAt(3, 4);

        Assert.Equal(3, cell.Position.Row);
        Assert.Equal(4, cell.Position.Column);
    }

    [Fact]
    public void EmptyCells_Should_Return_All_Empty_Cells()
    {
        var grid = CreateEmptyGrid();

        grid.GetCellAt(0, 0).Value = 5;

        var emptyCount = grid.EmptyCells().Count();

        Assert.Equal(80, emptyCount);
    }
}
