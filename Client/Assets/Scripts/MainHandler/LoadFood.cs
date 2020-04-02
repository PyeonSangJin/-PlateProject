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
                var name = ChangeScene.name[i];
                if (name == null || name.Equals("") || name.Equals(null)) continue;

                food = Resources.Load<GameObject>("Prefabs/" + ChangeScene.name[i]);
                GameObject userImages = Instantiate(food);

                //위치 크기 조절여기서 하면 됩니다.
                //0번 side1
                //1번 side2
                //2번 side3
                //3번 bread
                //4번 soup

                //userImages.transform.SetParent(b_obj.transform);
                userImages.transform.localPosition = new Vector3(0, 0, 0);
                //userImages.transform.localScale = new Vector3(b_obj.GetComponent<RectTransform>().sizeDelta.x, b_obj.GetComponent<RectTransform>().sizeDelta.y, 1);

            }catch (Exception e) {
                Debug.Log(name + ":is not available");
                continue;                
            }

        }
    }

}
