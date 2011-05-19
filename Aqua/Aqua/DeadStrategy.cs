using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Aqua
{
    class DeadStrategy:Strategy
    {
        public DeadStrategy(Fish fish)
            : base(fish)
        { 
        }

        public override void Move()
        {
            if (fish.position.Y > 0)
                fish.position = new PointF(fish.position.X, fish.position.Y - 1);
        }

        public override Strategy Next()
        {
            return this;
        }
    }
}
