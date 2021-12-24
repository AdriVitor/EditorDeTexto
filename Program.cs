using System;
using System.IO;

namespace EditorDeTexto
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();

            Console.WriteLine("Olá");
            Console.WriteLine("1 --- Abrir");
            Console.WriteLine("2 --- Editar");
            Console.WriteLine("0 --- Sair");
            Console.WriteLine("O que você deseja fazer? ");
            short option = short.Parse(Console.ReadLine());
            switch(option){
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }
            
        }
        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine("Olá, digite o caminho do arquivo que você deseja ler: ");
            var path = Console.ReadLine();

            using(var file = new StreamReader(path)){
                string text = file.ReadToEnd();
                Console.WriteLine("");
                Console.WriteLine(text);
            }
        }

        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Digite o seu texto");
            Console.WriteLine("ESC para sair");
            Console.WriteLine("-------------------");
            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine; 
                
            }
            while(Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine(text);

            Salvar(text);
        }
    
        static void Salvar(string text){
            Console.Clear();
            Console.WriteLine("Digite o caminho para salvar o arquivo: ");
            var path = Console.ReadLine();

            using(var file = new StreamWriter(path)){
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso");
        }
    
    
    }
}
