using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    private Vector3 foodPos;
    private int foodNum = 0;

    // Start is called before the first frame update
    void Start()
    {
        foodPos = transform.position;
        RecognizeFood();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void RecognizeFood()
    {
        if (foodPos.z < -2f) // -2.5f
        {
            if (foodPos.x > 1f) // 1.2f
                foodNum = 1;
            else if (foodPos.x == 0)
                foodNum = 2;
            else // foodPos.x == -1.2f
                foodNum = 3;
        }
        else // -1.5f
        {
            if (foodPos.x > 0)
                foodNum = 4;
            else
                foodNum = 5;
        }
    }

    public void OnMouseDown()
    {
        GameObject.Find("Kid").GetComponent<CharacterManager>().AnimEat(foodNum);
    }
}
