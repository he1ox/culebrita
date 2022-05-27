using System;
using System.Collections.Generic;
using System.Text;

namespace culebrita.SnakeOOP
{
    internal class SnakeCircular : ICola
    {
        protected int Fin { get; set; }
        protected int QueueSize { get; set; }
        protected int Frente { get; set; }
        protected int Size { get; set; }
        protected object[] ListaCola { get; set; }

        private int Siguiente(int r)
        {
            return (r + 1) % QueueSize;
        }

        public SnakeCircular(int QueueSize = 40)
        {
            Frente = 0;
            Fin = -1;
            ListaCola = new object[this.QueueSize = QueueSize];
        }
        public void EnQueue(object elemento)
        {
            if (ColaLlena()) throw new Exception("La cola se encuentra llena | OVERFLOW");
            Fin = Siguiente(Fin);
            ListaCola[Fin] = elemento;
            Size++;
        }

        public object DeQueue()
        {
            if (ColaVacia()) throw new Exception("La cola se encuentra vacía | UNDERFLOW");
            object elemento = ListaCola[Frente];
            Frente = Siguiente(Frente);
            Size--;
            return elemento;
        }

        public object FrenteCola()
        {
            if (ColaVacia()) throw new Exception("La cola está vacía");
            return ListaCola[Frente];
        }

        public void BorrarCola()
        {
            Fin = QueueSize - 1;
            Frente = 0;
        }


        public bool ColaVacia()
        {
            return Frente == Siguiente(Fin);
        }

        public bool ColaLlena()
        {
            return Fin == Siguiente(Siguiente(Fin));
        }

    }
}
