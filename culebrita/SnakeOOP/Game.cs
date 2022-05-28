using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace culebrita.SnakeOOP
{
    internal class Game
    {

        private string GameName { get;set;}
        private int ScreenHeight { get; set; }
        private int ScreenWidth { get; set; }
        private int Punteo { get; set; }
        private int Velocidad { get; set; }
        public string NombreJugador { get; set; }
        public ICola TipoDeCola { get; set; }
        private int TopeVelocidad { get; set; }
        private SoundPlayer player { get; set; }
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
            this.Velocidad = 0; // 100 milisegundos = 0.1s
            this.TopeVelocidad = 50; // 50 Ms
            TipoDeCola = new SnakeArrayList();
        }

        /// <summary>
        /// Corre el programa
        /// </summary>
        public void Run()
        {
            //SoundPlayer player = new SoundPlayer();
            //player.SoundLocation = "C:\\Sonidos\\FirstBlood.wav";
            //player.Load();

            var foodPosition = Point.Empty; 
            var snakeLength = 5;
            var currentPosition = new Point(0,9);
            var direccion = Direccion.DERECHA;
            this.Velocidad = 100;

            TipoDeCola.EnQueue(currentPosition);
            DibujaPantalla();
            MuestraPunteo();

            while(MoveSnake(TipoDeCola, currentPosition, snakeLength))
            {
                Thread.Sleep(this.Velocidad);
                direccion = GetDireccion(direccion);
                currentPosition = ObtenerSiguienteDireccion(direccion, currentPosition);

                if (currentPosition.Equals(foodPosition))
                {
                    foodPosition = Point.Empty;
                    snakeLength++;
                    this.Punteo += 10;

                    if (Velocidad > TopeVelocidad)
                    {
                        this.Velocidad -= 5;
                    }
                    MuestraPunteo();

                    //NO asincrono
                    //Console.Beep(1000,100);
                    //Asincrono
                    //Task.Run(() => Console.Beep(1000,100));
                    ReproduceSonidos(Punteo);
                }

                if (foodPosition == Point.Empty)
                {
                    foodPosition = ShowFood(TipoDeCola);
                }

            }

            ReproduceSonidos();
            Console.ResetColor();
            Console.SetCursorPosition(this.ScreenWidth / 2 - 4, this.ScreenHeight / 2);
            Console.Write($"Haz fallado. \n\t\tTu máximo punteo fue: {this.Punteo.ToString("00000000")}");
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
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(1, 0);

            Console.Write($"Punteo: {this.Punteo.ToString("00000000")}");


            Console.SetCursorPosition(20, 0);
            Console.Write("Jugador: " + NombreJugador);
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

        /// <summary>
        /// Se encarga de movilizar el snake a la posición requerida
        /// </summary>
        /// <param name="snake"></param>
        /// <param name="targetPosition"></param>
        /// <param name="snakeLength"></param>
        /// <returns>Devuelve true si el movimiento es posible, false si no</returns>
        bool MoveSnake(ICola snake, Point targetPosition, int snakeLength)
        {
            var random = new Random();

            var lastPoint = snake.UltimoElemento();

            if (lastPoint.Equals(targetPosition)) return true;

            if (snake.GetElementos().Any(x => x.Equals(targetPosition))) return false;

            if (targetPosition.X < 0 || targetPosition.X >= this.ScreenWidth || targetPosition.Y < 0
                || targetPosition.Y >= this.ScreenHeight)
            {
                return false;
            };

            //Snake RGB
            Console.BackgroundColor = (System.ConsoleColor) random.Next(1,11);

            Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
            Console.Write(" ");

            snake.EnQueue(targetPosition);

            Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(targetPosition.X + 1, targetPosition.Y + 1);
            Console.Write(" ");

            //Quitamos la cola
            if (snake.GetSize() > snakeLength)
            {
                var removePoint = (Point) snake.DeQueue();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
                Console.Write(" ");
            }

            return true;
        }

        /// <summary>
        /// Recibe como argumento la cola que representa el snake, calcula de mandera random
        /// un punto con las coordenadas (x,y) en el que mostrar la comida, pero antes verifica que este
        /// punto no esté actualmente ocupado por la queue del snake, y que tenga un minimo de espacio con la 
        /// cabeza de la serpiente
        /// </summary>
        /// <returns>Devuelve la nueva posición para la comida</returns>
        Point ShowFood(ICola snake)
        {
            var foodPoint = Point.Empty;
            var snakeHead = snake.UltimoElemento(); ;
            var random = new Random();

            do
            {
                //Quitamos un -1 por la linea blanca que rodea la consola
                var x = random.Next(0, this.ScreenWidth - 1);
                var y = random.Next(0, this.ScreenHeight - 1);
                if (snake.GetElementos().All(p => p.X != x || p.Y != y) && Math.Abs(x - snakeHead.X) + Math.Abs(y - snakeHead.Y) > 8)
                {
                    foodPoint = new Point(x, y);
                }

            } while (foodPoint == Point.Empty);


            //Genera un color aleatorio y lo castea el enum ConsoleColor, omite el 0 porque es negro
            Console.BackgroundColor = (System.ConsoleColor) random.Next(1,16);

            Console.SetCursorPosition(foodPoint.X + 1, foodPoint.Y + 1);
            Console.Write(" ");

            return foodPoint;
        }

        void ReproduceSonidos(int punteo)
        {
            player = new SoundPlayer();

            if (punteo == 10)
            {
                player.SoundLocation = "C:\\Sonidos\\FirstBlood.wav";
                player.Load();
                player.Play();
            }else if(punteo == 30)
            {
                player.SoundLocation = "C:\\Sonidos\\KillingSpree.wav";
                player.Load();
                player.Play();
            }else if(punteo == 60)
            {
                player.SoundLocation = "C:\\Sonidos\\MegaKill.wav";
                player.Load();
                player.Play();
            } else if(punteo == 90)
            {
                player.SoundLocation = "C:\\Sonidos\\MonsterKill.wav";
                player.Load();
                player.Play();
            }
            else
            {
                Task.Run(() => Console.Beep(1000, 200));
            }
        }

        void ReproduceSonidos()
        {
            player = new SoundPlayer();
            player.SoundLocation = "C:\\Sonidos\\NO.wav";
            player.Load();
            player.Play();
        }

    }
}
