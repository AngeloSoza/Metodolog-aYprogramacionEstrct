/*Desarrollar un programa que permita al usuario gestionar una cuenta bancaria. El programa
deberá utilizar un menú que permita realizar diferentes operaciones sobre el saldo de la cuenta.
Menú de opciones:
1. Consultar saldo
2. Depositar dinero
3. Retirar dinero
4. Salir
El programa debe permitir al usuario ingresar la cantidad para depositar o retirar, actualizar el
saldo y mostrar los resultados. Si se elige la opción de retiro, debe verificar que el saldo sea
suficiente.*/

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<decimal> transacciones = new List<decimal>();
        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1. Consultar saldo");
            Console.WriteLine("2. Depositar dinero");
            Console.WriteLine("3. Retirar dinero");
            Console.WriteLine("4. Salir");
            Console.Write("Elige una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    decimal saldo = CalcularSaldo(transacciones);
                    Console.WriteLine($"Saldo actual: {saldo:C}");
                    break;

                case "2":
                    Console.Write("Ingresa la cantidad a depositar: ");
                    decimal deposito = Convert.ToDecimal(Console.ReadLine());
                    transacciones.Add(deposito);
                    Console.WriteLine("Depósito realizado.");
                    break;

                case "3":
                    Console.Write("Ingresa la cantidad a retirar: ");
                    decimal retiro = Convert.ToDecimal(Console.ReadLine());
                    decimal saldoActual = CalcularSaldo(transacciones);
                    if (retiro <= saldoActual)
                    {
                        transacciones.Add(-retiro);
                        Console.WriteLine("Retiro realizado.");
                    }
                    else
                    {
                        Console.WriteLine("Saldo insuficiente.");
                    }
                    break;

                case "4":
                    salir = true;
                    Console.WriteLine("Saliendo del programa.");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
            Console.WriteLine();
        }
    }

    static decimal CalcularSaldo(List<decimal> transacciones)
    {
        decimal saldo = 0;
        foreach (var transaccion in transacciones)
        {
            saldo += transaccion;
        }
        return saldo;
    }
}
