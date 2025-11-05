using MohawkGame2D;
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

        public Vector2 gravity;
        Vector2 bombVelocity = new Vector2(0, 0);

        float bombSpeed = 300.0f;


        public void Setup()
        {
            
        }

        public void Update() 
        {
            ProcessBombPhysics();
            //BombGravity();
            DrawBomb();
        }

        void ProcessBombPhysics()
        {
            position += bombSpeed * bombVelocity * Time.DeltaTime;
        }

        void BombGravity()
        { 
            bombVelocity += gravity * Time.DeltaTime;
        }
        void DrawBomb()
        {
            Draw.LineSize = 2;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.DarkGray;
            Draw.Circle(position, 7);

        }
    }
}
