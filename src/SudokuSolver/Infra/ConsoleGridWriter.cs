using System;
using SudokuSolver.Domain;

namespace SudokuSolver.Infra;

public static class ConsoleGridWriter
{
    public static void Write(Grid grid)
    {
        Console.WriteLine("Grille de Sudoku :");
        Console.WriteLine();

        for (int row = 0; row < 9; row++)
        {
            Console.Write($"Ligne {row + 1}: ");

            for (int col = 0; col < 9; col++)
            {
                var cell = grid.GetCellAt(row, col);
                Console.Write(cell.Value?.ToString() ?? ".");
            }

            Console.WriteLine();
        }
    }
}

