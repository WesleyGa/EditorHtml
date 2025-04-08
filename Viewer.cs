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
            var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");

            // 'words' recebe um array de strings (string[]), ou seja, uma lista de palavras separadas com base nos espaços em branco.
            //  A ideia aqui é apenas para fins de aprendizado, não visando performance.
            var words = text.Split(' '); // Divide a string text em várias palavras, separadas por espaços.

            for (var i = 0; i < words.Length; i++) // Loop por todas as palavras separadas.
            {
                if (strong.IsMatch(words[i])) // Se a palavra atual (words[i]) contém uma tag <strong>.
                {
                    Console.ForegroundColor = ConsoleColor.Blue; // Muda a cor do texto no console para azul.
                    Console.Write(
                        words[i].Substring(
                            words[i].IndexOf('>') + 1, // encontra o > da primeira tag (<strong>), que está na posição 7.
                            (
                             (words[i].LastIndexOf('<') - 1) -
                             words[i].IndexOf('>')
                            )
                        )
                    );
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(words[i]);
                    Console.Write(" ");
                }
            }
        }

    }
}