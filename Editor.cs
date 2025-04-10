using System;
using System.IO;
using System.Text;



namespace EditorHtml
{

    public static class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("------------");
            Start();


        }

        public static void Start()
        {
            var file = new StringBuilder();
            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Viewer.Show(file.ToString());

            Console.WriteLine("Deseja salvar este arquivo? Sim ou não:");
            string option = Console.ReadLine().Trim().ToLower(); ; // Trim: Ignora espaços antes e depois da frase.

            if (option.Equals("sim"))
                Salvar(file.ToString()); // Converte StringBuilder para string antes de salvar.

            if (option != "sim")
                Menu.Show();


        }

        public static void Salvar(string text)
        {

            Console.WriteLine("Em qual endereço deseja salvar:");
            string path = Console.ReadLine();
            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }
            Console.WriteLine("Arquivo salvo com sucesso");
            Console.ReadKey();
            Menu.Show();

        }


    }
}