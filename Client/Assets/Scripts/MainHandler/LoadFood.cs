using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFood : MonoBehaviour
{
    private GameObject food;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            try{
                //Debug.Log(name[i]);
                if (name[i] == null || name[i].Equals("") || name[i].Equals(null)) continue;
                food = Resources.Load<GameObject>("Prefabs/" + ChangeScene.name[i]);
                GameObject userImages = Instantiate(food);
                //userImages.transform.SetParent(b_obj.transform);
                userImages.transform.localPosition = new Vector3(0, 0, 0);
                //userImages.transform.localScale = new Vector3(b_obj.GetComponent<RectTransform>().sizeDelta.x, b_obj.GetComponent<RectTransform>().sizeDelta.y, 1);
            }catch (Exception e) {
                Debug.Log(name[i] + ":is not available");
                continue;                
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
