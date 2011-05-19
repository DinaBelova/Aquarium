using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Reflection;

namespace Aqua
{
    class LifeStrategy:Strategy
    {
        private double speedFactor;

        public LifeStrategy(Fish fish, double speedFactor)
            : base(fish)
        {
            this.speedFactor = speedFactor;
        }

        public override void Move()
        {

            if (Tools.Distance(fish.position, fish.destination) >= fish.widthSize / 2)
            {
                double distance = Tools.Distance(fish.position, fish.destination);
                double dy = (fish.destination.Y - fish.position.Y) / distance * speedFactor;
                double dx = (fish.destination.X - fish.position.X) / distance * speedFactor;
                fish.position = new PointF(fish.position.X + (float)dx, fish.position.Y + (float)dy);
            }
            else
            {
                fish.destination.X = (float)Tools.random.NextDouble() * fish.maxShiftX;
                fish.destination.Y = (float)Tools.random.NextDouble() * fish.maxShiftY;

                if (fish.destination.X < fish.position.X)
                {
                    fish.direction = Direction.Left;
                }
                else
                {
                    fish.direction = Direction.Right;
                }
            }

            fish.health -= (float)Tools.random.NextDouble();
        }

        public override Strategy Next()
        {
            if (fish.health <= 1)
            {
                fish.health = 0;
                return new DeadStrategy(fish);
            }
            else
            {
                return this;
            }
        }
    }
}
