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
                UltimoNodo = nodoEntrante;
            }
            

        }

        public Point DeQueue()
        {
            throw new NotImplementedException();
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

        public bool ColaVacia()
        {
            return PrimerNodo == null;
        }

        public bool ColaLlena()
        {
            throw new NotImplementedException();
        }

        public Point[] GetElementos()
        {
            throw new NotImplementedException();
        }

        public Point UltimoElemento()
        {
            if (ColaVacia()) throw new Exception("La cola está vacía");
            return UltimoNodo.Dato;
        }

        public int GetSize()
        {
            return Size;
        }
    }
}
