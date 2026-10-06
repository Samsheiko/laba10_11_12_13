using System;
using System.IO;

namespace compiler
{
    static class InputOutputTests
    {
        private static string CreateTestFile(string fileName, string content)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + fileName;
            File.WriteAllText(path, content);
            return path;
        }

        public static void RunAllTests()
        {
            Console.WriteLine("==========================");
            Console.WriteLine(" ТЕСТ МОДУЛЯ ВВОДА-ВЫВОДА ");
            Console.WriteLine("==========================");

            InputOutput.PrintErrorTable();

            TestPascalProgram();
        }

        private static void TestPascalProgram()
        {
            string content =
                "program test;\n" +
                "var p : record x, y: integer; end;\n" +
                "begin\n" +
                "  with p do\n" +
                "  begin\n" +
                "    x := 10;\n" +
                "    y := 20\n" + 
                "  end;\n" +
                "end.";

            string fileName = CreateTestFile("test_v9.pas", content);

            InputOutput.OpenFile(fileName);

            
            InputOutput.Error(100, new TextPosition(2, 12));

            InputOutput.Error(52, new TextPosition(7, 11));

            while (InputOutput.Ch != '\0')
            {
                InputOutput.NextCh();
            }

            InputOutput.CloseFile();
        }
    }
}
