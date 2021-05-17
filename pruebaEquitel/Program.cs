using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace pruebaEquitel
{
    class Program
    {
        static void Main()
        {
            var inputFileName = "Texto.txt";
            var outputFileName = "Result.txt";
            var currentDirectory = Directory.GetCurrentDirectory();

            var inputFilePath = Path.Combine(currentDirectory,"txt", inputFileName);
            var outputFilePath = Path.Combine(currentDirectory, "txt", outputFileName);

            AnalyseText(inputFilePath, outputFilePath);
        }
        static void AnalyseText(string inputFilePath, string outputFilePath)
        {
            int counter;

            List<string> results = new List<string>();

            var inputFile = File.ReadAllText(inputFilePath);

            File.AppendAllTextAsync(outputFilePath, $"\n\n\nResultados de la ejecucion realizada en la fecha {DateTime.UtcNow} \n\n");

            counter = wordsFinalN(inputFile);
            File.AppendAllTextAsync(outputFilePath, $"La cantidad de palabras que terminan en N o n es de: {counter}\n");
            
            counter = fifteenWords(inputFile);
            File.AppendAllTextAsync(outputFilePath, $"El numero de frases que contiene mas de 15 palabras es de: {counter}\n");

            counter = paragraphCounter(inputFile);
            File.AppendAllTextAsync(outputFilePath, $"El numero de parrafos en el texto es de: {counter}\n");

            counter = distinctNChar(inputFile);
            File.AppendAllTextAsync(outputFilePath, $"La cantidad de caracteres diferentes a N o n es: {counter}\n");
        }
        static int wordsFinalN (string file)
        {
            int contador;
            var pattern = @"\b\w+n\b";
            contador = Regex.Matches(file, pattern).Count;

            return contador;
        }
        static int fifteenWords(string file)
        {
            int contador;
            var pattern = @"(([\-_\('’""]*\b\w+\b[ \),:;\-_'’""]*){16,})\.[ ]";
            contador = Regex.Matches(file, pattern).Count;

            return contador;
        }
        static int paragraphCounter (string file)
        {
            int contador;
            var pattern = @"\.\r";
            contador = Regex.Matches(file, pattern).Count;

            return contador;
        }
        static int distinctNChar(string file)
        {
            int contador;
            var pattern = @"[^nN\s\p{P}]";
            contador = Regex.Matches(file, pattern).Count;

            return contador;
        }
    }
}

