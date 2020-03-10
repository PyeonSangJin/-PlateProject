using Assets.Scripts.LobbyHandler;
using UnityEngine;
using UnityEngine.UI;

public class PlateConfig : MonoBehaviour
{
    private Button side1, side2, side3;
    private Button bread, soup;

    private void Awake()
    {
        side1 = GameObject.Find("side1").GetComponent<Button>();
        side2 = GameObject.Find("side2").GetComponent<Button>();
        side3 = GameObject.Find("side3").GetComponent<Button>();
        bread = GameObject.Find("main").GetComponent<Button>();
        soup = GameObject.Find("soup").GetComponent<Button>();
    }

    public void PlateButtonListener(SearchConfig s, TaskManager parent)
    {
        side1.onClick.AddListener(delegate () { s.Active(true); parent.SetButton(side1); });
        side2.onClick.AddListener(delegate () { s.Active(true); parent.SetButton(side2); });
        side3.onClick.AddListener(delegate () { s.Active(true); parent.SetButton(side3); });
        bread.onClick.AddListener(delegate () { s.Active(true); parent.SetButton(bread); });
        soup.onClick.AddListener(delegate () { s.Active(true); parent.SetButton(soup); });
    }
}
