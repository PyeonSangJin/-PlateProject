using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchConfig : MonoBehaviour
{
    private InputField search;

    private void Awake()
    {
        //        side1 = GetComponent<Button>();
        search = GameObject.Find("search").GetComponent<InputField>();
    }

    private void Start() {
        search.onValueChanged.AddListener(TextUpdated);
        //search.onEndEdit.AddListener(TextUpdated);
    }

    public void TextUpdated(string str) {
        Debug.Log("OUTOUTOUTOUT : " + str);
    }
}
