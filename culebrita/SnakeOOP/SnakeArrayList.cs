using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace culebrita.SnakeOOP
{

    internal class SnakeArrayList : ICola
    {
        /*
        EL MENOS EFICIENTE!!!!!
        Cuando inicializamos un ArrayList, en un inició se asignara espacio en memoria para 4 elementos,
        cuando agreguemos un 5to elemento al ArrayList, este redimensionará hasta el doble de su espacio,
        es decir, con este 5to elemento más, ahora el ArrayList tiene espacio en memoria para 8 elementos.
        Así sucesivamente 4,8,16,32, 2 a la n potencia
        */
        internal int Fin { get; set; }
        internal int Frente { get; set; }
        protected ArrayList ListaCola { get; set; }

        public SnakeArrayList()
        {
            Frente = 0;
            Fin = -1;
            ListaCola = new ArrayList();
        }

        public void EnQueue(object point)
        {
            if (ColaLlena()) throw new Exception("La cola está llena");
            ++Fin;
            ListaCola.Add(point);
        }

        public object DeQueue()
        {
            if (ColaVacia()) throw new Exception("La cola está vacía");
            object aux = ListaCola[Frente];
            ListaCola.RemoveAt(Frente);
            Fin--;
            return aux;
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
            return ListaCola.Count == 0;
        }

        public bool ColaLlena()
        {
            //Ya que crece exponencialmente en base 2, el máximo número de elementos es int.MaxValue -> 2^31
            return ListaCola.Count == int.MaxValue;
        }

        public int QueueSize()
        {
            return ListaCola.Capacity;
        }

    }
}
