using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private Button btn_start;

    private void Awake()
    {
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
        

}
