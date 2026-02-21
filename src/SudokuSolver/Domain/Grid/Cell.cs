using SudokuSolver.Domain;
namespace SudokuSolver.Domain;

public sealed class Cell
{
    public Position Position { get; }
    private int? _value;
    //In sudoku value can be less than 1 and greater than 9.
public int? Value
{
    get => _value;
    set
    {
        if (value is < 1 or > 9)
            throw new ArgumentOutOfRangeException();
        _value = value;
    }
}

    public Cell(Position position, int? value = null)
    {
        Position = position;
        Value = value;
    }
}
