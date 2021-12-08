using System;

namespace exercicios3
{
    class Program
    {
        static void Main(string[] args)
        {
            //exercicio1();
            //exercicio2();
            exercicio3();
        }

        static void exercicio1()
        {
            int senha = int.Parse(Console.ReadLine());

            while (senha != 2002)
            {
                Console.WriteLine("Senha Invalida");
                senha = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Acesso Permitido");
        }

        static void exercicio2()
        {
            imprimeQuadrante();
        }
        static void imprimeQuadrante()
        {
            string[] x_y = Console.ReadLine().Split(" ");
            while (!existeNulo(x_y))
            {
                Console.WriteLine(calculaQuadrante(x_y));
                x_y = Console.ReadLine().Split(" ");
            }
        }
        static bool existeNulo(string[] x_y)
        {
            return (x_y[0].CompareTo("0") == 0 || x_y[1].CompareTo("0") == 0);
        }
        static string calculaQuadrante(string[] x_y)
        {
            string quadrante;
            int x = int.Parse(x_y[0]);
            int y = int.Parse(x_y[1]);
            if (x < 0)
            {
                if (y < 0)
                {
                    quadrante = "terceiro";
                }
                else
                {
                    quadrante = "segundo";
                }
            }
            else
            {
                if (y < 0)
                {
                    quadrante = "quarto";
                }
                else
                {
                    quadrante = "primeiro";
                }
            }
            return quadrante;
        }

        static void exercicio3()
        {
            imprimePreferencia();
        }
        static void imprimePreferencia()
        {
            int alcool = 0;
            int gasolina = 0;
            int diesel = 0;

            int tipo = int.Parse(Console.ReadLine());

            while (tipo != 4)
            {
                if (tipo == 1)
                {
                    alcool += 1;
                }
                else if (tipo == 2)
                {
                    gasolina += 1;
                }
                else if (tipo == 3)
                {
                    diesel += 1;
                }

                tipo = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("MUITO OBRIGADO");
            Console.WriteLine("Alcool: " + alcool);
            Console.WriteLine("Gasolina: " + gasolina);
            Console.WriteLine("Diesel: " + diesel);
        }
    }
}
