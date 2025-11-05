// Include the namespaces (code libraries) you need below.
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

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("Bombs Away");
            Window.SetSize(800, 600);
            Window.TargetFPS = 60;
        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            Window.ClearBackground(Color.LightGray);

            for (int i = 0; i < bombs.Length; i++)
            {
                if (bombs[i] == null) continue;
                bombs[i].Update();
            }
        }

        void spawnBomb()
        {
            
        }
    }

}
