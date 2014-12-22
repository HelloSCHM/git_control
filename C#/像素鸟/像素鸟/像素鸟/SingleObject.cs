using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 像素鸟
{
    /// <summary>
    /// 全局中任何位置获得对象
    /// </summary>
    class SingleObject
    {
        //实现单里设计模式

        private SingleObject()
        { }

        //声明全局唯一单例
        private static SingleObject _singleObject = null;

        //对外提供一个获得对象的方法
        public static SingleObject GetSingle()
        {
            if(_singleObject == null)
            {
                _singleObject = new SingleObject();
            }
            return _singleObject;
        }

        //在单例中存储唯一游戏对象

        public Bird SingleBird
        {
            get;
            set;
        }

        /// <summary>
        /// 个当前类添加一个 向游戏中添加游戏对象的方法
        /// </summary>
        /// <param name="go"></param>
        public void AddGameObject(GameObject go)
        {
            SingleBird = (Bird)go;
        }

        public void DrawGameObject(Graphics g)
        {
            SingleBird.Draw(g);
        }

    }
}
