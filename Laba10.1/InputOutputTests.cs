using System;
using System.IO;

namespace Компилятор
{
    static class InputOutputTests
    {
        public static void RunAllTests()
        {
            Console.WriteLine("╔════════════════════════╗");
            Console.WriteLine("║ ЛЕКСИЧЕСКИЙ АНАЛИЗАТОР ║");
            Console.WriteLine("╚════════════════════════╝");

            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "test.pas");

            if (!File.Exists(filePath))
            {
                Console.WriteLine();
                Console.WriteLine("Файл test.pas не найден!");
                Console.WriteLine("Искал по пути: " + filePath);
                return;
            }

            Console.WriteLine();
            Console.WriteLine("Исходная программа:");
            Console.WriteLine();

            string[] lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine((i + 1).ToString().PadLeft(4) + " " + lines[i]);
            }

            Console.WriteLine();
            Console.WriteLine("=== ПОИСК ЛЕКСИЧЕСКИХ ОШИБОК ===");
            Console.WriteLine();

            InputOutput.OpenFile(filePath);

            LexicalAnalyzer lexer = new LexicalAnalyzer();

            while (lexer.NextSym() != 0)
            {
                Console.Write(lexer.Symbol + " ");
            }
            Console.WriteLine();

            InputOutput.CloseFile();

            Console.WriteLine();
            Console.WriteLine("Лексический анализ завершён.");
            Console.WriteLine();

            InputOutput.PrintErrors();
        }
    }
}
