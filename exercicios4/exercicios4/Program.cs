using System;
using System.Globalization;

namespace exercicios4
{
    class Program
    {
        static void Main(string[] args)
        {
            //exercicio1();
            //exercicio2();
            //exercicio3();
            //exercicio4();
            //exercicio5();
            //exercicio6();
            exercicio7();
        }

        static void exercicio1()
        {
            int x = int.Parse(Console.ReadLine());
            imprimeInteirosAteX(x);
        }
        static void imprimeInteirosAteX(int x)
        {
            for(int i = 1; i < 8; i += 2)
            {
                Console.WriteLine(i);
            }
        }

        static void exercicio2()
        {
            int N = int.Parse(Console.ReadLine());
            imprimirNumerosIntervalo(N);
        }
        static void imprimirNumerosIntervalo(int N)
        {
            int qtdeForaIntervalo = 0;
            int qtdeDentroIntervalo = 0;
            int numero;
            for(int i = 0; i < N; i++)
            {
                numero = int.Parse(Console.ReadLine());
                if(numero < 20 && numero > 10)
                {
                    qtdeDentroIntervalo++;
                }
                else
                {
                    qtdeForaIntervalo++;
                }
            }
            Console.WriteLine($"{qtdeDentroIntervalo} in");
            Console.WriteLine($"{qtdeForaIntervalo} out");
        }

        static void exercicio3()
        {
            int N = int.Parse(Console.ReadLine());
            for(int i = 0; i < N; i++)
            {
                imprimirMedia();
            }
        }
        static void imprimirMedia()
        {
            string[] line = Console.ReadLine().Split(' ');
            double a = double.Parse(line[0], CultureInfo.InvariantCulture);
            double b = double.Parse(line[1], CultureInfo.InvariantCulture);
            double c = double.Parse(line[2], CultureInfo.InvariantCulture);

            double media = (a * 2.0 + b * 3.0 + c * 5.0) / 10.0;

            Console.WriteLine(media.ToString("F1", CultureInfo.InvariantCulture));
        }

        static void exercicio4()
        {
            int N = int.Parse(Console.ReadLine());
            for(int i = 0; i < N; i++)
            {
                imprimeDivisao();
            }
        }
        static void imprimeDivisao()
        {
            string[] numeros = Console.ReadLine().Split(" ");
            double numero1 = double.Parse(numeros[0]);
            double numero2 = double.Parse(numeros[1]);
            if(numero2 == 0)
            {
                Console.WriteLine("divisao impossivel");
            }
            else
            {
                Console.WriteLine((numero1 / numero2).ToString("F1", CultureInfo.InvariantCulture));
            }
        }

        static void exercicio5()
        {
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine(fatorial(N));
        }
        static int fatorial(int N)
        {
            int fatorial = 1;
            for(int i = 1; i <= N; i++)
            {
                fatorial *= i;
            }
            return fatorial;
        }

        static void exercicio6()
        {
            int N = int.Parse(Console.ReadLine());
            imprimirDivisores(N);
        }
        static void imprimirDivisores(int N)
        {
            for(int i = 1; i <= N; i++)
            {
                if(N % i == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void exercicio7()
        {
            int N = int.Parse(Console.ReadLine());
            imprimirLinhas(N);
        }
        static void imprimirLinhas(int N)
        {
            for(int i = 1; i <= N; i++)
            {
                Console.WriteLine($"{i} {i * i} {i * i * i}");
            }
        }
    }
}
