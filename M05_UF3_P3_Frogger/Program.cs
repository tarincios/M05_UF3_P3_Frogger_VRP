using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace M05_UF3_P3_Frogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            // Crear objetos necesarios
            TimeManager.timer.Start();

            List<Lane> lineas = new List<Lane>();


            // Crear carriles con diferentes configuraciones
            List<ConsoleColor> colorsCars = new List<ConsoleColor>(Utils.colorsCars);
            List<ConsoleColor> colorsLogs = new List<ConsoleColor>(Utils.colorsLogs);

            lineas.Add(new Lane(0, false, ConsoleColor.DarkGreen, false, false, 0f, Utils.charCars, colorsCars));
            lineas.Add(new Lane(1, true, ConsoleColor.DarkBlue, false, true, 0.8f, Utils.charLogs, colorsLogs));
            lineas.Add(new Lane(2, true, ConsoleColor.DarkBlue, false, true, 0.8f, Utils.charLogs, colorsLogs));
            lineas.Add(new Lane(3, true, ConsoleColor.DarkBlue, false, true, 0.8f, Utils.charLogs, colorsLogs));
            lineas.Add(new Lane(4, true, ConsoleColor.DarkBlue, false, true, 0.8f, Utils.charLogs, colorsLogs));
            lineas.Add(new Lane(5, true, ConsoleColor.DarkBlue, false, true, 0.8f, Utils.charLogs, colorsLogs));
            lineas.Add(new Lane(6, false, ConsoleColor.DarkGreen, false, false, 0f, Utils.charCars, colorsCars));
            lineas.Add(new Lane(7, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, colorsCars));
            lineas.Add(new Lane(8, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, colorsCars));
            lineas.Add(new Lane(9, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, colorsCars));
            lineas.Add(new Lane(10, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, colorsCars));
            lineas.Add(new Lane(11, false, ConsoleColor.Black, true, false, 0.1f, Utils.charCars, colorsCars));
            lineas.Add(new Lane(12, false, ConsoleColor.DarkGreen, false, false, 0f, Utils.charCars, colorsCars));
            lineas.Add(new Lane(13, false, ConsoleColor.Black, false, false, 0f, Utils.charCars, colorsLogs));

            // Crear personaje
            Utils.GAME_STATE gameState = Utils.GAME_STATE.RUNNING;

            Player player = new Player();

            Vector2Int inputDirection = Vector2Int.zero;
            player.Draw();

            while (gameState == Utils.GAME_STATE.RUNNING)
            {

                // Inputs
                inputDirection = Utils.Input();
                //player.Update(inputDirection, lineas);
                for (int i = 0; i < lineas.Count; i++)
                {
                    lineas[i].Update();
                }


                // Dibujado
                for (int i = 0; i < lineas.Count; i++)
                {
                    lineas[i].Draw();
                }
                foreach (Lane lane in lineas)
                {
                    if (lane.posY == player.pos.y)
                    {
                        player.Draw(lane.background);
                        break;
                    }
                }
                player.Draw();
                Console.BackgroundColor = ConsoleColor.Black;

                // Lógica
                gameState = player.Update(inputDirection, lineas);
                if (gameState == Utils.GAME_STATE.WIN)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("YOU WON!");
                    System.Threading.Thread.Sleep(500);
                }
                if (gameState == Utils.GAME_STATE.LOOSE)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("YOU LOST!");
                    System.Threading.Thread.Sleep(500);
                }
                TimeManager.NextFrame();
            }
        }
    }
}
