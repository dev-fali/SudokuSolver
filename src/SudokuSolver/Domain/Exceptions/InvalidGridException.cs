
namespace SudokuSolver.Domain.Exceptions;
public sealed class InvalidGridException : Exception
{
    public InvalidGridException(string message)
        : base(message)
    {
    }
}
