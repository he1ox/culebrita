using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita.SnakeOOP
{
    internal class SnakeLineal : ICola
    {
        internal int Fin { get; set; }
        internal int Frente { get; set; }
        internal int QueueSize { get; set; }
        internal Point[] ListaCola { get; set; }
        internal int Size { get; set; }
    
        public SnakeLineal(int QueueSize = 40)
        {
            Frente = 0;
            Fin = -1;
            this.QueueSize = QueueSize;
            ListaCola = new Point[this.QueueSize];
        }

        public void EnQueue(Point point)
        {
            if (ColaLlena()) throw new Exception("La cola está llena");
            ListaCola[++Fin] = point;
            Size++;
        }

        public Point DeQueue()
        {
            if (ColaVacia()) throw new Exception("La cola está vacía");
            Point aux = ListaCola[Frente];
            ListaCola[Frente] = Point.Empty;
            Frente++;
            Size--;
            return aux;

            //return ListaCola[Frente++];
        }

        public void BorrarCola()
        {
            Frente = 0;
            Fin = -1;
        }
        public Point FrenteCola()
        {
            if (ColaVacia()) throw new Exception("La cola está vacía");
            return ListaCola[Frente];
        }
        public bool ColaVacia() => Frente > Fin;


        public bool ColaLlena() => Fin == this.QueueSize - 1;


        public Point UltimoElemento()
        {
            if (ColaVacia()) throw new Exception("La cola está vacía");
            return ListaCola[Fin];
        }

        public Point[] GetElementos() => ListaCola;


        public int GetSize() => Size;

    }
}
