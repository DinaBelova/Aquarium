using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Aqua
{
    abstract class BaseObject:InterfaceBaseObject
    {
        public PointF position;
        public int maxShiftX;
        public int maxShiftY;

        public abstract void Draw (Graphics g);
        public abstract void DrawIfSelected(Graphics g);
        public abstract void Move(int width, int height);
        public abstract bool HitTest(int x, int y);
    }
}