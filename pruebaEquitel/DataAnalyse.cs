using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace pruebaEquitel
{
    class DataAnalyse
    {
        public static async Task<bool> AnalyseText(string inputFilePath, string outputFilePath)
        {
            List<int> results = new List<int>();

            var file = loadFile(inputFilePath);

            File.AppendAllText(outputFilePath, $"\n\n\nResultados de la ejecucion realizada en la fecha {DateTime.Now} \n\n");            

            var wordsFinalNTask =   wordsFinalN(file, outputFilePath);
            var fifteenWordsTask =  fifteenWords(file, outputFilePath);
            var paragraphCounterTask =  paragraphCounter(file, outputFilePath);
            var distinctNCharTask =  distinctNChar(file, outputFilePath);

            await Task.WhenAll(wordsFinalNTask, fifteenWordsTask, paragraphCounterTask, distinctNCharTask);

            return true;
        }
        static string loadFile (string filePath)
        {
            string file = File.ReadAllText(filePath);

            return file;
        }
        static async Task<int> wordsFinalN(string file, string filePath)
        {
            int contador = 0;
            var pattern = @"\b\w+n\b";


            contador = Regex.Matches(file, pattern).Count;
            await File.AppendAllTextAsync(filePath, $"La cantidad de palabras que terminan en N o n es de: {contador}\n");
   
            
            return contador;
        }
        static async Task<int> fifteenWords(string file, string filePath)
        {
            int counter = 0;
            var pattern = @"(([\-_\('’""]*\b\w+\b[ \),:;\-_'’""]*){16,})\.[ ]";

            counter = Regex.Matches(file, pattern).Count;
            await File.AppendAllTextAsync(filePath, $"El numero de frases que contiene mas de 15 palabras es de: {counter}\n");

            return counter;
        }
        static async Task<int> paragraphCounter(string file, string filePath)
        {
            int counter = 0;
            var pattern = @"\.\r";

            counter = Regex.Matches(file, pattern).Count;
            await File.AppendAllTextAsync(filePath, $"El numero de parrafos en el texto es de: {counter}\n");


            return counter;
        }
        static async Task<int> distinctNChar(string file, string filePath)
        {
            int counter = 0;
            var pattern = @"[^nN\s\p{P}]";

            counter = Regex.Matches(file, pattern).Count;
            await File.AppendAllTextAsync(filePath, $"La cantidad de caracteres diferentes a N o n es: {counter}\n");

            return counter;
        }

    }
}
