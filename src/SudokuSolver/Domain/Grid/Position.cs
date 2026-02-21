namespace SudokuSolver.Domain;

public readonly struct Position
{
    public int Row { get; }
    public int Column { get; }

    public Position(int row, int column)
    {
        if (row < 0 || row > 8)
            throw new ArgumentOutOfRangeException(nameof(row));
        if (column < 0 || column > 8)
            throw new ArgumentOutOfRangeException(nameof(column));

        Row = row;
        Column = column;
    }

    public override string ToString() => $"({Row}, {Column})";
}
