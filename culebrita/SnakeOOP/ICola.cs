using System;
using System.Collections.Generic;
using System.Text;

namespace culebrita.SnakeOOP
{
    internal interface ICola
    {
        /// <summary>
        /// Este método se encarga de insertar un elemento a la cola
        /// </summary>
        /// <param name="elemento">Objeto a encolar</param>
        void EnQueue(Object elemento);

        /// <summary>
        /// Este método se encarga de eliminar el primer elemento en la cola, y lo devuelve. 
        /// </summary>
        /// <returns>Objeto</returns>
        object DeQueue();

        /// <summary>
        /// Este método resetea la cola.
        /// </summary>
        void BorrarCola();

        /// <summary>
        /// Este método devuelve el primer elemento en haber entrado a la cola.
        /// </summary>
        /// <returns>Objeto</returns>
        object FrenteCola();
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
    }
}
