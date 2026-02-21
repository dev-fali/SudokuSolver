using SudokuSolver.Application;
using SudokuSolver.Infra;
using SudokuSolver.Solvers;

namespace Sudoku.ConsoleApp;

public static class Program
{
    static void Main()
    {
        try
        {
            var grid = ConsoleGridReader.Read();

            var solver = SolverFactory.CreateMrvSolver(grid);
            var useCase = new SolveSudokuUseCase(solver);

            useCase.Execute(grid);

            ConsoleGridWriter.Write(grid);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
        }
    }
}
