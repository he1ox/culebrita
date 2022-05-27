﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace culebrita.SnakeOOP
{
    internal class Game
    {

        private string GameName { get;set;}
        private int ScreenHeight { get; set; }
        private int ScreenWidth { get; set; }
        private int Punteo { get; set; }
        private int Velocidad { get; set; }


        enum Direccion
        {
            ARRIBA,
            ABAJO,
            IZQUIERDA,
            DERECHA
        }

        public Game()
        {
            this.GameName = "Snake Game";
            this.ScreenHeight = 20;
            this.ScreenWidth = 60;
            this.Punteo = 0;
            this.Velocidad = 100; // 100 milisegundos = 0.1s
        }


        public void run()
        {
            var foodPosition = Point.Empty; 
            SnakeLineal snake = new SnakeLineal(1000000);
            var snakeLength = 3;
            var currentPosition = new Point(0,9);
            var direccion = Direccion.DERECHA;

            snake.EnQueue(currentPosition);
            DibujaPantalla();

            while(moveSnake(snake, currentPosition, snakeLength))
            {
                Thread.Sleep(this.Velocidad);
                direccion = GetDireccion(direccion);
                currentPosition = ObtenerSiguienteDireccion(direccion, currentPosition);
            }

            Console.ResetColor();
            Console.SetCursorPosition(this.ScreenWidth / 2 - 4, this.ScreenHeight / 2);
            Console.Write("Haz fallado.");
            Thread.Sleep(2000);
            Console.ReadKey();
        }


        /// <summary>
        /// Este método crea el tablero o la pantalla en dónde se movera el Snake.
        /// Establece primero todo el fondo blanco, y posteriormente pinta el fondo negro, dejando un marco de color blanco.
        /// </summary>
        void DibujaPantalla()
        {
            Console.Title = this.GameName;

            Console.WindowHeight = this.ScreenHeight + 2;
            Console.WindowWidth = this.ScreenWidth + 2;

            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.White;

            Console.Clear();

            Console.BackgroundColor = ConsoleColor.Black;
            for (int row = 0; row < this.ScreenHeight; row++)
            {
                for (int col = 0; col < this.ScreenWidth; col++)
                {
                    Console.SetCursorPosition(col + 1, row + 1);
                    Console.Write(" ");
                }
            }


            MuestraPunteo();
        }

        /// <summary>
        /// Muestra el punteo en pantalla actual del juego
        /// </summary>
        void MuestraPunteo()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(1, 0);

            Console.Write($"Punteo: {this.Punteo.ToString("00000000")}");
        }

        /// <summary>
        /// Verifica si hemos pulsado alguna tecla, y define la dirección en la que se moverá la serpiente
        /// </summary>
        /// <param name="direccionActual">Direccion en la que se mueve la serpiente</param>
        /// <returns>Dirección en la que serpiente se moverá</returns>
        Direccion GetDireccion(Direccion direccionActual)
        {
            if (!Console.KeyAvailable) return direccionActual;

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.DownArrow:
                    if (direccionActual != Direccion.ARRIBA)
                        direccionActual = Direccion.ABAJO;
                    break;
                case ConsoleKey.LeftArrow:
                    if (direccionActual != Direccion.DERECHA)
                        direccionActual = Direccion.IZQUIERDA;
                    break;
                case ConsoleKey.RightArrow:
                    if (direccionActual != Direccion.IZQUIERDA)
                        direccionActual = Direccion.DERECHA;
                    break;
                case ConsoleKey.UpArrow:
                    if (direccionActual != Direccion.ABAJO)
                        direccionActual = Direccion.ARRIBA;
                    break;
            }

            return direccionActual;
        }


        /// <summary>
        /// Retorna la nueva posición en la que deberá moverse el snake
        /// </summary>
        /// <param name="direccion">Direccion en la que el snake debe moverse</param>
        /// <param name="posicionActual">Posición actual del snake</param>
        /// <returns></returns>
        Point ObtenerSiguienteDireccion(Direccion direccion, Point posicionActual)
        {
            Point siguientePosicion = new Point(posicionActual.X, posicionActual.Y);

            switch (direccion)
            {
                case Direccion.ARRIBA:
                    siguientePosicion.Y--;
                    break;
                case Direccion.IZQUIERDA:
                    siguientePosicion.X--;
                    break;
                case Direccion.ABAJO:
                    siguientePosicion.Y++;
                    break;
                case Direccion.DERECHA:
                    siguientePosicion.X++;
                    break;
            }

            return siguientePosicion;
        }

        bool moveSnake(SnakeLineal snake, Point targetPosition, int snakeLength)
        {
            var lastPoint = (Point) snake.UltimoElemento();
            if (lastPoint.Equals(targetPosition)) return true;

            if (snake.ToString().Any(x => x.Equals(targetPosition))) return true;

            if (targetPosition.X < 0 || targetPosition.X >= this.ScreenWidth || targetPosition.Y < 0
                || targetPosition.Y >= this.ScreenHeight)
            {
                return false;
            };


            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
            Console.Write(" ");

            snake.EnQueue(targetPosition);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(targetPosition.X + 1, targetPosition.Y + 1);
            Console.Write(" ");

            //Quitamos la cola
            if (snake.Size > snakeLength)
            {
                var removePoint = (Point) snake.DeQueue();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
                Console.Write(" ");
            }

            return true;
        }
    }
}
