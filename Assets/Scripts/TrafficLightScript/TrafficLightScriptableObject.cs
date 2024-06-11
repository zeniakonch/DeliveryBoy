using UnityEngine;

namespace TrafficLightScript
{
    [CreateAssetMenu(fileName = "NewTrafficLight", menuName = "Game/CreateTrafficLight")]
    public class TrafficLightScriptableObject : ScriptableObject
    {
        [Range(1, 40)]
        public float timeRed;
        
        [Range(1, 40)]
        public float timeOrange;
        
        [Range(1, 40)]
        public float timeGreen;
    }
}
