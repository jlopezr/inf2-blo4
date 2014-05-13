using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLO4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            GestorRegalos db = new GestorRegalos();
            db.Abrir();

            Console.WriteLine("Nombre:");
            String nombre = Console.ReadLine();
            Console.WriteLine("Destinatario:");
            String destinatario = Console.ReadLine();
            Console.WriteLine("Precio:");
            double precio = Convert.ToDouble(Console.ReadLine());
            double total = db.InsertarRegalo(nombre, destinatario, precio);
            Console.WriteLine("El total de los regalos de {0} es {1}", destinatario, total);
            db.Cerrar();
        }
    }
}
