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
        
        public Direction direction;
        private FishType type;
        public PointF destination;
        public int widthSize;
        public int heightSize;
        public float maximumHealth;
        public float health;
        public Strategy strategy;
              
        public Fish(int width, int height, PointF pos)
        {
            maxShiftX = width;
            maxShiftY = height;           
            direction = Direction.Left;
            type = (FishType)Tools.random.Next(0, 4);
            position = pos;
            destination = position;
            widthSize = Tools.FishSize(type).X;
            heightSize = Tools.FishSize(type).Y;
            maximumHealth = 200.0f;
            health = maximumHealth;
            strategy = new InitialStrategy(this);
        }

        public override void Move(int width, int height)
        {
            strategy = strategy.Next();
            strategy.Move();
        }

        public override void Draw(Graphics g)
        {
            ImagePool.Instance.DrawImage(g, type, position, direction, health == 0);           
        }

        public override void DrawIfSelected(Graphics g)
        {
            ImagePool.Instance.DrawImage(g, type, position, direction, health == 0);
            ImagePool.Instance.DrawFrame(g, position, widthSize, heightSize, health, maximumHealth);
        }

        public override bool HitTest(int x, int y)
        {
            return (x >= position.X && x <= position.X + widthSize && y >= position.Y && y <= position.Y + heightSize);
        }

    }
}