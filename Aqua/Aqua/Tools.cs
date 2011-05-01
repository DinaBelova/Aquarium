using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Aqua
{
    class Tools
    {
        public static double Distance(PointF first, PointF second)
        {
            return Math.Sqrt((first.X-second.X)*(first.X-second.X) + (first.Y-second.Y)*(first.Y-second.Y));
        }

        public static Point FishSize(FishType type)
        {
            Point size = new Point();
            if (type == (FishType)0)
            {
                size.X = Images.fish1.Width;
                size.Y = Images.fish1.Height;             
            }
            else if (type == (FishType)1)
            {
                size.X = Images.fish2.Width;
                size.Y = Images.fish2.Height;
            }
            else if (type == (FishType)2)
            {
                size.X = Images.fish3.Width;
                size.Y = Images.fish3.Height;
            }
            else if (type == (FishType)3)
            {
                size.X = Images.fish4.Width;
                size.Y = Images.fish4.Height;
            }
            else
            {
                throw new ArgumentException("Unsupported fish type");
            }

            size.X /= 2;
            size.Y /= 2;

            return size;
        }
    }
}
