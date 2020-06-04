using Assets.Scripts;
using Assets.Scripts.Config;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimulSceneManager : MonoBehaviour
{
    public static SimulSceneManager instance = null;

    private FoodTransform foodTr;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void LoadFood()
    {
        string curFood;

        for (int i = 0; i < 5; i++)
        {
            curFood = SelectedFood.getInstance().GetFoodList()[i];
 
            try
            {
                if (curFood.Equals("")) continue;
                // instantiate prefab
                GameObject foodObject = Instantiate(Resources.Load<GameObject>("Prefabs/" + curFood)) as GameObject;
                // setPosition & size
                foodObject.transform.localScale = foodTr.scale;
                foodObject.transform.localPosition = foodTr.pos[i];
                foodObject.AddComponent<MouseEvent>();

                DontDestroyOnLoad(foodObject);
            }
            catch (Exception e)
            {
                Debug.Log(curFood + ":is not available");
                Debug.Log(e.Message);
            }
        }
    }
    
    public void LoadScene()
    {
        foodTr = new FoodTransform();
        LoadFood();
        SceneManager.LoadScene("Simulation");
    }
}