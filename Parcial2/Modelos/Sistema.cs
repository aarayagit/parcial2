using Parcial2.Enums;
using System.Net.Http.Headers;

namespace Parcial2.Modelos
{
    static public class Sistema
    {
        static List<Producto> Productos { get; set; } = new List<Producto>();
        static string ArchivoProductos = "productos.txt";

        static public void AgregarProducto(Producto producto)
        {
            Productos.Add(producto);
            Console.WriteLine($"Misión {producto.Nombre} ha sido agregada.");
        }
        static public void MostrarProductos()
        {
            if (Productos.Count == 0)
            {
                Console.WriteLine("No existen productos.");
            }
            else
            {
                foreach (var producto in Productos)
                {
                    Console.WriteLine(producto);
                }
            }
        }
        static public void ActualizarProducto(string nombre)
        {
            var product = Productos.Find(p => p.Nombre == nombre);
            if (product == null)
            {
                Console.WriteLine($"Producto no encontrado.");
            }
            else
            {
                Console.Write($"Ingrese el nuevo precio del producto: ");
                var precio = double.Parse(Console.ReadLine());
                Console.Write($"Ingrese el nuevo stock del videojuego: ");
                var stock = int.Parse(Console.ReadLine());
                Productos.Remove(product);
                Producto nuevoproducto = new Producto(nombre, precio, product.Categoria, stock);
                Productos.Add(nuevoproducto);
                Console.WriteLine($"Producto: {nombre} actualizado!");
                GuardarDatos();
            }
        }
        static public void EliminarProducto(string nombre)
        {
            var product = Productos.Find(p => p.Nombre == nombre);
            if (product == null)
            {
                Console.WriteLine($"Videojuego no encontrado. ");
            }
            else
            {
                Productos.Remove(product);
                GuardarDatos();
                Console.WriteLine($"Se elimino el siguiente producto: {nombre} ");
            }
        }
        static public void GuardarProducto(Producto producto)
        {
            using StreamWriter writer = new(ArchivoProductos, true);
            writer.WriteLine(producto);
        }
        static public void GuardarDatos()
        {
            using StreamWriter writer = new(ArchivoProductos);
            foreach (var p in Productos)
            {
                writer.WriteLine(p);
            }
        }
        static public void CargarDatos()
        {
            if (File.Exists(ArchivoProductos))
            {
                foreach (var linea in File.ReadAllLines(ArchivoProductos))
                {
                    string[] p = linea.Split(",");
                    Producto pr = null;

                    string nombre = p[0];
                    double precio = double.Parse(p[1]);
                    Categoria categoria = (Categoria)Enum.Parse(typeof(Categoria), p[2]);
                    int stock = int.Parse(p[3]);
                    pr = new Producto(nombre, precio, categoria, stock);
                    Productos.Add(pr);
                    pr = null;

                }
            }
        }
        static public void CalcularCostoTotal()
        {
            double tot = 0;
            foreach (var prod in Productos)
            {
                tot = tot + prod.Precio;
            }
            Console.WriteLine($"El total acumulado del inventario es: ${tot}");
        }
      
    }
}
