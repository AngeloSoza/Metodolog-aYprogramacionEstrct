/*Crear un programa que simule la gestión de un inventario en una tienda. Utilizar un menú para
agregar, eliminar, modificar y consultar productos en el inventario. Cada producto tendrá un
código, nombre, cantidad y precio.
Menú de opciones:
1. Agregar producto
2. Eliminar producto
3. Modificar producto
4. Consultar producto
5. Mostrar todos los productos
6. Salir*/

using System;
using System.Collections.Generic;

internal class InventarioTienda
{
    public static void Main()
    {
        List<Tuple<int, string, int, decimal>> inventario = crearInventario();
        GestionarInventario(inventario);
    }

    public static List<Tuple<int, string, int, decimal>> crearInventario()
    {
        return new List<Tuple<int, string, int, decimal>>();
    }

    public static void GestionarInventario(List<Tuple<int, string, int, decimal>> inventario)
    {
        int opcion;
        do
        {
            Console.WriteLine("\n--- Menú de Inventario ---");
            Console.WriteLine("1. Agregar producto");
            Console.WriteLine("2. Eliminar producto");
            Console.WriteLine("3. Modificar producto");
            Console.WriteLine("4. Consultar producto");
            Console.WriteLine("5. Mostrar todos los productos");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    AgregarProducto(inventario);
                    break;
                case 2:
                    EliminarProducto(inventario);
                    break;
                case 3:
                    ModificarProducto(inventario);
                    break;
                case 4:
                    ConsultarProducto(inventario);
                    break;
                case 5:
                    MostrarTodos(inventario);
                    break;
            }
        } while (opcion != 6);
    }

    public static void AgregarProducto(List<Tuple<int, string, int, decimal>> inventario)
    {
        Console.Write("Código del producto: ");
        int codigo = int.Parse(Console.ReadLine());

        Console.Write("Nombre del producto: ");
        string nombre = Console.ReadLine();

        Console.Write("Cantidad: ");
        int cantidad = int.Parse(Console.ReadLine());

        Console.Write("Precio: ");
        decimal precio = decimal.Parse(Console.ReadLine());

        inventario.Add(new Tuple<int, string, int, decimal>(codigo, nombre, cantidad, precio));
        Console.WriteLine("Producto agregado.");
    }

    public static void EliminarProducto(List<Tuple<int, string, int, decimal>> inventario)
    {
        Console.Write("Ingrese el código del producto a eliminar: ");
        int codigo = int.Parse(Console.ReadLine());

        var producto = inventario.Find(p => p.Item1 == codigo);

        if (producto != null)
        {
            inventario.Remove(producto);
            Console.WriteLine("Producto eliminado.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    public static void ModificarProducto(List<Tuple<int, string, int, decimal>> inventario)
    {
        Console.Write("Ingrese el código del producto a modificar: ");
        int codigo = int.Parse(Console.ReadLine());

        var producto = inventario.Find(p => p.Item1 == codigo);

        if (producto != null)
        {
            inventario.Remove(producto);

            Console.Write("Nuevo nombre: ");
            string nuevoNombre = Console.ReadLine();

            Console.Write("Nueva cantidad: ");
            int nuevaCantidad = int.Parse(Console.ReadLine());

            Console.Write("Nuevo precio: ");
            decimal nuevoPrecio = decimal.Parse(Console.ReadLine());

            inventario.Add(new Tuple<int, string, int, decimal>(codigo, nuevoNombre, nuevaCantidad, nuevoPrecio));
            Console.WriteLine("Producto modificado.");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    public static void ConsultarProducto(List<Tuple<int, string, int, decimal>> inventario)
    {
        Console.Write("Ingrese el código del producto: ");
        int codigo = int.Parse(Console.ReadLine());

        var producto = inventario.Find(p => p.Item1 == codigo);

        if (producto != null)
        {
            Console.WriteLine($"Código: {producto.Item1}, Nombre: {producto.Item2}, Cantidad: {producto.Item3}, Precio: {producto.Item4}");
        }
        else
        {
            Console.WriteLine("Producto no encontrado.");
        }
    }

    public static void MostrarTodos(List<Tuple<int, string, int, decimal>> inventario)
    {
        foreach (var producto in inventario)
        {
            Console.WriteLine($"Código: {producto.Item1}, Nombre: {producto.Item2}, Cantidad: {producto.Item3}, Precio: {producto.Item4}");
        }
    }
}
