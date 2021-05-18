using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace pruebaEquitel
{
    class Program
    {
        static void Main()
        {
            var inputFileName = "Texto.txt";
            var outputFileName = "Result.txt";
            var currentDirectory = Directory.GetCurrentDirectory();

            string inputFilePath = Path.Combine(currentDirectory,"txt", inputFileName);
            string outputFilePath = Path.Combine(currentDirectory, "txt", outputFileName);

            var analyseDataTask = DataAnalyse.AnalyseText(inputFilePath, outputFilePath);

            //bool analyseDataResult = analyseDataTask

            //if (analyseDataResult)
            //{
            //    Console.WriteLine($"El archivo {inputFileName} fue analizado con exito");
            //    Console.WriteLine($"Los resultados se pueden encontrar en el archivo {outputFileName}");
            //}


        }
    }
}

