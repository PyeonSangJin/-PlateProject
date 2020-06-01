using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    public GameObject spoon;
    Vector3 foodPos;

    // Start is called before the first frame update
    void Start()
    {
        foodPos = transform.position;

        // instantiate prefab
        spoon = Instantiate(Resources.Load<GameObject>("Prefabs/Spoon")) as GameObject;
        spoon.transform.localPosition = new Vector3(foodPos.x - 0.8f, foodPos.y + 1.3f, foodPos.z + 1.1f);
        spoon.SetActive(false);

        DontDestroyOnLoad(spoon);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        spoon.SetActive(!spoon.activeSelf);
    }
}
