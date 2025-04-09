using System;
using System.IO;


namespace EditorHtml
{
    public static class OpenArchive
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Qual é o caminho do arquivo que deseja abrir?");
            string path = Console.ReadLine();

            Console.WriteLine("Arquivo aberto");
            Console.WriteLine("------------");
            Reader(path);
            Console.WriteLine("------------");
            Console.ReadKey();


        }
        public static void Reader(string path)
        {
            using (var file = new StreamReader(path))
            {
                string content = file.ReadToEnd();
                Viewer.Replace(content);
            }
        }
    }
}