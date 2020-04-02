using System.Collections;
using UnityEngine.Networking;
using UnityEngine;
using System.IO;

using Assets.Scripts.Config;

public class LoadBundle : MonoBehaviour
{
    public string[] assetBundleNames;

    public IEnumerator SaveAssetBundleOnDisk() {
        string uri = Config.MAIN_URL + Config.GET_PPL;

        UnityWebRequest request = UnityWebRequest.Get(uri);
        yield return request.SendWebRequest();

        string assetBundleDirectory = "Assets/StreamingAssets";

        if (!Directory.Exists(assetBundleDirectory)) {
            Directory.CreateDirectory(assetBundleDirectory);
        }

        FileStream fs = new FileStream(assetBundleDirectory + "/" + "pplbundle", System.IO.FileMode.Create);
        //fs.Write(request.downloadHandler.data, 0, (int)request.downloadedBytes);

        for (ulong i = 0; i < request.downloadedBytes; i++)
        {
            fs.WriteByte(request.downloadHandler.data[i]);
            // 저장 진척도 표시
            //if ((ulong)(((float)i/ (float)request.downloadedBytes) * 100) % 5 == 0 )
            //    Debug.Log((((float)i / (float)request.downloadedBytes) * 100) + "%");
        }

        fs.Close();
        yield return LoadAssetFromLocalDisk();
    }

    public IEnumerator LoadAssetFromLocalDisk() {

        var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "pplbundle"));

        if (myLoadedAssetBundle == null)
        {
            Debug.Log("번들 로드 실패당 ㅎ");
            yield break;
        }
        else  
            Debug.Log("번들 로드 성공했숭 ㅎ");
        

        //ppl 개수 , ppl gameobject 이름
        for (var i = 1; i <= 3; i++) {
            var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("ppl" + i);
            Instantiate(prefab, new Vector3(0, 0, 15), Quaternion.identity);
        }
    }
}