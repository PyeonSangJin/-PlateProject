using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScManager : MonoBehaviour
{
    private SimulSceneManager simulMng;

    void Awake()
    {
        simulMng = new SimulSceneManager();
    }

    public void LoadSimul()
    {
        simulMng.LoadScene();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
