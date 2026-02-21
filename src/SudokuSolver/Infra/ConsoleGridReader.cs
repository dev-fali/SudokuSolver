using System;
using System.Collections.Generic;
using System.Linq;
using SudokuSolver.Domain;

namespace SudokuSolver.Infra;

public static class ConsoleGridReader
{
    public static Grid Read()
    {
        var cells = new List<Cell>(81);

        Console.WriteLine("Entrez la grille ligne par ligne (9 caractères : 1-9 ou '.' pour vide)");

        for (int row = 0; row < 9; row++)
        {
            string line = ReadValidLine(row);

            for (int col = 0; col < 9; col++)
            {
                char c = line[col];
                int? value = c == '.' ? null : c - '0';

                cells.Add(new Cell(new Position(row, col), value));
            }
        }

        return new Grid(cells);
    }

    private static string ReadValidLine(int row)
    {
        while (true)
        {
            Console.Write($"Ligne {row + 1} : ");
            var input = Console.ReadLine();

            if (input == null)
            {
                Console.WriteLine("Entrée invalide.");
                continue;
            }

            if (input.Length != 9)
            {
                Console.WriteLine("❌ La ligne doit contenir exactement 9 caractères.");
                continue;
            }

            if (!input.All(c => c == '.' || (c >= '1' && c <= '9')))
            {
                Console.WriteLine("❌ Caractères autorisés : chiffres 1-9 ou '.'");
                continue;
            }

            return input;
        }
    }
}
