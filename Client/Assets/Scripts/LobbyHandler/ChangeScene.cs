using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    static public string[] name;
    private Button btn_start;

    private void Awake()
    {
        name = new string[5];
        for (int i = 0; i < 5; i++) name[i] = "";
        btn_start = GetComponent<Button>();
    }

    private void Start()
    {
        btn_start = GameObject.Find("btn_start").GetComponent<Button>();
        btn_start.onClick.AddListener(delegate () { ChangeSceneStart(); });
    }

    private void ChangeSceneStart() {
        SceneManager.LoadScene("Main");
    }

    public void SetFood(string plate, string food)
    {
        switch (plate)
        {
            case "side1":
                name[0] = food;
                break;
            case "side2":
                name[1] = food;
                break;
            case "side3":
                name[2] = food;
                break;
            case "bread":
                name[3] = food;
                break;
            case "soup":
                name[4] = food;
                break;
        }
    }

}
