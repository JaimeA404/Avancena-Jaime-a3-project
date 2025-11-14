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

        //bomb variables
        Bomb[] bombs = new Bomb[2];
        int BombIndex = 0;

        Vector2 aimPosition = new Vector2 (150,280);

        bool canFire = true;
        float fireCoolDown = 0.0f; // cooldown timer start

        Blocks[] blocks = new Blocks[5];

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Bombs Away");
            Window.SetSize(800, 400);
            Window.TargetFPS = 60;

            makeBuildings();
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

            if (canFire == true && (Input.IsKeyboardKeyPressed(KeyboardInput.Space) ||  Input.IsKeyboardKeyPressed(KeyboardInput.Enter)))
            {
                spawnBomb();
                canFire = false;
            }

            // fire cooldown mechanic

            if (canFire == false)
            {
                fireCoolDown += Time.DeltaTime;

                if (fireCoolDown >= 3.0f)
                {
                    canFire = true;
                    fireCoolDown = 0;
                }
            }

            for (int i = 0; i < bombs.Length; i++)
            {
                if (bombs[i] == null) continue;
                bombs[i].Update(blocks);
            }

            for (int i = 0; i < blocks.Length; i++)
            {
                if (blocks[i] == null) continue;
                blocks[i].update();
            }
        }

        void damageCalc()
        {
            
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

        void makeBuildings()
        {
            Vector2 basePosition = new Vector2(350, 275);
            int blockCount = 5;

            for (int i = 0; i < 5; i++)
            {
                Vector2 BlocksPos = new Vector2(basePosition.X, basePosition.Y - (i * 5));
                blocks[i] = new Blocks(BlocksPos, new Vector2(5, 5));
                blocks[i].setup();
            }
        }
    }

}
