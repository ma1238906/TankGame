using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GME;
using System;

public class ChatManager
{
    //来自 腾讯云控制台 的 GME 服务提供的 AppID
    static string sdkAppId = "1400784392";
    //openID 只支持 Int64 类型（转为 string 传入），规则由 App 开发者自行制定，App 内不重复即可。
    public static string openID = "";
    //权限密钥
    static string key = "OcZHitnRovlJceQv";
    public static void InitGME()
    {
        //使用时间戳作为openID
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        openID = Convert.ToInt64(ts.TotalMilliseconds).ToString();

        int ret = ITMGContext.GetInstance().Init(sdkAppId, openID);
        //通过返回值判断是否初始化成功
        if (ret != QAVError.OK)
        {
            Debug.Log("SDK初始化失败:" + ret);
            return;
        }
        //对事件进行监听：
        ITMGContext.GetInstance().OnEnterRoomCompleteEvent += new QAVEnterRoomComplete(OnEnterRoomComplete);
        ITMGContext.GetInstance().OnExitRoomCompleteEvent += new QAVExitRoomComplete(OnExitRoomComplete);
    }
    public static void Update()
    {
        ITMGContext.GetInstance().Poll();
    }

    //进入房间
    public static void EnterRoom(string roomID)
    {
        byte[] byteAuthbuffer = QAVAuthBuffer.GenAuthBuffer(int.Parse(sdkAppId), roomID, openID, key);
        ITMGContext.GetInstance().EnterRoom(roomID, ITMGRoomType.ITMG_ROOM_TYPE_STANDARD, byteAuthbuffer);
    }

    //退出房间
    public static void ExitRoom()
    {
        ITMGContext.GetInstance().ExitRoom();
    }

    //进入房间成功事件监听处理
    static void OnEnterRoomComplete(int err, string errInfo)
    {
        if (err != 0)
        {
            Debug.Log("错误码:" + err + " 错误信息:" + errInfo);
            return;
        }
        else
        {
            //进房成功
            //打开麦克风
            ITMGContext.GetInstance().GetAudioCtrl().EnableMic(true);
            //打开扬声器
            ITMGContext.GetInstance().GetAudioCtrl().EnableSpeaker(true);
        }
    }

    //退出房间成功事件监听处理
    static void OnExitRoomComplete()
    {
        //退出房间后的处理
    }
}
