using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Reflection;

namespace Aqua
{
    public class ImagePool
    {
        protected Dictionary<FishType, Image> imageRight;
        protected Dictionary<FishType, Image> imageLeft;
        protected Dictionary<FishType, Image> deadFishRight;
        protected Dictionary<FishType, Image> deadFishLeft;
        public Image background {get; protected set;}



        protected ImagePool()
        {
            background = new Bitmap(Properties.Resources.back);
            imageLeft = new Dictionary<FishType, Image>();
            imageRight = new Dictionary<FishType, Image>();
            deadFishLeft = new Dictionary<FishType, Image>();
            deadFishRight = new Dictionary<FishType, Image>();

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

        private Image RotateToRight(Image image)
        {
            Image tmpImage = image;
            tmpImage.RotateFlip(RotateFlipType.Rotate180FlipY);
            return tmpImage;
        }

        private Image RotateToUp(Image image)
        {
            Image tmpImage = image;
            tmpImage.RotateFlip(RotateFlipType.Rotate180FlipX);
            return tmpImage;
        }

        public void DrawImage(Graphics g, FishType type, PointF position, Direction direction, bool isDead)
        {
            if (!isDead)
            {
                if (direction == Direction.Left)
                    g.DrawImage(imageLeft[type], position.X, position.Y);
                else
                    g.DrawImage(imageRight[type], position.X, position.Y);
            }
            else
            {
                if (direction == Direction.Left)
                    g.DrawImage(deadFishLeft[type], position.X, position.Y);
                else
                    g.DrawImage(deadFishRight[type], position.X, position.Y);
            }
        }

        public void DrawFrame(Graphics g, PointF position, int widthSize, int heightSize, float health, float maximumHealth)
        {
            g.DrawRectangle(Pens.White, position.X , position.Y - 3, widthSize, heightSize);
            g.FillRectangle(Brushes.Green, position.X, position.Y - 3, health*widthSize/maximumHealth, 3);
        }

        private sealed class SingletonCreator
        {
            private static readonly ImagePool instance = new ImagePool();
            public static ImagePool Instance { get { return instance; } }
        }

        public static ImagePool Instance
        {
            get { return SingletonCreator.Instance; }
        }
    }
}
