using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Blocks
    {
        public Vector2 position;
        public Vector2 velocity;

        public Vector2 gravity = new Vector2(0, 0.75f);

        public void setup()
        {
            
        }
        public void update()
        {
            DrawBlocks();
            BlockGravity();
        }

        public void BlockGravity()
        {
            velocity += gravity * Time.DeltaTime;
            position.X += velocity.X * Time.DeltaTime;
            position.Y += velocity.Y * Time.DeltaTime;
        }

        void DrawBlocks() 
        {
            Draw.LineSize = 2;
            Draw.LineColor = Color.DarkGray;
            Draw.FillColor = Color.Gray;

            Draw.Rectangle(position.X, position.Y, 5, 5);
        }
    }
}
