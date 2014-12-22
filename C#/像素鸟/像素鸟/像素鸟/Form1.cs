using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 像素鸟
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            IntialGame();
        }

        //初始化游戏，给游戏添加游戏对象

        private Guandao gdUp;
        private Guandao gdDown;

        public void IntialGame()
        {
            SingleObject.GetSingle().AddGameObject(new Bird(50, 200, 0));
            //对管道进行初始化
            gdUp = new Guandao(100, -600, GDDirection.Up);
            gdDown = new Guandao(100, 400, GDDirection.Down);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //this.BackgroundImage = 像素鸟.Properties.Resources.day_background;
            //this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //在绘制窗口同时画出小鸟
            SingleObject.GetSingle().DrawGameObject(e.Graphics);

            gdUp.DrawGD(e.Graphics);
            gdDown.DrawGD(e.Graphics);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        /// <summary>
        /// 当鼠标点击窗口，调用move方法上移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            SingleObject.GetSingle().SingleBird.Move();
            SingleObject.GetSingle().SingleBird.CurrentSpeed = 10f;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                SingleObject.GetSingle().SingleBird.Move();
                SingleObject.GetSingle().SingleBird.CurrentSpeed = 10f;
            }
        }

        /// <summary>
        /// 小鸟按照重力下落
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer2_Tick(object sender, EventArgs e)
        {
            //首先获得小鸟下降高度
            var height = Zhongli.GetHeight(SingleObject.GetSingle().SingleBird.CurrentSpeed,
                SingleObject.GetSingle().SingleBird.DurationTime * 0.001f);//将毫秒转换成帧 Time.DeltaTime

            //获得小鸟下落后新坐标
            int y = SingleObject.GetSingle().SingleBird.Y + (int)height;

            //赋值前对小鸟做个限定
            //最高窗口顶
            y = y < 0 ? 0 : y;
            //限定小鸟，不让他掉落到地面下面
            y = y > this.Size.Height - pictureBox1.Height - 60 ? this.Size.Height - pictureBox1.Height -90 : y;
            //将新坐标Y 赋值给小鸟
            SingleObject.GetSingle().SingleBird.Y = y;

            //小鸟按照加速度下降
            //v = v0 + at;
            SingleObject.GetSingle().SingleBird.CurrentSpeed = SingleObject.GetSingle().SingleBird.CurrentSpeed +
                SingleObject.GetSingle().SingleBird.DurationTime * Zhongli._zhongli * 0.001f;

            //点击鼠标或者空格有个固定的向上值           
        }

        private int GDDistance = 150;

        //让管道从右向左开始移动
        private void MoveGuanDao()
        {
            //在游戏中不停地让管道向左边移动，减少x坐标

            gdUp.X -= 10;
            gdDown.X -= 10;
            //管道移出界面没有从右边出来
            //解决，判断
            if(gdUp.X < -130)
            {
                gdUp.X = this.Width * 4 / 3 - 130;
                gdDown.X = this.Width * 4 / 3 - 130;

                gdUp.GDHeight = SetRandomHeight();
                gdDown.GDHeight = this.Size.Height - this.pictureBox1.Height - GDDistance - gdUp.GDHeight;
                //最后更具高度，计算出y坐标复制给管道
                gdUp.Y = gdUp.GDHeight - 830;
                gdDown.Y = gdDown.GDHeight + GDDistance;
            }
        }

        public int SetRandomHeight()
        {
            Random r = new Random();
            int totalHeight = this.Size.Height - this.pictureBox1.Height;
            //return 0;
            return r.Next(90, totalHeight - 90 - GDDistance);
        }


        /// <summary>
        /// 在timer中管道不停的移动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer3_Tick(object sender, EventArgs e)
        {
            MoveGuanDao();

            //不停的判断是否发生碰撞
            if(SingleObject.GetSingle().SingleBird.GetRectangle
                ().IntersectsWith(gdDown.GetRectangle()))
            {
                Console.WriteLine("鸟挂了");
                //MessageBox.Show("鸟挂了");
            }
        }

    }
}
