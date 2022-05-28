using System;
using System.Collections.Generic;
using System.Text;

namespace culebrita.SnakeOOP
{
    internal class ColasFabrica
    {
        /// <summary>
        /// Devuelve el tipo de cola solicitada
        /// 1. arreglo lineal
        /// 2. lista enlazada
        /// 3. arreglo circular
        /// 4. array list
        /// </summary>
        /// <param name="TipoDeCola"></param>
        /// <returns>ICola</returns>
        public ICola GetCola(string TipoDeCola)
        {
            switch (TipoDeCola.ToLower())
            {
                case "arreglo lineal":
                    return new SnakeLineal(10000);
                case "lista enlazada":
                    return new SnakeEnlazada();
                case "arreglo circular":
                    return new SnakeCircular(10000);
                case "array list":
                    return new SnakeArrayList();
                default:
                    return new SnakeLineal(10000);
            }
        }
    }
}
