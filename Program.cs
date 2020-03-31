using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace string_test
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numberOfStrings = 10000000;
            const int minStringLength = 30;
            const int maxStringLength = 100;
            const int showFirstNLines = 5;
            const int charactersToShow = 500;

            var sw = new Stopwatch();
            var rnd = new Random();

            // Generate random array of text (could be replaced to read from already generated file)
            var arr = new string[numberOfStrings];
            Console.WriteLine($"Generating array of {numberOfStrings} random strings and putting them into one array");
            sw.Start();
            for (int i = 0; i < numberOfStrings; i++)
            {
                arr[i] = RandomStringUtils.RandomStringUtils.RandomAlphanumeric(rnd.Next(minStringLength, maxStringLength));
            }
            Console.WriteLine($"... Done! Took {sw.ElapsedMilliseconds}ms");
            Console.WriteLine();

            // Write array to file for later use and comparison
            using (var f = File.OpenWrite("arr.txt"))
            {
                var writer = new StreamWriter(f);

                foreach (var s in arr)
                {
                    writer.WriteLine(s);
                }
            }

            // For debugging and testing, print first lines
            PrintFirstLines(arr, showFirstNLines);

            // Sort array of random text
            Console.WriteLine($"Sorting array of {numberOfStrings} random strings");
            sw.Restart();
            Array.Sort(arr);
            Console.WriteLine($"... Done! Took {sw.ElapsedMilliseconds}ms");
            Console.WriteLine();

            // Print first lines again to show that array has been sorted
            PrintFirstLines(arr, showFirstNLines);

            // Test combining lines into one huge big string
            var sb = new StringBuilder();
            Console.WriteLine($"Combining {numberOfStrings} strings into one");
            sw.Restart();
            foreach (var s in arr)
            {
                sb.Append(s);
            }
            var str = sb.ToString();
            Console.WriteLine($"... Done! Took {sw.ElapsedMilliseconds}ms");
            Console.WriteLine();

            // Print the combined string to see that it worked
            Console.WriteLine($"Showing first {charactersToShow} characters of combined string");
            Console.WriteLine(str.Substring(0, charactersToShow));


        }

        private static void PrintFirstLines(string[] arr, int linesToPrint)
        {
            Console.WriteLine($"Showing first {linesToPrint} lines of array");
            for (int i = 0; i < linesToPrint; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine();
        }
    }
}
