using UnityEngine;

namespace Assets.Scripts.Config
{
    public class FoodTransform
    {
        public Vector3[] pos; // 위치
        public Vector3 scale; // 크기

        public FoodTransform()
        {
            scale = new Vector3(1, 1, 1);

            pos = new Vector3[5];
            pos[0] = new Vector3(1.2f, -4.2f, -2.5f); // side1
            pos[1] = new Vector3(0, -4.2f, -2.5f); // side2
            pos[2] = new Vector3(-1.2f, -4.2f, -2.5f); // side3
            pos[3] = new Vector3(0.6f, -4.2f, -1.5f); // bread
            pos[4] = new Vector3(-0.6f, -4.2f, -1.5f); // soup
        }
    }
}