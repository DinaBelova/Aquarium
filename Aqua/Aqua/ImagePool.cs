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
        public Dictionary<FishType, Image> imageRight { get; private set; }
        public Dictionary<FishType, Image> imageLeft { get; private set; }
        public Dictionary<FishType, Image> deadFishRight { get; private set; }
        public Dictionary<FishType, Image> deadFishLeft { get; private set; }
        public Image background {get; protected set;}
        public bool gameOver { get; protected set; }

        protected ImagePool()
        {
            gameOver = false;
            background = Images.background;
            imageLeft = new Dictionary<FishType, Image>();
            imageRight = new Dictionary<FishType, Image>();
            deadFishLeft = new Dictionary<FishType, Image>();
            deadFishRight = new Dictionary<FishType, Image>();

            //Tools.ListsInitialization();

            imageLeft.Add(FishType.fish1, Images.fish1);
            imageLeft.Add(FishType.fish2, Images.fish2);
            imageLeft.Add(FishType.fish3, Images.fish3);
            imageLeft.Add(FishType.fish4, Images.fish4);

            imageRight.Add(FishType.fish1, Tools.RotateToRight(Images.fish1));
            imageRight.Add(FishType.fish2, Tools.RotateToRight(Images.fish2));
            imageRight.Add(FishType.fish3, Tools.RotateToRight(Images.fish3));
            imageRight.Add(FishType.fish4, Tools.RotateToRight(Images.fish4));

            deadFishLeft.Add(FishType.fish1, Tools.RotateToUp(Images.fish1));
            deadFishLeft.Add(FishType.fish2, Tools.RotateToUp(Images.fish2));
            deadFishLeft.Add(FishType.fish3, Tools.RotateToUp(Images.fish3));
            deadFishLeft.Add(FishType.fish4, Tools.RotateToUp(Images.fish4));

            deadFishRight.Add(FishType.fish1, Tools.RotateToUp(Tools.RotateToRight(Images.fish1)));
            deadFishRight.Add(FishType.fish2, Tools.RotateToUp(Tools.RotateToRight(Images.fish2)));
            deadFishRight.Add(FishType.fish3, Tools.RotateToUp(Tools.RotateToRight(Images.fish3)));
            deadFishRight.Add(FishType.fish4, Tools.RotateToUp(Tools.RotateToRight(Images.fish4)));

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
                //if (!gameOver)
                //{
                //    ChangeBack();
                //    gameOver = true;
                //}
                if (direction == Direction.Left)
                    g.DrawImage(deadFishLeft[type], position.X, position.Y);
                else
                    g.DrawImage(deadFishRight[type], position.X, position.Y);
            }
        }

        public void DrawFrame(Graphics g, PointF position, int widthSize, int heightSize, float health, float maximumHealth)
        {
            g.DrawRectangle(Pens.White, position.X , position.Y - 3, widthSize, heightSize);

            if (health > maximumHealth/2)
                g.FillRectangle(Brushes.LimeGreen, position.X, position.Y - 3, health * widthSize / maximumHealth, 3);
            else
                g.FillRectangle(Brushes.Red, position.X, position.Y - 3, health*widthSize/maximumHealth, 3);
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

        private void ChangeBack()
        {
            background = Images.gameOver;
        }
    }
}
