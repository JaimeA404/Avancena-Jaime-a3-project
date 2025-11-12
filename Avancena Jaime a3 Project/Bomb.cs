using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D

{
    public class Bomb
    {
        public Vector2 position;
        public Vector2 velocity;

        public Vector2 gravity = new Vector2(0,0.75f);

        float bombSpeed = 450.0f;


        public void Setup()
        {
            
        }

        public void Update() 
        {
            ProcessBombPhysics();
            BombGravity();
            DrawBomb();
        }

        void ProcessBombPhysics()
        {
            position += bombSpeed * velocity * Time.DeltaTime;
        }

        public void BombGravity()
        {
            // Apply gravity
            velocity += gravity * Time.DeltaTime;

            // Update position
            position.Y += velocity.Y * Time.DeltaTime;
        }
        void DrawBomb()
        {
            Draw.LineSize = 2;
            Draw.FillColor = Color.DarkGray;
            Draw.LineColor = Color.Black;
            Draw.Circle(position, 5);

        }
    }
}
