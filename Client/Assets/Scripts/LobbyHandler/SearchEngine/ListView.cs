using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Listview : MonoBehaviour
{
    private List<string> list;
    private Text noRecordLabel;
    private Transform scrollContentView;
    private GameObject contentDataPanel;

    private SearchConfig parent;

    private void Awake()
    {
        noRecordLabel = gameObject.transform.GetChild(5).GetChild(2).GetComponent<Text>(); //NOTFOUND
        scrollContentView = gameObject.transform.GetChild(5).GetChild(0).GetChild(0).GetChild(0); //Content
        contentDataPanel = Resources.Load<GameObject>("Prefabs/lobby_list");
        noRecordLabel.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, (float)(Screen.height / 32));
    }
    public void setParent(SearchConfig s) {
        parent = s;
    }

    public void setData(List<string> menus) {
        list = menus;
    }

    public void printData() {

        for (var i = scrollContentView.childCount - 1; i >= 0; i--) {
            Destroy(scrollContentView.GetChild(i).gameObject);
        }

        if (list.Count > 0)
        {
            noRecordLabel.gameObject.SetActive(false);
            for (int i = 0; i < list.Count; i++)
            {
                string value = list[i];
                GameObject userImages = Instantiate(contentDataPanel);
                userImages.transform.SetParent(scrollContentView);
                userImages.transform.localScale = new Vector3(1, 1, 1);
                userImages.transform.localPosition = new Vector3(0, 0, 0);
                userImages.transform.Find("Text").GetComponent<Text>().text = i +  ". " + value;

                Button btn = userImages.GetComponent<Button>();
                btn.onClick.AddListener(delegate () {
                    parent.PickedMenu = value;
                });

            }
        }
        else {
            noRecordLabel.gameObject.SetActive(true);
        }
    }

}
