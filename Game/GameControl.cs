using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameControl
    {
        private readonly List<Star> stars;

        //上次拿的行
        private int lastRow = 0;

        public GameControl()
        {
            stars = Star.InitStarLayout();
        }

        /// <summary>
        /// 玩游戏
        /// </summary>
        public bool Play(GamePlayer player, int steps, int row, int removeNumber)
        {
            var lastStar = stars.FirstOrDefault(m => m.row == lastRow);

            var star = stars.FirstOrDefault(m => m.row == row);
            if (star == null)
            {
                Console.WriteLine("出错了，请在行1到3中取值，玩家重试");
                return false;
            }

            if (star.Number < removeNumber)
            {
                Console.WriteLine($"行【{row}】只剩下{star.Number}颗星星，玩家重新开始。。");
                return false;
            }
            if (lastRow != 0 && lastRow != row && lastStar.Number > 0)
            {
                Console.WriteLine($"【{lastRow}】行还有星星，不允许跨行");
                return false;
            }

            star.Number -= removeNumber;

            lastRow = row;

            return true;
        }

        // 游戏是否结束
        // 当前玩家是否输了
        public bool IsOver()
        {
            return !stars.Any(m => m.Number > 0);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var item in stars)
            {
                if (item.Number > 0)
                {
                    builder.Append($"第{item.row}行：");
                    for (int i = 0; i < item.Number; i++)
                    {
                        builder.Append("☆");
                    }
                    builder.Append("\n");
                }
            }
            return builder.ToString();
        }
    }
}
