using System;
using System.Globalization;

namespace exercicios1
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
            exercicio6();
        }

        static void exercicio1()
        {
            int[] numeros = new int[2];
            foreach (int i in numeros)
            {
                numeros[i] = int.Parse(Console.ReadLine());
            }
            imprimeSoma(numeros);
        }
        static void imprimeSoma(int[] numeros)
        {
            Console.WriteLine($"SOMA = {soma(numeros[0], numeros[1])}");
        }
        static int soma(int numero1, int numero2)
        {
            return (numero1 + numero2);
        }

        static void exercicio2()
        {
            float raio = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            imprimeArea(raio);
        }
        static void imprimeArea(float raio)
        {
            Console.WriteLine($"A={calculaArea(raio).ToString(CultureInfo.InvariantCulture)}");
        }
        static float calculaArea(float raio)
        {
            const float pi = 3.14159f;
            return (pi * raio * raio);
        }

        static void exercicio3()
        {
            int a, b, c, d;
            a = int.Parse(Console.ReadLine());
            b = int.Parse(Console.ReadLine());
            c = int.Parse(Console.ReadLine());
            d = int.Parse(Console.ReadLine());
            imprimeDiferenca(a, b, c, d);
        }
        static void imprimeDiferenca(int a, int b, int c, int d)
        {
            Console.WriteLine($"DIFERENCA = {diferenca(a, b, c, d)}");
        }
        static int diferenca(int a, int b, int c, int d)
        {
            return ((a * b) - (c * d));
        }

        static void exercicio4()
        {
            int numeroFuncionario = int.Parse(Console.ReadLine());
            int horasTrabalhadas = int.Parse(Console.ReadLine());
            float valorDaHora = float.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            imprimeNumeroESalario(numeroFuncionario, horasTrabalhadas, valorDaHora);
        }
        static void imprimeNumeroESalario(int numeroFuncionario, int horasTrabalhadas, float valorDaHora)
        {
            Console.WriteLine($"NUMBER = {numeroFuncionario}\nSALARY = U$ {calculaSalario(horasTrabalhadas, valorDaHora).ToString("F2", CultureInfo.InvariantCulture)}");

        }
        static float calculaSalario(int horasTrabalhadas, float valorHora)
        {
            return (horasTrabalhadas * valorHora);
        }

        static void exercicio5()
        {
            String dadosPeca1 = Console.ReadLine();
            String dadosPeca2 = Console.ReadLine();
            imprimeValorASerPago(dadosPeca1, dadosPeca2);
        }
        static void imprimeValorASerPago(String dadosPeca1, String dadosPeca2)
        {
            Console.WriteLine($"VALOR A PAGAR: R$ {calculaValorTotal(dadosPeca1, dadosPeca2).ToString("F2", CultureInfo.InvariantCulture)}");
        }
        static float calculaValorTotal(String dadosPeca1, String dadosPeca2)
        {
            float valorTotal = 0;
            valorTotal += calculaValorUmaPeca(dadosPeca1);
            valorTotal += calculaValorUmaPeca(dadosPeca2);
            return valorTotal;
        }
        static float calculaValorUmaPeca(String dadosPeca)
        {
            String[] dadosPecaSeparado = dadosPeca.Split(" ");
            //numero de peças * valor unitário
            float valorTotalPeca = int.Parse(dadosPecaSeparado[1]) * float.Parse(dadosPecaSeparado[2], CultureInfo.InvariantCulture);
            return valorTotalPeca;
        }

        static void exercicio6()
        {
            String valoresJuntos = Console.ReadLine();
            imprimeDados(valoresJuntos);
        }
        static void imprimeDados(String valoresJuntos)
        {
            float[] valoresFloat = separaValores(valoresJuntos);
            Console.WriteLine($"TRIANGULO: {calculaAreaTriangulo(valoresFloat).ToString("F3", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"CIRCULO: {calculaAreaCirculo(valoresFloat).ToString("F3", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"TRAPEZIO: {calculaAreaTrapezio(valoresFloat).ToString("F3", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"QUADRADO: {calculaAreaQuadrado(valoresFloat).ToString("F3", CultureInfo.InvariantCulture)}");
            Console.WriteLine($"RETANGULO: {calculaAreaRetangulo(valoresFloat).ToString("F3", CultureInfo.InvariantCulture)}");


        }
        static float[] separaValores(String valoresJuntos)
        {
            String[] valoresSeparadosString = valoresJuntos.Split(" ");
            float[] valoresSeparadosConvertido = new float[valoresSeparadosString.Length];
            for (int i = 0; i < valoresSeparadosString.Length; i++)
            {
                valoresSeparadosConvertido[i] = float.Parse(valoresSeparadosString[i], CultureInfo.InvariantCulture);
            }

            return valoresSeparadosConvertido;
        }
        static float calculaAreaTriangulo(float[] valoresFloat)
        {
            return ((valoresFloat[0] * valoresFloat[2]) / 2);
        }
        static float calculaAreaCirculo(float[] valoresFloat)
        {
            const float pi = 3.14159f;
            return (pi * valoresFloat[2] * valoresFloat[2]);
        }
        static float calculaAreaTrapezio(float[] valoresFloat)
        {
            return ((valoresFloat[2] * (valoresFloat[0] + valoresFloat[1])) / 2);
        }
        static float calculaAreaQuadrado(float[] valoresFloat)
        {
            return (valoresFloat[1] * valoresFloat[1]);
        }
        static float calculaAreaRetangulo(float[] valoresFloat)
        {
            return (valoresFloat[0] * valoresFloat[1]);
        }
    }
}
