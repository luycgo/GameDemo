using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class GameClient
    {
        private readonly GamePlayer blackPlayer;
        private readonly GamePlayer whitePlayer;
        private GameControl gameControl;

        public GameClient()
        {
            blackPlayer = new GamePlayer
            {
                Id = 1,
                Name = "玩家1"
            };
            whitePlayer = new GamePlayer
            {
                Id = 2,
                Name = "玩家2"
            };
            gameControl = new GameControl();
            CurrentPlayer = blackPlayer;
        }

        // 当前第几轮
        public int CurrentSteps { get; private set; } = 1;

        //当前玩家
        public GamePlayer CurrentPlayer { get; private set; }

        public void GameStart(int row, int removeNumber)
        {
            var result = gameControl.Play(CurrentPlayer, CurrentSteps, row, removeNumber);
            if (result)
            {
                if (gameControl.IsOver())
                {
                    Console.WriteLine($"游戏结束，玩家【{CurrentPlayer.Name}】输了，请再接再励哦！按任意键退出");
                    Console.ReadKey();
                    Environment.Exit(0);
                    return;
                }

                if (CurrentPlayer == blackPlayer)
                    CurrentPlayer = whitePlayer;
                else
                    CurrentPlayer = blackPlayer;

                if (CurrentPlayer == blackPlayer)
                    CurrentSteps += 1;
            }
        }

        public override string ToString()
        {
            return gameControl.ToString();
        }
    }
}
