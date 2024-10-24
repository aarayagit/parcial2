using Parcial2.Enums;
using Parcial2.Modelos;

namespace Parcial2.Modelos
{
   abstract class Menu
   {
        private static List<Action> Acciones = new()
        {
           AgregarProducto,
           EliminarProducto,
           MostrarProducto,
           ActualizarProducto,
          
           CalcularCostoTotal,
        };
            public static void MostrarMenu()
            {
            Sistema.CargarDatos();
                bool salir = false;

                while (!salir)
                {
                    Console.WriteLine("\n --- Menú de panaderia ---\n" +
                        "1. Agregar producto.\n" +
                        "2. Eliminar Producto.\n" +
                        "3. Mostrar todos los productos.\n" +
                        "4. Actualizar producto\n" +
                        "5. Calcular costo tot\n"+
                        "6. Guardar y Salir\n");
                    Console.Write("Seleccione una opción: ");
                    string opcion = Console.ReadLine();
                    if (int.TryParse(opcion, out int indice) && indice >= 1 && indice <= Acciones.Count + 1)
                    {
                        if (indice == Acciones.Count + 1)
                        {
                            salir = true;
                        }
                        else
                        {
                            Acciones[indice - 1].Invoke();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\nOpción no válida.");
                    }
                }
            }

            static void AgregarProducto()
            {
                Console.Write("Ingrese el nombre del producto: ");
                string nombre = Console.ReadLine();

                Console.Write("Ingrese el precio: ");
                var precio = double.Parse(Console.ReadLine());

                Console.WriteLine("Seleccione su categoria: ");
                foreach (var c in Enum.GetValues(typeof(Categoria)))
                {
                    Console.WriteLine($"{(int)c+ 1}. {c}");
                }
                int categoria= int.Parse(Console.ReadLine());
                Categoria CatElegida= (Categoria)categoria;
                
                Console.Write("Ingrese el stock : ");
                var stock = int.Parse(Console.ReadLine());
                Producto nuevoproducto = new Producto(nombre, precio,CatElegida, stock);

                Sistema.AgregarProducto(nuevoproducto);
            }
            static void MostrarProducto() => Sistema.MostrarProductos();
            static void ActualizarProducto()
            {
                Console.Write($"Ingrese el nombre del producto a modificar: ");
                string nombre = Console.ReadLine();

                Sistema.ActualizarProducto(nombre);
            }
            static void EliminarProducto()
            {
                Console.Write($"Ingrese el nombre producto que desee eliminar: ");
                string nombre = Console.ReadLine();

                Sistema.EliminarProducto(nombre);
            }
        static void CalcularCostoTotal() => Sistema.CalcularCostoTotal();

    }
 }

