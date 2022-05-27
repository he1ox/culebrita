using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace culebrita.SnakeOOP
{
    internal class SnakeLineal : ICola
    {
        internal int Fin { get; set; }
        internal int Frente { get; set; }
        internal int QueueSize { get; set; }
        internal object[] ListaCola { get; set; }
        internal int Size { get; set; }
    
        public SnakeLineal(int QueueSize = 40)
        {
            Frente = 0;
            Fin = -1;
            this.QueueSize = QueueSize;
            ListaCola = new object[this.QueueSize];
        }

        public void EnQueue(object point)
        {
            if (ColaLlena()) throw new Exception("La cola está llena");
            ListaCola[++Fin] = point;
            Size++;
        }

        public object DeQueue()
        {
            if (ColaVacia()) throw new Exception("La cola está vacía");
            //object aux = ListaCola[Frente];
            //ListaCola[Frente] = null;
            //Frente++;
            //return aux;

            Size--;
            return ListaCola[Frente++];
        }

        public void BorrarCola()
        {
            Frente = 0;
            Fin = -1;
        }
        public object FrenteCola()
        {
            if (ColaVacia()) throw new Exception("La cola está vacía");
            return ListaCola[Frente];
        }
        public bool ColaVacia()
        {
            return Frente > Fin;
        }

        public bool ColaLlena()
        {
            return Fin == this.QueueSize - 1;
        }

        public object UltimoElemento()
        {
            if (ColaVacia()) throw new Exception("La cola está vacía");

            return ListaCola[Fin];
        }
    }
}
