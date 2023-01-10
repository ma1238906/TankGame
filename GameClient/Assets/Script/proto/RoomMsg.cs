﻿//查询成绩
public class MsgGetAchieve:MsgBase {
	public MsgGetAchieve() {protoName = "MsgGetAchieve";}
	//服务端回
	public int win = 0;
	public int lost = 0;
	public string nickName = "";
	public string headName = "";
}

//房间信息
[System.Serializable]
public class RoomInfo{
	public int id = 0;      //房间id
	public string map;      //地图名称
	public int count = 0;	//人数
	public int status = 0;	//状态0-准备中 1-战斗中
}

//请求房间列表
public class MsgGetRoomList:MsgBase {
	public MsgGetRoomList() {protoName = "MsgGetRoomList";}
	//服务端回
	public RoomInfo[] rooms;
}

//创建房间
public class MsgCreateRoom:MsgBase {
	public MsgCreateRoom() {protoName = "MsgCreateRoom";}
	//地图名称
	public string map;
	//服务端回
	public string roomID;
	public int result = 0;
}

//进入房间
public class MsgEnterRoom:MsgBase {
	public MsgEnterRoom() {protoName = "MsgEnterRoom";}
	//客户端发
	public int id = 0;
	//服务端回
	public string roomID;
	public int result = 0;
}


//玩家信息
[System.Serializable]
public class PlayerInfo{
	public string id = "lpy";   //账号
	public string nickname = "";//昵称
	public int camp = 0;		//阵营
	public int win = 0;			//胜利数
	public int lost = 0;		//失败数
	public int isOwner = 0;		//是否是房主
}

//获取房间信息
public class MsgGetRoomInfo:MsgBase {
	public MsgGetRoomInfo() {protoName = "MsgGetRoomInfo";}
	//服务端回
	public PlayerInfo[] players;
}

//离开房间
public class MsgLeaveRoom:MsgBase {
	public MsgLeaveRoom() {protoName = "MsgLeaveRoom";}
	//服务端回
	public int result = 0;
}

//开战
public class MsgStartBattle:MsgBase {
	public MsgStartBattle() {protoName = "MsgStartBattle";}
	public string map;      //地图名称
	//服务端回
	public int result = 0;
}

//客户端地图加载完成
public class MsgMapReady : MsgBase
{
	public MsgMapReady() { protoName = "MsgMapReady"; }
}