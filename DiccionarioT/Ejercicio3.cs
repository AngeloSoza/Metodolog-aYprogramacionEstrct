/*Desarrollar un programa que se comporte como un diccionario Inglés-Español; esto es, solicitará
una palabra en inglés y escribirá la correspondiente palabra en español. Para hacer más sencillo
el ejercicio, el número de parejas de palabras estará limitado a 5. Por ejemplo, suponer que
introducimos las siguientes parejas de palabras:
book libro
green verde
mouse ratón
Una vez finalizada la introducción de las listas de palabras, pasamos al modo traducción, de
forma que si introducimos green, la respuesta ha de ser verde. Si la palabra no se encuentra, se
emitirá un mensaje que lo indique.
El programa constará de dos métodos, aparte de Main():
1. crearDiccionario(). Este método creará el diccionario.
2. traducir(). Este método realizará la labor de traducción.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class DiccionarioT
{
    public static void Main()
    {
        List<Tuple<string, string>> diccionario = crearDiccionario();
        traducir(diccionario);
    }

    public static List<Tuple<string, string>> crearDiccionario()
    {
        List<Tuple<string, string>> diccionario = new List<Tuple<string, string>>();
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"Introduce la palabra {i+1} en inglés: ");
            string palabra1 = Console.ReadLine();
            Console.WriteLine($"Introduce la palabra {i + 1} en español: ");
            string palabra2 = Console.ReadLine();

            diccionario.Add(new Tuple<string, string>(palabra1, palabra2));
        }
        return diccionario;
    }

    public static void traducir (List<Tuple<string,string>> diccionario)
    {
        Console.Write("Introduzca la palabra a traducir: ");
        string palabraTrad = Console.ReadLine();
        bool encontrado = false;

        foreach (var duo in diccionario)
        {
            if (duo.Item1.Equals(palabraTrad, StringComparison.OrdinalIgnoreCase))
                {
                Console.WriteLine($"La traducción de {palabraTrad} es : {duo.Item2}");
                encontrado = true;
                break;
                
            } 
            else if (duo.Item2.Equals(palabraTrad, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"La traducción de {palabraTrad} es : {duo.Item1}");
                encontrado = true;
                break;
            }
        }
        if (!encontrado)
        {
            Console.WriteLine("La palabra no se encuentra en el diccionario");
        }
    }
}