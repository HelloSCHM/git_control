using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 像素鸟.Properties;

namespace 像素鸟
{
    public class Bird : GameObject
    {
        //绘制鸟的 图片
        private static Image[] imgs = {
                                   Resources.bird_blue_0,
                                   Resources.bird_blue_1,
                                   Resources.bird_blue_2
                               };

        public int BirdIndex
        {
            get;
            set;
        }

        public Bird(int x, int y, int birdIndex)
            :base(x,y,imgs[0].Width, imgs[1].Height)
        {
            this.BirdIndex = birdIndex;
            this.DurationTime = 100;
            this.CurrentSpeed = 0;
        }

        /// <summary>
        /// 将小鸟绘制到窗口
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            switch(this.BirdIndex)
            {
                case 0:
                    g.DrawImage(imgs[0], this.X, this.Y);
                    break;
                case 1:
                    g.DrawImage(imgs[1], this.X, this.Y);
                    break;
                case 2:
                    g.DrawImage(imgs[2], this.X, this.Y);
                    break;
            }
            this.BirdIndex++;
            if (this.BirdIndex >= 3)
                this.BirdIndex = 0;
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 点击窗口或者空格，小鸟向上
        /// </summary>
        public override void Move()
        {
            this.Y -= 40;
            if (this.Y <= 0)
            {
                this.Y = 0;
            }

        }

        public float CurrentSpeed
        {
            get;
            set;
        }

        public int DurationTime
        {
            get;
            set;
        }
    }
}
