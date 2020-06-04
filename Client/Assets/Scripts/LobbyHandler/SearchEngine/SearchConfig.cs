using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts.Config;
using System.Collections.Generic;
using Assets.Scripts.LobbyHandler;

public class SearchConfig : MonoBehaviour
{
    private GameObject searchEngine;
    private InputField tv_search;

    private FoodData foodData;
    private TRIE trie;
    private TRIE.Node root;

    private Listview listview;
    private List<string> selectedMenus;

   // private string picked;
    private TaskManager parent;

    public string PickedMenu
    {
      //  get { return picked; }
        set {
            //picked = value;
            parent.LoadSelectedFood(value);
            Active(false);
        }
    }

    public void setListview(Listview l, SearchConfig s, TaskManager t)
    {
        listview = l;
        listview.setParent(s);
        parent = t;
    }

    private void Awake()
    {
        searchEngine = GameObject.Find("SearchEngine");
        tv_search = GameObject.Find("tv_search").GetComponent<InputField>();
    }

    private void Start()
    {
        //inital
        foodData = FoodData.Instance;
        trie = new TRIE();
        root = trie.Root;

        selectedMenus = new List<string>();

        //setting
        trie.insert(foodData.words);
        tv_search.onValueChanged.AddListener(TextUpdated);

        Active(false);
    }

    public void TextUpdated(string str)
    {
        selectedMenus.Clear();
        TRIE.Node node = trie.find(root, str);
        if (node == null) return;

        for (int i = 0; i < node.m_idx.Count; i++)
        {
            int retIdx = node.m_idx[i];
            selectedMenus.Add(foodData.words[retIdx]);
        }

        listview.setData(selectedMenus);
        listview.printData();
    }


    public void Active(bool flag)
    {
        searchEngine.SetActive(flag);
    }
}
