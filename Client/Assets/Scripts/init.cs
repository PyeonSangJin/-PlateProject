using UnityEngine;
using Newtonsoft.Json.Linq;

namespace Assets.Scripts
{
    class Init : MonoBehaviour
    {
        private NetworkUtility networkUtility;

        private void Awake()
        {
            networkUtility = new NetworkUtility();
            JObject json = new JObject();
            json.Add("ipaddr", networkUtility.GetLocalIP());
            json.Add("userId", "M_Chang");

            Debug.Log(json.ToString());
            Debug.Log(networkUtility.HTTP_POST(json, Config.Config.POST_LOG));
        }
    }
}
