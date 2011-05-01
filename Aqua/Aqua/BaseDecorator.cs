using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Aqua
{
    class BaseDecorator:InterfaceBaseObject
    {
        public InterfaceBaseObject original { get; protected set; }

        public BaseDecorator(InterfaceBaseObject original)
        {
            this.original = original;
        }

        public virtual void Draw(Graphics g)
        {
            original.Draw(g);
        }

        public virtual void DrawIfSelected(Graphics g)
        {
            original.DrawIfSelected(g);
        }

        public virtual void Move(int width, int height)
        {
            original.Move(width, height);
        }

        public virtual bool HitTest(int x, int y)
        {
            return original.HitTest(x, y);
        }
    }
}
