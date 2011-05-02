using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Reflection;

namespace Aqua
{
    class Fish: BaseObject
    {        
        static Random random = new Random();
        private Direction direction;
        private FishType type;
        private PointF destination;
        private int widthSize;
        private int heightSize;
        public float maximumHealth;
        private float health;
        public bool isDead;
              
        public Fish(int width, int height, PointF pos)
        {
            maxShiftX = width;
            maxShiftY = height;           
            direction = Direction.Left;
            type = (FishType)random.Next(0, 4);
            position = pos;
            destination = position;
            widthSize = Tools.FishSize(type).X;
            heightSize = Tools.FishSize(type).Y;
            maximumHealth = 200.0f;
            health = maximumHealth;
            isDead = false;
        }

        private void Step()
        {
            double distance = Tools.Distance(position, destination);
            double dy = (destination.Y - position.Y )/distance;
            double dx = (destination.X - position.X)/distance;
            position = new PointF(position.X + (float)dx, position.Y + (float)dy) ;
        }

        private void DeadStep()
        {
            if(position.Y > 0)
                position = new PointF(position.X, position.Y - 1);
        }

        public override void Move(int width, int height)
        {
            health -= (float)random.NextDouble();
            if (health <= 1)
            {
                health = 0;
                isDead = true;
                DeadStep();
                return; 
            }
            else
            {
                if (Tools.Distance(position, destination) >= widthSize / 2)
                {
                    Step();
                    return;
                }
                else
                {
                    destination.X = (float)random.NextDouble() * maxShiftX;
                    destination.Y = (float)random.NextDouble() * maxShiftY;

                    if (destination.X < position.X)
                    {
                        direction = Direction.Left;
                    }
                    else
                    {
                        direction = Direction.Right;
                    }
                }
            }
        }
        
        public override void Draw(Graphics g)
        {
            ImagePool.Instance.DrawImage(g, type, position, direction, isDead);           
        }

        public override void DrawIfSelected(Graphics g)
        {
            ImagePool.Instance.DrawImage(g, type, position, direction, isDead);
            ImagePool.Instance.DrawFrame(g, position, widthSize, heightSize, health, maximumHealth);
        }

        public override bool HitTest(int x, int y)
        {
            return (x >= position.X && x <= position.X + widthSize && y >= position.Y && y <= position.Y + heightSize);
        }

    }
}