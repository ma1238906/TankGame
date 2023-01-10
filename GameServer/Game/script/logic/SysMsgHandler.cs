using System;
using System.Collections.Generic;

public partial class MsgHandler {
	public static void MsgPing(ClientState c, MsgBase msgBase){
		Console.WriteLine("MsgPing");
		c.lastPingTime = NetManager.GetTimeStamp();
		MsgPong msgPong = new MsgPong();
		NetManager.Send(c, msgPong);
	}
}

public partial class MsgHandler
{
	public static Dictionary<string, System.Reflection.MethodInfo> MsgDic = new Dictionary<string,System.Reflection.MethodInfo>();

	public static void Init()
    {
		System.Reflection.MethodInfo[] allMsg = typeof(MsgHandler).GetMethods();
		for(int i=0;i<allMsg.Length;i++)
        {
			MsgDic.Add(allMsg[i].Name, allMsg[i]);
        }
    }
}