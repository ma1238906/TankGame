using System;

namespace Game
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            if (!DbManager.Connect("game", "172.22.210.186", 3306, "root", "123456"))
            {
                return;
            }

            MsgHandler.Init();
			NetManager.StartLoop(8888);
		}
	}
}
