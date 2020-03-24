using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fortest : MonoBehaviour
{
    LoadBundle loadBundle;

    void Awake()
    {
        loadBundle = gameObject.AddComponent<LoadBundle>();
        StartCoroutine(loadBundle.SaveAssetBundleOnDisk());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}