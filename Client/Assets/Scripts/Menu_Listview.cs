using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class Menu_Listview : MonoBehaviour
{
    List<string> list;
    public GameObject winnerPop;
    public Text noRecordLabel;
    public GameObject scrollContentView;
    public GameObject contentDataPanel;

    void Awake() {
        setWinnerListData();
        winnerPopupInitialized();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Winnder popup
    void setWinnerListData() {
        list = new List<string>();
        for (int i = 0; i < 15; i++) {
            list.Add("반찬이당 ㅎ" + i);
        }
    }

    void winnerPopupInitialized() {
        if (list.Count > 0)
        {
            noRecordLabel.gameObject.SetActive(false);
            RectTransform rt = (RectTransform)scrollContentView.transform;
            for (int i = 0; i < list.Count; i++)
            {
                string value = list[i];
                GameObject userImages = (GameObject)Instantiate(contentDataPanel);
                //userImages.GetComponent<userImages>().sprite = value;
                //userImages.GetComponent < RectTransform().sizeDelta = new Vector2(rt.rect.height - 6, rt.rect.height - 6);
                userImages.transform.SetParent(scrollContentView.transform);
                userImages.transform.localScale = new Vector3(1, 1, 1);
                userImages.transform.localPosition = new Vector3(0, 0, 0);
                userImages.transform.Find("Text").GetComponent<Text>().text = i +  ". " + value;
                //userImages.GetComponent<Button>().onClick.AddListener(() => { guestUsersSelection(value); });
            }
        }
        else {
            noRecordLabel.gameObject.SetActive(false);
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
