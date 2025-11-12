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

        Vector2 aimPosition = new Vector2 (350,150);

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

            if (Input.IsKeyboardKeyDown(KeyboardInput.W) || Input.IsKeyboardKeyDown(KeyboardInput.Up))
            {
                aimPosition.Y -= 5;
            }

            if (Input.IsKeyboardKeyDown(KeyboardInput.S) || Input.IsKeyboardKeyDown(KeyboardInput.Down))
            {
                aimPosition.Y += 5;
                
                //if (aimPosition.Y >= )
            }
            /*if (Input.IsKeyboardKeyDown(KeyboardInput.A) || Input.IsKeyboardKeyDown(KeyboardInput.Left))
            {
                aimPosition.X -= 5;
            }
            if (Input.IsKeyboardKeyDown(KeyboardInput.D) || Input.IsKeyboardKeyDown(KeyboardInput.Right))
            {
                aimPosition.X += 5;
            }*/    // disabled x movement to keep trajectory line smaller

            Draw.LineSize = 5;
            Draw.Line(100, 300, 150, aimPosition.Y);

            if (Input.IsKeyboardKeyPressed(KeyboardInput.Space) || Input.IsKeyboardKeyPressed(KeyboardInput.Enter))
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

            Vector2 bombTrajectory = aimPosition - bombSpawn;
            bomb.velocity = Vector2.Normalize(bombTrajectory);

            bombs[BombIndex] = bomb;
            BombIndex++;

            if (BombIndex >= bombs.Length) BombIndex = 0;
        }
    }

}
