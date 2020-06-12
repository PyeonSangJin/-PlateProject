using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private GameObject foodnameField;

    private UnityEngine.UI.Text eatingFoodname;
    private Animator anim;
    private AudioSource audioSc;
    private AudioClip[] foodWordsVoice, fineVoice, encourageVoice;

    private List<string> foodWords;

    // Start is called before the first frame update
    void Start()
    {
        Random.InitState((int)(Time.realtimeSinceStartup * 100f));

        foodnameField = Instantiate(Resources.Load<GameObject>("Prefabs/foodnameField"));
        eatingFoodname = foodnameField.transform.GetChild(0).GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>();
        foodnameField.SetActive(false);

        anim = GetComponent<Animator>();
        audioSc = gameObject.AddComponent<AudioSource>();
        foodWords = Assets.Scripts.Config.FoodData.Instance.words;

        foodWordsVoice = new AudioClip[foodWords.Count];
        for (int i = 0; i < foodWordsVoice.Length; i++)
            foodWordsVoice[i] = Resources.Load<AudioClip>("Voice/foodWords/" + foodWords[i]);
        fineVoice = Resources.LoadAll<AudioClip>("Voice/fine");
        encourageVoice = Resources.LoadAll<AudioClip>("Voice/encouragement");
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
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || audioSc.isPlaying)
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
        if (Random.Range(0, 11) <= 7) // 70% 음식 이름 소리 출력
            audioSc.PlayOneShot(foodWordsVoice[foodId]);
        else // 30% 감탄 소리 출력
            audioSc.PlayOneShot(fineVoice[Random.Range(0, fineVoice.Length)]);

        // 음식 이름 출력
        eatingFoodname.text = foodWords[foodId];
        foodnameField.SetActive(true);
        Invoke("OffFoodnameField", 2);
    }

    public void OnMouseDown()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") || audioSc.isPlaying)
            return;

        // 식사 격려 소리 출력
        audioSc.PlayOneShot(encourageVoice[Random.Range(0, encourageVoice.Length)]);
    }
}