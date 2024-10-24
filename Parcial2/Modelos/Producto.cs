using Parcial2.Enums;

namespace Parcial2.Modelos
{
    public class Producto
    {
        public string Nombre { get;private set; }
        public double Precio { get; private set; }
        public Categoria Categoria { get; private set; } = new ();
        public int Stock { get; private set; }

        public Producto(string nombre,double precio,Categoria categoria,int stock)
        {
            Nombre = nombre;
            Precio = precio;
            Categoria = categoria;
            Stock=stock;
        }
        public override string ToString()
        {
            return $"{Nombre},{Precio}, {GetType().Name}, {Stock}";
        }
    }
}
