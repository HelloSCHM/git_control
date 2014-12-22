using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 像素鸟
{
    class Zhongli
    {
        public static float _zhongli = 9.8f;

        //写方法计算小鸟下降

        public static float GetHeight(float speed, float second)
        {
            return (float)( 0.5 * _zhongli * second * second ) + speed * second; 
        }
    }
}
