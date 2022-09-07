using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    //星星
    public class Star
    {
        //星星所在的行
        public int row { get; set; }

        //取走星星的数量
        public int Number { get; set; }

        //初始化星星
        public static List<Star> InitStarLayout()
        { 
            List<Star> stars = new List<Star>();
            stars.Add(new Star() { row = 1, Number = 3 });
            stars.Add(new Star() { row = 2, Number = 5 });
            stars.Add(new Star() { row = 3, Number = 7 });
            return stars;
        }
    }
}
