using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

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
            this.Velocidad = 0;
        }


        public void run()
        {
            DibujaPantalla();

            //Evito que se acabe la ejecución rápido
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

        bool MoveSnake(Queue<Point> snake, Point targetPosition, int snakeLenght)
        {

        }
        {

        }
    }
}
