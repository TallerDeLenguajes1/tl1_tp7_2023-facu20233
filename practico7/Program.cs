// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using EspacioCalculadora;


static void Main(string[] args)
{
    Calculadora calculadora = new Calculadora();

    Console.WriteLine("Calculadora");
    Console.WriteLine("Ingrese los comandos de operación o 'exit' para salir.");

    string comando;

    // -> sumar 5
    // -> restar 2
    // -> dividir 2
    // -> resultado
    // Resultado: 1,5

    do
    {
        Console.Write("-> ");
        comando = Console.ReadLine();

        if (comando.StartsWith("sumar "))
        {
            double termino = double.Parse(comando.Substring(6));
            calculadora.Sumar(termino);
        }
        else if (comando.StartsWith("restar "))
        {
            double termino = double.Parse(comando.Substring(7));
            calculadora.Restar(termino);
        }
        else if (comando.StartsWith("multiplicar "))
        {
            double termino = double.Parse(comando.Substring(12));
            calculadora.Multiplicar(termino);
        }
        else if (comando.StartsWith("dividir "))
        {
            double termino = double.Parse(comando.Substring(8));
            calculadora.Dividir(termino);
        }
        else if (comando == "limpiar")
        {
            calculadora.Limpiar();
        }
        else if (comando == "resultado")
        {
            Console.WriteLine($"Resultado: {calculadora.Resultado}");
        }
        else if (comando != "exit")
        {
            Console.WriteLine("Comando inválido.");
        }

    } while (comando != "exit");

    Console.WriteLine("¡Hasta luego!");
}


