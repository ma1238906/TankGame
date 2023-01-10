using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour {
	public static string id = "";
	public static PlayerData player { get; set; }
	private static MapData _map;
	public static MapData map
	{
		get
		{
			if (_map == null)
			{
				_map = new MapData();
			}
			return _map;
		}
		set
		{
			_map = value;
		}
	}

	// Use this for initialization
	void Start () {
		//网络监听
		NetManager.AddEventListener(NetManager.NetEvent.Close, OnConnectClose);
		NetManager.AddMsgListener("MsgKick", OnMsgKick);
		//初始化
		PanelManager.Init();
		BattleManager.Init();
		ChatManager.InitGME();
        //打开登陆面板
        PanelManager.Open<LoginPanel>();
	}


	// Update is called once per frame
	void Update () {
		NetManager.Update();
		ChatManager.Update();
	}

    private void OnDestroy()
    {
		NetManager.Close();
    }

    //关闭连接
    void OnConnectClose(string err){
		Debug.Log("断开连接");
	} 

	//被踢下线
	void OnMsgKick(MsgBase msgBase){
		PanelManager.Open<TipPanel>("被踢下线");
	}
}

/// <summary>
/// 玩家信息
/// </summary>
public class PlayerData
{
	//昵称
	public string nickname = "";
	//头像
	public string headName = "";
	//金币
	public int coin = 0;
	//记事本
	public string text = "new text";
	//胜利数
	public int win = 0;
	//失败数
	public int lost = 0;
}

/// <summary>
/// 地图信息
/// </summary>
public class MapData
{
	public string CurrentMapName;
}
