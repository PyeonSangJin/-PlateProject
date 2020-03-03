using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateConfig : MonoBehaviour
{
    private Button side1, side2, side3;
    private Button bread, soup;
    private GameObject searchEngine;

    private void Awake()
    {
        side1 = GetComponent<Button>();
        side2 = GetComponent<Button>();
        side3 = GetComponent<Button>();
        bread = GetComponent<Button>();
        soup = GetComponent<Button>();
        searchEngine = GameObject.Find("SearchEngine");
        searchEngine.SetActive(false);
    }

    void Start()
    {
        side1 = GameObject.Find("side1").GetComponent<Button>();
        side2 = GameObject.Find("side2").GetComponent<Button>();
        side3 = GameObject.Find("side3").GetComponent<Button>();
        bread =GameObject.Find("main").GetComponent<Button>();
        soup = GameObject.Find("soup").GetComponent<Button>();

        side1.onClick.AddListener(delegate () { SearchEngine(); });
        side2.onClick.AddListener(delegate () { SearchEngine(); });
        side3.onClick.AddListener(delegate () { SearchEngine(); });
        bread.onClick.AddListener(delegate () { SearchEngine(); });
        soup.onClick.AddListener(delegate () { SearchEngine(); });
    }

    public void SearchEngine() {
        searchEngine.SetActive(true);
    }
}
