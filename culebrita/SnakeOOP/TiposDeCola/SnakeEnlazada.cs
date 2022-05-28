using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita.SnakeOOP
{
    internal class SnakeEnlazada : ICola
    {
        public Nodo PrimerNodo { get; set; }
        public Nodo UltimoNodo { get; set; }
        public int Size;
        public SnakeEnlazada()
        {
            PrimerNodo = null;
            UltimoNodo = null;
            Size = 0;
        }

        public void EnQueue(Point elemento)
        {
            Nodo nodoEntrante = new Nodo(elemento);
            if (ColaVacia())
            {
                PrimerNodo = nodoEntrante;
            }
            else
            {
                UltimoNodo.Siguiente = nodoEntrante;
            }

            UltimoNodo = nodoEntrante;
            Size++;

        }

        public Point DeQueue()
        {
            if (ColaVacia()) throw new Exception("La cola está vacía");

            Point valorTemporal = PrimerNodo.Dato;
            PrimerNodo = PrimerNodo.Siguiente;
            Size--;
            return valorTemporal;
        }

        public void BorrarCola()
        {
            throw new NotImplementedException();
        }

        public Point FrenteCola()
        {
            if (ColaVacia()) throw new Exception("La cola está vacía");

            return PrimerNodo.Dato;
        }

        public bool ColaVacia() => PrimerNodo == null;


        public bool ColaLlena()
        {
            throw new NotImplementedException();
        }

        public Point[] GetElementos()
        {
            Point[] elementos = new Point[1000];
            int n = 0;
            Nodo comienzo = PrimerNodo;

            if (!ColaVacia())
            {
                //n = 1;
                while( comienzo != UltimoNodo)
                {
                    comienzo = comienzo.Siguiente;
                    elementos[n++] = Point.Empty;
                }
            }

            return elementos;
        }

        public Point UltimoElemento()
        {
            if (ColaVacia()) throw new Exception("La cola está vacía");
            return UltimoNodo.Dato;
        }

        public int GetSize() => Size;

    }
}
