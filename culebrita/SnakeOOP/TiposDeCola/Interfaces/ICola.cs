using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace culebrita.SnakeOOP
{
    internal interface ICola
    {
        /// <summary>
        /// Este método se encarga de insertar un elemento a la cola
        /// </summary>
        /// <param name="elemento">Objeto a encolar</param>
        void EnQueue(Point elemento);

        /// <summary>
        /// Este método se encarga de eliminar el primer elemento en la cola, y lo devuelve. 
        /// </summary>
        /// <returns>Objeto</returns>
        Point DeQueue();

        /// <summary>
        /// Este método resetea la cola.
        /// </summary>
        void BorrarCola();

        /// <summary>
        /// Este método devuelve el primer elemento en haber entrado a la cola.
        /// </summary>
        /// <returns>Objeto</returns>
        Point FrenteCola();
        /// <summary>
        /// Verifica si la colá esta vacía.
        /// </summary>
        /// <returns>True</returns>
        bool ColaVacia();

        /// <summary>
        /// Verifica si la cola está llena.
        /// </summary>
        /// <returns>True</returns>
        bool ColaLlena();

        /// <summary>
        /// Devuelve todos los elementos contenidos en la cola
        /// </summary>
        /// <returns>Devuelve todos los elementos de la cola</returns>
        Point[] GetElementos();

        /// <summary>
        /// Devuelve el elemento al final de la cola
        /// </summary>
        /// <returns>Devuelve el elemento al final de la cola</returns>
        Point UltimoElemento();

        /// <summary>
        /// Devuelve el tamaño de la cola
        /// </summary>
        /// <returns>Devuelve el tamaño de la cola</returns>
        int GetSize();
    }
}
