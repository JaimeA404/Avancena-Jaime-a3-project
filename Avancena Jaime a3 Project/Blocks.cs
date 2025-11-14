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
        Vector2 position;
        Vector2 velocity;
        public Vector2 size;

        public Vector2 gravity = new Vector2(0, 0.75f);

        public int blockHealth = 0;


        //collision sides
        public float top;
        public float bottom;
        public float left;
        public float right;

        public Blocks(Vector2 pos, Vector2 size)
        {
            this.position = pos;
            this.size = size;
        }
        public void setup()
        {
            blockHealth = 6;
        }
        public void update()
        {
            DrawBlocks();
            BlockGravity();

            //update collision sides
            top = position.Y;
            bottom = position.Y + 5;
            left = position.X;
            right = position.X + 5;
        }

        public void BlockGravity()
        {
            velocity += gravity * Time.DeltaTime;
            position.X += velocity.X * Time.DeltaTime;
            position.Y += velocity.Y * Time.DeltaTime;
        }

        public void DrawBlocks() 
        {
            Draw.LineSize = 2;
            Draw.LineColor = Color.DarkGray;
            Draw.FillColor = Color.Gray;

            Draw.Rectangle(position.X, position.Y, 5, 5);
        }
    }
}
