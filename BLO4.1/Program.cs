using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLO4
{
    static class Program
    {
        static void Main()
        {
            OperacionesBBDD db = new OperacionesBBDD();
            db.Open();
            db.AñadirJugador("Pedro", 24, 15);
            db.AñadirJugador("Xumi", 30, 20);
            db.AñadirJugador("Jose", 19, 20);
            Console.WriteLine("Suma de los puntos de mayores de 20 años: {0}", db.Puntos(0));
            db.Close();
        }
    }
}
