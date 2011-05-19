using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Reflection;

namespace Aqua
{
    abstract class Strategy
    {
        public Fish fish;

        public Strategy(Fish fish)
        {
            this.fish = fish;
        }

        public abstract void Move();

        public abstract Strategy Next();
    }
}
