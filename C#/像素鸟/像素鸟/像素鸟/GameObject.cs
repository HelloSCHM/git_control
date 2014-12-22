using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 像素鸟
{
    public abstract class GameObject
    {
        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public int Width
        {
            get;
            set;
        }

        public int Height
        {
            get;
            set;
        }

        public GameObject(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }

        public abstract void Move();

        public abstract void Draw(Graphics g);

        public Rectangle GetRectangle()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }
    }
}
