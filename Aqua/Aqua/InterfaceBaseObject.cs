using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Aqua
{
    public interface InterfaceBaseObject
    {
        void Draw(Graphics g);
        void DrawIfSelected(Graphics g);
        void Move(int width, int height);
        bool HitTest(int x, int y);
    }
}
