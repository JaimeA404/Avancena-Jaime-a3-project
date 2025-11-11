// Include the namespaces (code libraries) you need below.
using Raylib_cs;
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:

        Bomb[] bombs = new Bomb[100];
        int BombIndex = 0;

        Vector2 aimPosition = new Vector2 (200,200);

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Bombs Away");
            Window.SetSize(800, 400);
            Window.TargetFPS = 60;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);

            //WASD and arrow keys to control

            if (Input.IsKeyboardKeyDown(KeyboardInput.W))
            {
                aimPosition.Y -= 5;
            }

            if (Input.IsKeyboardKeyDown(KeyboardInput.S))
            {
                aimPosition.Y += 5;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.A))
            {
                aimPosition.X -= 5;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                aimPosition.X += 5;
            }

            Draw.LineSize = 5;
            Draw.Line(100, 300, aimPosition.X, aimPosition.Y);

            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                spawnBomb();
            }

            for (int i = 0; i < bombs.Length; i++)
            {
                if (bombs[i] == null) continue;
                bombs[i].Update();
            }
        }

        void spawnBomb()
        {
            Bomb bomb = new Bomb();

            Vector2 bombSpawn = new Vector2(100, 300);

            bomb.position = bombSpawn;

            Vector2 spawnToMouse = aimPosition - bombSpawn;
            bomb.velocity = Vector2.Normalize(spawnToMouse);

            bombs[BombIndex] = bomb;
            BombIndex++;

            if (BombIndex >= bombs.Length) BombIndex = 0;
        }
    }

}
