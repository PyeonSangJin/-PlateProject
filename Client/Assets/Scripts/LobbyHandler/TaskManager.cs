using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.LobbyHandler
{
    public class TaskManager: MonoBehaviour
    {
        private PlateConfig plateConfig;
        private Listview listview;
        private SearchConfig searchConfig;
        private ChangeScene changeScene;
        private SelectedFood selectedFood;

        private Button b_obj;
        private GameObject food;
        private void Awake()
        {
            plateConfig = gameObject.AddComponent<PlateConfig>(); //new PlateConfig();
            listview = gameObject.AddComponent<Listview>();
            searchConfig = gameObject.AddComponent<SearchConfig>();
            changeScene = gameObject.AddComponent<ChangeScene>();
            selectedFood = SelectedFood.getInstance();

            searchConfig.setListview(listview, searchConfig, this);
            plateConfig.PlateButtonListener(searchConfig, this);
        }

        public void SetButton(Button obj)
        {
            b_obj = obj;
        }

        public void LoadSelectedFood(string foodName) {
            if (!b_obj) return;

            for (var i = b_obj.transform.childCount - 1; i >= 0; i--)
                Destroy(b_obj.transform.GetChild(i).gameObject);

            food = Resources.Load<GameObject>("Prefabs/" + foodName);
            GameObject userImages = Instantiate(food);
            userImages.transform.SetParent(b_obj.transform);
            userImages.transform.localPosition = new Vector3(0, 0, 0);
            userImages.transform.localScale = new Vector3(b_obj.GetComponent<RectTransform>().sizeDelta.x, b_obj.GetComponent<RectTransform>().sizeDelta.y, 1);

            selectedFood.SetFood(b_obj.name, foodName);
        }


    }
}
