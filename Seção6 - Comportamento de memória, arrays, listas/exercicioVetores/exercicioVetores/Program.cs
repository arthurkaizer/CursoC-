using System;

namespace exercicioVetores
{
    class Program
    {
        static void Main(string[] args)
        {
            Estudante[] quartos = new Estudante[10];
            Console.Write("Quantos quartos serão alugados?");
            int qtdeQuartos = int.Parse(Console.ReadLine());

            registrarAluguel(quartos, qtdeQuartos);
            mostrarAlugueis(quartos);

        }
        static void registrarAluguel(Estudante[] quartos, int qtdeQuartos)
        {
            for(int i = 0; i < qtdeQuartos; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Aluguel #{i+1}:");
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Quarto: ");
                int quarto = int.Parse(Console.ReadLine());
                quartos[quarto] = new Estudante(nome, email);
            }
        }

        static void mostrarAlugueis(Estudante[] quartos)
        {
            Console.WriteLine("Quartos ocupados:");
            for(int i = 0; i < quartos.Length; i++)
            {
                if(quartos[i] != null)
                {
                    Console.WriteLine(i + ": " + quartos[i]);
                }
            }
        }
    }
}
