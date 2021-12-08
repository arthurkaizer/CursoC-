using System;

using System.Globalization;

namespace exercicios2
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
            //exercicio7();
            exercicio8();

        }

        static void exercicio1()
        {
            int numero = int.Parse(Console.ReadLine());
            imprimeNegativo(numero);
        }
        static void imprimeNegativo(int numero)
        {
            Console.WriteLine(numero < 0 ? "NEGATIVO" : "NAO NEGATIVO");
        }

        static void exercicio2()
        {
            int numero = int.Parse(Console.ReadLine());
            imprimeParidade(numero);
        }
        static void imprimeParidade(int numero)
        {
            Console.WriteLine(numero % 2 == 0 ? "PAR" : "IMPAR");
        }

        static void exercicio3()
        {
            int[] numeros = pegarNumeros();
            imprimeMultiplicidade(numeros[0], numeros[1]);
        }
        static int[] pegarNumeros()
        {
            String[] numerosSeparados = Console.ReadLine().Split(" ");
            int[] numeros = new int[2];
            numeros[0] = int.Parse(numerosSeparados[0]);
            numeros[1] = int.Parse(numerosSeparados[1]);
            return numeros;
        }
        static void imprimeMultiplicidade(int numero1, int numero2)
        {
            Console.WriteLine(saoMultiplos(numero1,numero2) ? "Sao Multiplos" : "Nao sao Multiplos");
        }
        static bool saoMultiplos(int numero1, int numero2)
        {
            return (numero2 % numero1 == 0 || numero1 % numero2 == 0);
        }

        static void exercicio4()
        {
            int[] numeros = pegarNumeros();
            imprimeDuracao(numeros[0], numeros[1]);
        }
        static void imprimeDuracao(int horaInicial, int horaFinal)
        {
            Console.WriteLine($"O JOGO DUROU {calculaDuracao(horaInicial, horaFinal)} HORA(S)");
        }
        static int calculaDuracao(int horaInicial, int horaFinal)
        {
            int duracao = 0;
            if(horaFinal < horaInicial)
            {
                duracao = 24 - horaInicial + horaFinal;
            }
            else
            {
                duracao = horaFinal - horaInicial;
            }
            return duracao;
        }

        static void exercicio5()
        {
            int[] numeros = pegarNumeros();
            imprimeValorAPagar(numeros[0], numeros[1]);
        }
        static void imprimeValorAPagar(int codigo, int quantidade)
        {
            Console.WriteLine($"Total: R$ {calculaValorPagar(codigo, quantidade).ToString("F2",CultureInfo.InvariantCulture)}");
        }
        static double calculaValorPagar(int codigo, int quantidade)
        {
            double total;
            if (codigo == 1)
            {
                total = quantidade * 4.0;
            }
            else if (codigo == 2)
            {
                total = quantidade * 4.5;
            }
            else if (codigo == 3)
            {
                total = quantidade * 5.0;
            }
            else if (codigo == 4)
            {
                total = quantidade * 2.0;
            }
            else
            {
                total = quantidade * 1.5;
            }
            return total;
        }

        static void exercicio6()
        {
            float numero = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            imprimeIntervalo(numero);
        }
        static void imprimeIntervalo(float numero)
        {
            if(numero <= 25.0f)
            {
                Console.WriteLine("Intervalo [0,25]");
            }else if(numero <= 50.0f)
            {
                Console.WriteLine("Intervalo (25,50]");
            }
            else if(numero <= 75.0f)
            {
                Console.WriteLine("Intervalo (50,75]");
            }
            else if(numero <= 100.0f)
            {
                Console.WriteLine("Intervalo (75,100]");
            }
            else
            {
                Console.WriteLine("Fora de intervalo");
            }
        }

        static void exercicio7()
        {
            string[] valores = Console.ReadLine().Split(" ");
            float x = float.Parse(valores[0],CultureInfo.InvariantCulture);
            float y = float.Parse(valores[1], CultureInfo.InvariantCulture);
            imprimeQuadrante(x, y);
        }
        static void imprimeQuadrante(float x, float y)
        {
            if(x < 0.0f)
            {
                if(y < 0.0f)
                {
                    Console.WriteLine("Q3");
                }
                else
                {
                    Console.WriteLine("Q2");
                }
            }else if(x > 0.0f)
            {
                if (y < 0.0f)
                {
                    Console.WriteLine("Q4");
                }
                else
                {
                    Console.WriteLine("Q1");
                }
            }
            else
            {
                Console.WriteLine("Origem");
            }
        }

        static void exercicio8()
        {
            float salario = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            imprimeImposto(salario);
        }
        static void imprimeImposto(float salario)
        {
            float imposto = calculaImposto(salario);
            if(imposto == 0.0f)
            {
                Console.WriteLine("Isento");
            }
            else
            {
                Console.WriteLine($"R$ {imposto.ToString("F2", CultureInfo.InvariantCulture)}");
            }
        }
        static float calculaImposto(float salario)
        {
            float imposto;
            if (salario <= 2000.0f)
            {
                imposto = 0.0f;
            }
            else if (salario <= 3000.0f)
            {
                imposto = (salario - 2000.0f) * 0.08f;
            }
            else if (salario <= 4500.0)
            {
                imposto = (salario - 3000.0f) * 0.18f + 1000.0f * 0.08f;
            }
            else
            {
                imposto = (salario - 4500.0f) * 0.28f + 1500.0f * 0.18f + 1000.0f * 0.08f;
            }
            return imposto;
        }
    }
}
