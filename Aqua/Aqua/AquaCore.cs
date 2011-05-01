using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Aqua
{
    class AquaCore
    {
        private int count;
        public int width;
        public int height;
        private Random random = new Random();             
        private List <InterfaceBaseObject> objectList;

        public AquaCore() { }
        public static AquaCore Instance = new AquaCore();

        public void Initialize (int count, int width, int height)
        {
            this.width = width;
            this.height = height;
            this.count = count;
            objectList = new List<InterfaceBaseObject>();

            for (int i = 0; i < count; i++)
            {
                objectList.Add (new Fish(width, height, new PointF ((float)random.NextDouble()*width, (float)random.NextDouble()*height)));
            }            
        }

        public void Refresh(int width, int height)
        {
            if (objectList == null)
            {
                throw new ApplicationException("Сначала следует вызвать метод Initialize()");
            }

            foreach (InterfaceBaseObject obj in objectList)
            {
                obj.Move(width, height);

            }
        }      

        internal void Draw (Graphics g)
        {
            if (objectList == null)
            {
                throw new ApplicationException("Сначала следует вызвать метод Init()");
            }
            
            foreach (InterfaceBaseObject obj in objectList)
            {
                if (obj is SelectedFishDecorator)
                {
                    obj.DrawIfSelected(g);
                }
                else
                {
                    obj.Draw(g);
                }
            }         
        }

        public void Resize(int width, int height) 
        {
            if (this.width == width && this.height == height) return;

            int dw = width - this.width;
            int dh = height - this.height;

            foreach (BaseObject obj in objectList)
            {
                obj.position.X += dw;
                obj.position.Y += dh;
            }

            this.height = height;
            this.width = width;
        }

        public void Select(int x, int y)
        {
            for (int i = 0; i < objectList.Count; i++)
            {
                InterfaceBaseObject interfaceBaseObject = objectList[i];
                if (interfaceBaseObject.HitTest(x, y))
                {
                    if (interfaceBaseObject is SelectedFishDecorator)
                    {
                        objectList[i] = (interfaceBaseObject as SelectedFishDecorator).original;
                    }
                    else
                    {
                        objectList[i] = new SelectedFishDecorator(interfaceBaseObject);
                    }
                }
            }
        }

    }
}