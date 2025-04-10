using System;
using System.Text.RegularExpressions;

namespace EditorHtml
{

    public static class Viewer
    {
        public static void Show(string text)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO VISUALIZAÇÃO");
            Console.WriteLine("------------");
            Replace(text);
            Console.WriteLine("------------");
            Console.ReadKey();


        }

        public static void Replace(string text)
        {
            // Cria um objeto Regex (expressão regular) que vai encontrar qualquer texto que esteja dentro de uma 
            // tag <strong>...</strong>.
            var tags = new Regex(@"<\s*(h1|strong|p|li)[^>]*>(.*?)<\s*/\s*\1>", RegexOptions.Singleline); //O \1 significa: feche com a mesma tag que abriu.

            // 'words' recebe um array de strings (string[]), ou seja, uma lista de palavras separadas com base nos espaços em branco.
            //  A ideia aqui é apenas para fins de aprendizado, não visando performance.
            var words = tags.Matches(text); // Divide a string text em várias palavras, separadas por espaços.

            foreach (Match match1 in words) // Loop por todas as palavras separadas.
            {
                if (tags.IsMatch(match1.Value)) // Se a palavra atual (words[i]) contém uma tag <strong>.
                {
                    var type = match1.Groups[1].Value;
                    switch (type)
                    {
                        case "strong": Console.ForegroundColor = ConsoleColor.Red; break;
                        case "h1": Console.ForegroundColor = ConsoleColor.Cyan; break;
                        case "title": Console.ForegroundColor = ConsoleColor.DarkRed; break;
                        case "p": Console.ForegroundColor = ConsoleColor.Yellow; break;
                        case "li":
                            Console.ForegroundColor = ConsoleColor.Green; break;
                    }

                    Console.WriteLine(match1.Groups[2].Value);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(match1.Value);
                    Console.Write(" ");
                }
            }
        }


    }
}