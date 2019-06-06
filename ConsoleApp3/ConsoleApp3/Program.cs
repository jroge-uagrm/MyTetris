using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Progra_Grafica_3D
{
    class Program
    {
        static void Main(string[] args)
        {
            GameWindow ventana = new GameWindow(500, 500);
            Juego nuevoJuego = new Juego(ventana);
        }
    }
}
