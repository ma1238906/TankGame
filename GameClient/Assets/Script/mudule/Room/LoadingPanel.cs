using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JEngine.Core;

/// <summary>
/// 地图加载面板
/// </summary>
public class LoadingPanel : BasePanel
{
    private Slider loadingProgree;//加载进度条

    public override void OnInit()
    {
        skinPath = "LoadingPanel";
        layer = PanelManager.Layer.Panel;
        NetManager.AddMsgListener("MsgEnterBattle", OnMsgEnterBattle);
    }

    public override void OnShow(params object[] para)
    {
        loadingProgree = skin.transform.Find("Slider").GetComponent<Slider>();
//#if UNITY_EDITOR
//        StartCoroutine(LoadingScene((string)para[0]));
//#else
        switch((string)para[0])
        {
            case "Autumn":
                LoadMapScene("Assets/HotUpdateResources/Scene/Autumn/Autumn.unity");
                break;
            case "ShaMo":
                LoadMapScene("Assets/HotUpdateResources/Scene/ShaMoYuLin/Demo/ShaMo.unity");
                break;
            case "YuLin":
                LoadMapScene("Assets/HotUpdateResources/Scene/ShaMoYuLin/Demo/YuLin.unity");
                break;
        }
//#endif
    }

    public override void OnClose()
    {
        NetManager.RemoveMsgListener("MsgEnterBattle", OnMsgEnterBattle);
    }

    private IEnumerator LoadingScene(string mapName)
    {
        var ao = SceneManager.LoadSceneAsync(mapName, LoadSceneMode.Additive);
        while(!ao.isDone)
        {
            loadingProgree.value = ao.progress;
            yield return null;
        }
        loadingProgree.value = 1;
        yield return new WaitForSeconds(0.5f);
        MsgMapReady msg = new MsgMapReady();
        NetManager.Send(msg);
    }

    /// <summary>
    /// 非编辑器情况加载bundle中的scene
    /// </summary>
    /// <param name="mapName"></param>
    private void LoadMapScene(string mapName)
    {
        AssetMgr.LoadSceneAsync(mapName, true,
            (progress) => {
                loadingProgree.value = progress;
            },
        (e) => {
            loadingProgree.value = 1;
            MsgMapReady msg = new MsgMapReady();
            NetManager.Send(msg);
        });

    }

    private void OnMsgEnterBattle(MsgBase msgBase)
    {
        Close();
    }
}