using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita.SnakeOOP
{
    internal class SnakeCircular : ICola
    {
        protected int Fin { get; set; }
        protected int QueueSize { get; set; }
        protected int Frente { get; set; }
        protected int Size { get; set; }
        protected Point[] ListaCola { get; set; }

        private int Siguiente(int r) => (r + 1) % QueueSize;

        public SnakeCircular(int QueueSize = 40)
        {
            Frente = 0;
            Fin = -1;
            ListaCola = new Point[this.QueueSize = QueueSize];
        }
        public void EnQueue(Point elemento)
        {
            if (ColaLlena()) throw new Exception("La cola se encuentra llena | OVERFLOW");
            Fin = Siguiente(Fin);
            ListaCola[Fin] = elemento;
            Size++;
        }

        public Point DeQueue()
        {
            if (ColaVacia()) throw new Exception("La cola se encuentra vacía | UNDERFLOW");
            Point elemento = ListaCola[Frente];
            Frente = Siguiente(Frente);
            Size--;
            return elemento;
        }

        public Point FrenteCola()
        {
            if (ColaVacia()) throw new Exception("La cola está vacía");
            return ListaCola[Frente];
        }

        public void BorrarCola()
        {
            Fin = QueueSize - 1;
            Frente = 0;
        }

        public bool ColaVacia() => Frente == Siguiente(Fin);

        public bool ColaLlena() => Fin == Siguiente(Siguiente(Fin));

        public Point UltimoElemento()
        {
            if (ColaVacia()) throw new Exception("La cola está vacía");
            return ListaCola[Fin];
        }

        public Point[] GetElementos() => ListaCola;

        public int GetSize() => Size;

    }

}
