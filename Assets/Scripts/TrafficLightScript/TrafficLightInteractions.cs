using UnityEngine;

namespace TrafficLightScript
{

    public class TrafficLightInteraction : MonoBehaviour
    {
        [SerializeField]
        private TrafficLight trafficLight;

        [SerializeField] private float reducedTime = 1f;
        [SerializeField] private Transform playerTransform;
        [SerializeField] private float interactionRadius = 2f;

        // void Update()
        // {
        //     if (Input.GetKeyDown(KeyCode.E))
        //     {
        //         InteractedWithTrafficLight();
        //     }
        // }
        
        // ReSharper disable Unity.PerformanceAnalysis
        public void InteractedWithTrafficLight()
        {
            if (Vector3.Distance(playerTransform.position, trafficLight.transform.position) <= interactionRadius)
            {
                trafficLight.SetTemporaryTime(reducedTime);
            }
            else
            {
                Debug.Log("Вы слишком далеко от светофора для взаимодействия.");
            }
        }
    }
}
