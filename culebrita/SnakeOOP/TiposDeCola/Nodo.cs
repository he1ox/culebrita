using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita.SnakeOOP
{
    internal class Nodo
    {
        public Point Dato { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(Point Dato)
        {
            this.Dato = Dato;
            this.Siguiente = null;
        }
    }
}
