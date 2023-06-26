// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;

namespace administracion
{
    public enum Cargos
    {
        Auxiliar,
        Administrativo,
        Ingeniero,
        Especialista,
        Investigador
    }

    public class Empleado
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public char EstadoCivil { get; set; }
        public char Genero { get; set; }
        public DateTime FechaIngreso { get; set; }
        public double SueldoBasico { get; set; }
        public Cargos Cargo { get; set; }

        public int Antiguedad
        {
            get
            {
                TimeSpan antiguedad = DateTime.Now - FechaIngreso;
                return antiguedad.Days / 365;
            }
        }

        public int Edad
        {
            get
            {
                TimeSpan edad = DateTime.Now - FechaNacimiento;
                return edad.Days / 365;
            }
        }

        public int AniosParaJubilarse
        {
            get
            {
                int edadJubilacion = (Genero == 'M') ? 65 : 60;
                int aniosParaJubilarse = edadJubilacion - Edad;
                return Math.Max(aniosParaJubilarse, 0);
            }
        }

        public double Salario
        {
            get
            {
                double adicional = 0;
                int antiguedad = Antiguedad;

                if (antiguedad <= 20)
                    adicional = SueldoBasico * (antiguedad * 0.01);
                else
                    adicional = SueldoBasico * 0.25;

                if (Cargo == Cargos.Ingeniero || Cargo == Cargos.Especialista)
                    adicional += SueldoBasico * 0.5;

                if (EstadoCivil == 'C')
                    adicional += 15000;

                return SueldoBasico + adicional;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Cargar datos para 3 empleados
            Empleado empleado1 = new Empleado
            {
                Nombre = "Juan",
                Apellido = "Pérez",
                FechaNacimiento = new DateTime(1985, 3, 10),
                EstadoCivil = 'S',
                Genero = 'M',
                FechaIngreso = new DateTime(2010, 6, 15),
                SueldoBasico = 50000,
                Cargo = Cargos.Ingeniero
            };

            Empleado empleado2 = new Empleado
            {
                Nombre = "María",
                Apellido = "González",
                FechaNacimiento = new DateTime(1990, 7, 20),
                EstadoCivil = 'C',
                Genero = 'F',
                FechaIngreso = new DateTime(2012, 9, 1),
                SueldoBasico = 60000,
                Cargo = Cargos.Administrativo
            };

            Empleado empleado3 = new Empleado
            {
                Nombre = "Carlos",
                Apellido = "López",
                FechaNacimiento = new DateTime(1988, 12, 5),
                EstadoCivil = 'S',
                Genero = 'M',
                FechaIngreso = new DateTime(2015, 4, 10),
                SueldoBasico = 55000,
                Cargo = Cargos.Especialista
            };

            // Obtener el Monto Total de lo que se paga en concepto de Salarios
            double montoTotalSalarios = empleado1.Salario + empleado2.Salario + empleado3.Salario;

            // Encontrar el empleado más próximo a jubilarse
            Empleado empleadoMasProximoJubilarse = empleado1;
            int aniosProximoJubilarse = empleado1.AniosParaJubilarse;

            if (empleado2.AniosParaJubilarse < aniosProximoJubilarse)
            {
                empleadoMasProximoJubilarse = empleado2;
                aniosProximoJubilarse = empleado2.AniosParaJubilarse;
            }

            if (empleado3.AniosParaJubilarse < aniosProximoJubilarse)
            {
                empleadoMasProximoJubilarse = empleado3;
                aniosProximoJubilarse = empleado3.AniosParaJubilarse;
            }

            // Mostrar los datos del empleado más próximo a jubilarse
            Console.WriteLine("Empleado más próximo a jubilarse:");
            Console.WriteLine($"Nombre: {empleadoMasProximoJubilarse.Nombre} {empleadoMasProximoJubilarse.Apellido}");
            Console.WriteLine($"Edad: {empleadoMasProximoJubilarse.Edad}");
            Console.WriteLine($"Años para jubilarse: {empleadoMasProximoJubilarse.AniosParaJubilarse}");
            Console.WriteLine($"Salario: {empleadoMasProximoJubilarse.Salario}");

            Console.WriteLine("Monto Total de Salarios: " + montoTotalSalarios);
        }
    }
}


