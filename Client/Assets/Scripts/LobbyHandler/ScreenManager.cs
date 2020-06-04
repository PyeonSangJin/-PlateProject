using UnityEngine;
using UnityEngine.UI;

//1440 2560
public class ScreenManager : MonoBehaviour
{
    private GameObject plate;
    private GameObject up_row, down_row;
    private GameObject side1, side2, side3, main, soup;
    private GameObject insert_name;
    private GameObject btn_start;
    private GameObject bottom_bar;
    private GameObject btn_home, btn_store, btn_setting;
    private GameObject searchEngine;

    private void Awake()
    {
        plate = GameObject.Find("Plate");
        up_row = GameObject.Find("up_row");
        down_row = GameObject.Find("down_row");
        side1 = GameObject.Find("side1");
        side2 = GameObject.Find("side2");
        side3 = GameObject.Find("side3");
        main = GameObject.Find("bread");
        soup = GameObject.Find("soup");
        insert_name = GameObject.Find("insert_name");
        btn_start = GameObject.Find("btn_start");
        bottom_bar = GameObject.Find("bottom_bar");
        btn_home = GameObject.Find("btn_home");
        btn_store = GameObject.Find("btn_store");
        btn_setting = GameObject.Find("btn_setting");
        searchEngine = GameObject.Find("SearchEngine");
    }
    void Start()
    {
        //1440 2560
        //1440 2560
        //1440 2560

        new Vector2((float)(Screen.width / 2.717), (float)(Screen.height / 7.11));

        plate.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -(float)(Screen.height / 3.66));
        plate.GetComponent<RectTransform>().sizeDelta = new Vector2((float)(Screen.width / 1.16), (float)(Screen.height / 2.84));
        up_row.GetComponent<RectTransform>().anchoredPosition = new Vector2(-(float)(Screen.width / 2.64), -(float)(Screen.height / 37.87));
        up_row.GetComponent<HorizontalLayoutGroup>().spacing = (float)(Screen.width / 28.8);
        down_row.GetComponent<RectTransform>().anchoredPosition = new Vector2(-(float)(Screen.width / 2.64), -(float)(Screen.height / 5.53));
        down_row.GetComponent<HorizontalLayoutGroup>().spacing = (float)(Screen.width / 48);

        side1.GetComponent<RectTransform>().sizeDelta = new Vector2((float)(Screen.width / 4.364), (float)(Screen.height / 7.7578));
        side2.GetComponent<RectTransform>().sizeDelta = new Vector2((float)(Screen.width / 4.364), (float)(Screen.height / 7.7578));
        side3.GetComponent<RectTransform>().sizeDelta = new Vector2((float)(Screen.width / 4.364), (float)(Screen.height / 7.7578));
        main.GetComponent<RectTransform>().sizeDelta = new Vector2((float)(Screen.width / 2.717), (float)(Screen.height / 7.11));
        soup.GetComponent<RectTransform>().sizeDelta = new Vector2((float)(Screen.width / 2.717), (float)(Screen.height / 7.11));

        insert_name.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        insert_name.GetComponent<RectTransform>().sizeDelta = new Vector2((float)(Screen.width / 1.4), (float)(Screen.height / 18.3));

        btn_start.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -(float)(Screen.height / 5.7));
        btn_start.GetComponent<RectTransform>().sizeDelta = new Vector2((float)(Screen.width / 1.16), (float)(Screen.height / 8.53));

        bottom_bar.GetComponent<RectTransform>().anchoredPosition = new Vector2(-(Screen.width / 2), (float)(Screen.height / 9.6));
        btn_home.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 3, (float)(Screen.height / 9.6));
        btn_store.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 3, (float)(Screen.height / 9.6));
        btn_setting.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width / 3, (float)(Screen.height / 9.6));

        searchEngine.GetComponent<RectTransform>().anchoredPosition = new Vector2(-(float)(Screen.width / 3.384), -(float)(Screen.height / 3.384) + (float)(Screen.height / 9.6)); // bottombar +
        searchEngine.GetComponent<RectTransform>().sizeDelta = new Vector2((float)(Screen.width / 1.69), (float)(Screen.height / 1.69) - (float)(Screen.height / 9.6)); // bottombar -
        //RectTransform s = searchEngine.GetComponent<RectTransform>();
        //s.offsetMin = new Vector2((float)(Screen.width / 4.3), s.offsetMin.y); //left
        //s.offsetMax = new Vector2(-(float)(Screen.width / 4.3), s.offsetMax.y); //right
        //s.offsetMax = new Vector2(s.offsetMax.x, -(float)(Screen.height / 4.3)); //top
        //s.offsetMin = new Vector2(s.offsetMin.x, (float)(Screen.height / 4.3+ Screen.height / 9.6 / 2)); //bottom
        //= new RectOffset((int)(Screen.width / 8.7), (int)(Screen.width / 8.7), (int)(Screen.height / 8.7), (int)(Screen.height / 8.7));
    }
}
