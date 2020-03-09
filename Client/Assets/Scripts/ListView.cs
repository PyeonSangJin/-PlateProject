using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Listview : MonoBehaviour
{
    List<string> list;
    public GameObject winnerPop;
    public Text noRecordLabel;
    public Transform scrollContentView;
    public GameObject contentDataPanel;

    private void Awake()
    {
        winnerPop = transform.Find("SearchEngine").GetComponent<GameObject>();
        noRecordLabel = gameObject.transform.GetChild(4).GetChild(2).GetComponent<Text>(); //NOTFOUND
        scrollContentView = gameObject.transform.GetChild(4).GetChild(0).GetChild(0).GetChild(0); //Content
        contentDataPanel = Resources.Load<GameObject>("Prefabs/lobby_list");
    }

    //Winnder popup
    public void setWinnerListData(List<string> menus) {
        list = menus;
    }

    public void winnerPopupInitialized() {

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
            }
        }
        else {
            noRecordLabel.gameObject.SetActive(true);
        }
    }

    public void hideWinnerListPopUp() {
        winnerPop.gameObject.SetActive(false);
    }
    public void showWinnerListPopUp()
    {
        winnerPop.gameObject.SetActive(true);
    }

}
