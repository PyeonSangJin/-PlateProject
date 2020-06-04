using System.Collections.Generic;
using UnityEngine;

public class MouseEvent : MonoBehaviour
{
    private List<string> foodWords;

    private Vector3 foodPos;
    private int foodLoc = 0;
    private int foodId = -1;

    // Start is called before the first frame update
    void Start()
    {
        foodWords = Assets.Scripts.Config.FoodData.Instance.words;
        for (int i = 0; i < foodWords.Count; i++)
            if (name.Split('(')[0].Equals(foodWords[i]))
            {
                foodId = i;
                break;
            }

        foodPos = transform.position;
        RecognizeFood();
    }

    private void RecognizeFood()
    {
        if (foodPos.z < -2f) // -2.5f
        {
            if (foodPos.x > 1f) // 1.2f
                foodLoc = 1;
            else if (foodPos.x == 0)
                foodLoc = 2;
            else // foodPos.x == -1.2f
                foodLoc = 3;
        }
        else // -1.5f
        {
            if (foodPos.x > 0)
                foodLoc = 4;
            else
                foodLoc = 5;
        }
    }

    public void OnMouseDown()
    {
        GameObject.Find("Kid").GetComponent<CharacterManager>().PlayEatAnim(foodId, foodLoc);
    }
}
