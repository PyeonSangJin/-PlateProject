using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            anim.SetBool("EatSide1B", false);
            anim.SetBool("EatSide2B", false);
            anim.SetBool("EatSide3B", false);
            anim.SetBool("EatBreadB", false);
            anim.SetBool("EatSoupB", false);
        }
    }

    public void AnimEat(int n) {
        switch (n)
        {
            case 1:
                anim.SetBool("EatSide1B", true);
                break;
            case 2:
                anim.SetBool("EatSide2B", true);
                break;
            case 3:
                anim.SetBool("EatSide3B", true);
                break;
            case 4:
                anim.SetBool("EatBreadB", true);
                break;
            case 5:
                anim.SetBool("EatSoupB", true);
                break;
            default:
                Debug.Log("Eat animation is not working");
                break;
        }
    }
}
