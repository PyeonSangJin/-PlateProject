using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Config
{
    class FoodData
    {
        public const string TrieChild = "돼지불백김치찌게고기검은";
        public List<string> words;

        public FoodData()
        {
            words = new List<string>(new string[] {
                   "돼지불백",
                   "돼지김치찌게",
                   "김치찌게",
                   "돼지불고기",
                   "검은돼지불고기",

                   //reverse
                   //"백불지돼",
                   //"게찌치김지돼",
                   //"게찌치김",
                   //"기고불지돼",
                   //"기고불지돼은검"
            });
        }




    }
}
