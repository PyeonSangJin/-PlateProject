using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateConfig : MonoBehaviour
{
    private Button side1, side2, side3;
    private Button bread, soup;

    private SearchConfig Search;

    private void Awake()
    {
        side1 = GetComponent<Button>();
        side2 = GetComponent<Button>();
        side3 = GetComponent<Button>();
        bread = GetComponent<Button>();
        soup = GetComponent<Button>();

        Search = this.gameObject.AddComponent<SearchConfig>(); //new SearchConfig();
    }

    void Start()
    {
        side1 = GameObject.Find("side1").GetComponent<Button>();
        side2 = GameObject.Find("side2").GetComponent<Button>();
        side3 = GameObject.Find("side3").GetComponent<Button>();
        bread =GameObject.Find("main").GetComponent<Button>();
        soup = GameObject.Find("soup").GetComponent<Button>();

        side1.onClick.AddListener(delegate () { Search.Active(true); });
        side2.onClick.AddListener(delegate () { Search.Active(true); });
        side3.onClick.AddListener(delegate () { Search.Active(true); });
        bread.onClick.AddListener(delegate () {Search.Active(true); });
        soup.onClick.AddListener(delegate () { Search.Active(true); });
    }
}
