// See https://aka.ms/new-console-template for more information
using Game;

Console.WriteLine("游戏开始...");
Console.WriteLine("请输入 Row-Number, 如：2-3 将从第二行拿走3颗星星");
GameClient gameClient = new GameClient();

while (true)
{ 
    Console.WriteLine(gameClient.ToString());
    Console.WriteLine($"第{gameClient.CurrentSteps}轮，玩家：[{gameClient.CurrentPlayer.Name}]拿走星星 Row-Number：");
    var readStr = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(readStr))
    {
        ShowMsg();
        continue;
    }

    var readChars = readStr.Split('-');
    if (readChars.Length != 2)
    {
        ShowMsg();
        continue;
    }

    int row = 0;
    int number = 0;

    //玩游戏命令处理
    if (!int.TryParse(readChars[0], out row) || !int.TryParse(readChars[1], out number))
    {
        ShowMsg();
        continue;
    }

    gameClient.GameStart(row, number);
}

static void ShowMsg()
{
    Console.WriteLine("输入格式不正式，请参照格式 Row-Number ");
}