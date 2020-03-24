using UnityEngine;
using UnityEditor;
using System.Diagnostics;
using System.IO;

public class BuildAsssetBundles : MonoBehaviour {
    /***********************************************************************
     * 용도 : MenuItem을 사용하면 메뉴창에 새로운 메뉴를 추가할 수 있습니다.
     * (아래의 코드에서는 Bundles 항목에 하위 항목으로 Build AssetBundles 항목을 추가.) 
     ***********************************************************************/
#if UNITY_EDITOR
    //[MenuItem("Bundles/Build AssetBundles")]
    //static void BuildAllAssetBundles() {
    //    /***********************************************************************
    //     * 이름 : BuildPipeLine.BuildAssetBundles() 
    //     * 용도 : BuildPipeLine 클래스의 함수 BuildAssetBundles()는 에셋번들을 만들어줍니다. 
    //     * 매개변수에는 String 값을 넘기게 되며, 빌드된 에셋 번들을 저장할 경로입니다. 
    //     * 예를 들어 Assets 하위 폴더에 저장하려면 "Assets/AssetBundles"로 입력해야합니다. 
    //     ***********************************************************************/
    //    // target 용도에 맞게 바꿔야함 

    //    BuildPipeline.BuildAssetBundles(
    //        "Assets/AssetBundles",
    //        BuildAssetBundleOptions.None,
    //        BuildTarget.StandaloneWindows
    //        );
    //}


    [MenuItem("Bundles/Build AssetBundles")]
    static public void BuildNeedAssetBundle()
    {
        string bundleName = "pplbundle222";
        if (!Directory.Exists(Application.dataPath + "/AssetBundles"))
        {
            Directory.CreateDirectory(Application.dataPath + "/AssetBundles");
        }

        AssetBundleBuild[] buildBundles = new AssetBundleBuild[1];

        buildBundles[0].assetBundleName = bundleName;
        buildBundles[0].assetNames = AssetDatabase.GetAssetPathsFromAssetBundle(bundleName);

        BuildPipeline.BuildAssetBundles(
            Application.dataPath + "/AssetBundles", // 빌드된 에셋 번들이 생성될 경로
            buildBundles, // 빌드할 에셋 번들들의 정보
            BuildAssetBundleOptions.None,  // 에셋 번들 빌드 옵션
            BuildTarget.StandaloneWindows// 에셋 번들의 타겟 플랫폼
            );

    }

#endif



}

