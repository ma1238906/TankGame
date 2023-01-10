using UnityEngine;

public class ResManager : MonoBehaviour {

	//加载预设
	public static GameObject LoadPrefab(string path){
		return Resources.Load<GameObject>(path);
	}

	//加载资源
	public static T LoadAsset<T>(string path) where T : UnityEngine.Object
    {
		return Resources.Load<T>(path);
    }

	//释放未使用的资源
	public static void ReleaseUnusedAssets()
    {
		Resources.UnloadUnusedAssets();
		System.GC.Collect();
	}
}
