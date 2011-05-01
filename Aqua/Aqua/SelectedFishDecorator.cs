using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aqua
{
    class SelectedFishDecorator:BaseDecorator
    {
        private bool visible;

        public SelectedFishDecorator(InterfaceBaseObject interfaceBaseObject) : base(interfaceBaseObject)
        {
            visible = true;
        }

        public override void Move(int width, int height)
        {
            base.Move(width, height);
        }

        public override void Draw(System.Drawing.Graphics g)
        {
            if (visible)
            {
                base.Draw(g);
            }
        }

        public override void DrawIfSelected(System.Drawing.Graphics g)
        {
            base.DrawIfSelected(g);
        }
    }
}
