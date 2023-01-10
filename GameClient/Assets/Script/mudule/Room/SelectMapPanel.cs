using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 地图选择对话框
/// </summary>
public class SelectMapPanel : BasePanel
{
    public override void OnInit()
    {
        skinPath = "SelectMapPanel";
        layer = PanelManager.Layer.Panel;
    }

    public override void OnShow(params object[] para)
    {
        //消息监听
        NetManager.AddMsgListener("MsgCreateRoom", OnMsgCreateRoom);
        //为地图按钮添加点击事件
        Button[] mapBtns = skin.GetComponentsInChildren<Button>();
        foreach(Button btn in mapBtns)
        {
            btn.onClick.AddListener(() =>
            {
                MsgCreateRoom msg = new MsgCreateRoom();
                msg.map = btn.gameObject.name;
                NetManager.Send(msg);
            });
        }
    }

    public override void OnClose()
    {
        NetManager.RemoveMsgListener("MsgCreateRoom", OnMsgCreateRoom);
    }

    /// <summary>
    /// 接收创建房间 服务器返回事件
    /// </summary>
    private void OnMsgCreateRoom(MsgBase msgBase)
    {
        MsgCreateRoom msg = (MsgCreateRoom)msgBase;
        //成功创建房间
        if (msg.result == 0)
        {
            PanelManager.Close("RoomListPanel");
            PanelManager.Open<RoomPanel>();
            Close();
            //加入语音房间
            ChatManager.EnterRoom(msg.roomID);
        }
        //创建房间失败
        else
        {
            PanelManager.Open<TipPanel>("创建房间失败");
        }
    }
}
