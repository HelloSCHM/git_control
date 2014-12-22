using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 像素鸟.Properties;

namespace 像素鸟
{
    public enum GDDirection
    {
        Up,
        Down
    }
    public class Guandao
    {
        //两种管道，向上、向下

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

        public GDDirection GD
        {
            get;
            set;
        }

        public Guandao(int x, int y, GDDirection  gd)
        {
            this.X = x;
            this.Y = y;
            this.GD = gd;
        }

        public int GDHeight
        {
            get;
            set;
        }

        public int GDWidth
        {
            get;
            set;
        }

        //获取管道的图片
        public Image img = Resources.flappy_packer;

        /// <summary>
        /// 从大图中获取图片
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Image GetImage(int x, int y)
        {
            //创建位图对象 宽 128 高830
            Bitmap bmp = new Bitmap(130, 801);
            //将截取出来的图片 通过GDI+对象 绘制到位图上
            Graphics g = Graphics.FromImage(bmp);
            //开始绘制
            //第一个矩形表示我要绘制到bmp上矩形的大小
            //第二个举行表示我从原图的那个位置开始截取图片
            g.DrawImage(img, new Rectangle(0, 0, 130, 830), new Rectangle(x, y, 128, 830), GraphicsUnit.Pixel);
            return bmp;
        }

        public void DrawGD(Graphics g)
        {
            //在绘制管道的时候，应该根据不同的方向 绘制不同的管道
            switch (this.GD)
            {
                case GDDirection.Up:
                    g.DrawImage(GetImage(160, 495), this.X, this.Y);
                    break;
                case GDDirection.Down:
                    g.DrawImage(GetImage(10, 480), this.X, this.Y);
                    break;
            }
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(this.X, this.Y, this.GDWidth, this.GDHeight);
        }
    }
}
