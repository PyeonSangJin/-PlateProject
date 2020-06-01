using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Entity Class

namespace Assets.Scripts
{
    public class SelectedFood
    {
        private static SelectedFood instance = null;

        private string[] foodList;

        private SelectedFood()
        {
            foodList = new string[5];
            for (int i = 0; i < 5; i++) foodList[i] = "";
        }

        public static SelectedFood getInstance()
        {
            if (instance == null)
            {
                instance = new SelectedFood();
            }
            return instance;
        }

        // Getter
        public string[] GetFoodList()
        {
            return foodList;
        }

        // Setter like
        public void SetFood(string plate, string food)
        {
            switch (plate)
            {
                case "side1":
                    foodList[0] = food;
                    break;
                case "side2":
                    foodList[1] = food;
                    break;
                case "side3":
                    foodList[2] = food;
                    break;
                case "bread":
                    foodList[3] = food;
                    break;
                case "soup":
                    foodList[4] = food;
                    break;
            }
        }
    }
}