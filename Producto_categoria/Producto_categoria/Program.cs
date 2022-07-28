using System;
using System.Collections.Generic;
using System.Linq;

namespace ClaseProducto
{
    class Program
    {
        static void Main(string[] args)
        {
            //Crear clase producto y clase categoria
            //(Pueden ser valores fijos)
            //Luego decir el precio promedio(avg), la cantidad de productos, Maximo y ninimo por cada categoria  

            List<Productos> ObjProducto = new List<Productos>();

            ObjProducto.Add(new Productos { Nombre = "Pistola", Precio = 2323.41, Cantidad = 3, NombreCategoria = "Componentes diversos " });
            ObjProducto.Add(new Productos { Nombre = "Lubricante", Precio = 22222.65, Cantidad = 73, NombreCategoria = "Componentes diversos " });
            ObjProducto.Add(new Productos { Nombre = "Amortiguadores", Precio = 1330000, Cantidad = 22, NombreCategoria = "Componentes diversos " });
            ObjProducto.Add(new Productos { Nombre = "Boquillas", Precio = 100040, Cantidad = 10, NombreCategoria = "Componentes diversos " });
            ObjProducto.Add(new Productos { Nombre = "Casquillos", Precio = 32322.65, Cantidad = 4, NombreCategoria = "Componentes diversos " });

            ObjProducto.Add(new Productos { Nombre = "Escalera Mediana", Precio = 99.99, Cantidad = 200, NombreCategoria = "Escalera" });
            ObjProducto.Add(new Productos { Nombre = "Escalera Grande", Precio = 80.24, Cantidad = 2, NombreCategoria = "Escalera" });

            ObjProducto.Add(new Productos { Nombre = "Esmaltes", Precio = 544.60, Cantidad = 100, NombreCategoria = "Pinturas" });
            ObjProducto.Add(new Productos { Nombre = "Pintura Azul", Precio = 33.22, Cantidad = 30, NombreCategoria = "Pinturas" });
            ObjProducto.Add(new Productos { Nombre = "Pintura Roja", Precio = 55.99, Cantidad = 53, NombreCategoria = "Pinturas" });
            ObjProducto.Add(new Productos { Nombre = "Pintura Negra", Precio = 100.99, Cantidad = 999999, NombreCategoria = "Pinturas" });

            var query = ObjProducto.GroupBy(t => t.NombreCategoria)
                .Select(t => new
                {
                    NombreCategoria = t.Key,
                    //cantidad de productos
                    cantidad = t.Sum(ta => ta.Cantidad),
                    //la cantidad de productos Minimo
                    min = t.Min(ta => ta.Cantidad),
                    //la cantidad de productos Maximo
                    max = t.Max(ta => ta.Cantidad),
                    //precio promedio(avg)
                    avg = Math.Round(t.Average(ta => ta.Precio), 2)
                }).ToList();

            Console.WriteLine("\t\t\n---Productos Ordenados por categoria---\n");
            query.ForEach(
            row => Console.WriteLine($"Categoria: {row.NombreCategoria}, Cantidad: {row.cantidad}," +
            $" min: {row.min}, max: {row.max}, avg: {row.avg}"));

            Console.Read();
        }
    }

    internal class Productos
    {
        public object NombreCategoria { get; internal set; }
        public string Nombre { get; internal set; }
        public double Precio { get; internal set; }
        public int Cantidad { get; internal set; }
    }
}