using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Aqua
{
    class Tools
    {
        public static Random random = new Random();

        public static double Distance(PointF first, PointF second)
        {
            return Math.Sqrt((first.X-second.X)*(first.X-second.X) + (first.Y-second.Y)*(first.Y-second.Y));
        }

        public static Point FishSize(FishType type)
        {
            Point size = new Point();
            if (type == FishType.fish1)
            {
                size.X = Images.fish1.Width;
                size.Y = Images.fish1.Height;             
            }
            else if (type == FishType.fish2)
            {
                size.X = Images.fish2.Width;
                size.Y = Images.fish2.Height;
            }
            else if (type == FishType.fish3)
            {
                size.X = Images.fish3.Width;
                size.Y = Images.fish3.Height;
            }
            else if (type == FishType.fish4)
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

        public static void ListsInitialization()
        {
            Dictionary<FishType, Image> imageLeft = ImagePool.Instance.imageLeft;
            Dictionary<FishType, Image> imageRight = ImagePool.Instance.imageRight;
            Dictionary<FishType, Image> deadFishLeft = ImagePool.Instance.deadFishLeft;
            Dictionary<FishType, Image> deadFishRight = ImagePool.Instance.deadFishRight;

            imageLeft.Add(FishType.fish1, Images.fish1);
            imageLeft.Add(FishType.fish2, Images.fish2);
            imageLeft.Add(FishType.fish3, Images.fish3);
            imageLeft.Add(FishType.fish4, Images.fish4);

            imageRight.Add(FishType.fish1, RotateToRight(Images.fish1));
            imageRight.Add(FishType.fish2, RotateToRight(Images.fish2));
            imageRight.Add(FishType.fish3, RotateToRight(Images.fish3));
            imageRight.Add(FishType.fish4, RotateToRight(Images.fish4));

            deadFishLeft.Add(FishType.fish1, RotateToUp(Images.fish1));
            deadFishLeft.Add(FishType.fish2, RotateToUp(Images.fish2));
            deadFishLeft.Add(FishType.fish3, RotateToUp(Images.fish3));
            deadFishLeft.Add(FishType.fish4, RotateToUp(Images.fish4));

            deadFishRight.Add(FishType.fish1, RotateToUp(RotateToRight(Images.fish1)));
            deadFishRight.Add(FishType.fish2, RotateToUp(RotateToRight(Images.fish2)));
            deadFishRight.Add(FishType.fish3, RotateToUp(RotateToRight(Images.fish3)));
            deadFishRight.Add(FishType.fish4, RotateToUp(RotateToRight(Images.fish4)));
        }

        public static Image RotateToRight(Image image)
        {
            Image tmpImage = image;
            tmpImage.RotateFlip(RotateFlipType.Rotate180FlipY);
            return tmpImage;
        }

        public static Image RotateToUp(Image image)
        {
            Image tmpImage = image;
            tmpImage.RotateFlip(RotateFlipType.Rotate180FlipX);
            return tmpImage;
        }
    }
}
