using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private GameObject foodnameField;

    private UnityEngine.UI.Text eatingFoodname;

    private Animator anim;
    private AudioSource[] audioSc;
    private List<string> foodWords;
    private int audioScSize;

    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Random.InitState((int)(Time.realtimeSinceStartup * 100f));

        foodnameField = Instantiate(Resources.Load<GameObject>("Prefabs/foodnameField"));
        eatingFoodname = foodnameField.transform.GetChild(0).GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>();
        foodnameField.SetActive(false);
        //DontDestroyOnLoad(foodnameField);

        anim = GetComponent<Animator>();
        foodWords = Assets.Scripts.Config.FoodData.Instance.words;

        audioSc = new AudioSource[audioScSize = foodWords.Count + 2];
        for (int i = 0; i < audioScSize; i++)
            audioSc[i] = gameObject.AddComponent<AudioSource>();
        for (int i = 0; i < foodWords.Count; i++)
            audioSc[i].clip = Resources.Load<AudioClip>("Voice/" + foodWords[i]);
        audioSc[foodWords.Count].clip = Resources.Load<AudioClip>("Voice/reallyDelicious");
        audioSc[foodWords.Count + 1].clip = Resources.Load<AudioClip>("Voice/tasteIsBest");
    }

    private IEnumerator OneshotAnim()
    {
        yield return new WaitForEndOfFrame();

        anim.SetBool("EatSide1B", false);
        anim.SetBool("EatSide2B", false);
        anim.SetBool("EatSide3B", false);
        anim.SetBool("EatBreadB", false);
        anim.SetBool("EatSoupB", false);
    }

    private void OffFoodnameField()
    {
        foodnameField.SetActive(false);
    }

    public void PlayEatAnim(int foodId, int foodLoc)
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            return;

        // 애니메이션 실행
        switch (foodLoc)
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
        StartCoroutine(OneshotAnim());

        // 소리 출력
        if (UnityEngine.Random.Range(0, 11) <= 7) // 70% 음식 이름 소리 출력
            audioSc[foodId].Play();
        else // 30% 식사 독려 소리 출력
            audioSc[UnityEngine.Random.Range(5, 7)].Play();

        // 음식 이름 출력
        eatingFoodname.text = foodWords[foodId];
        foodnameField.SetActive(true);
        Invoke("OffFoodnameField", 2);
    }
}