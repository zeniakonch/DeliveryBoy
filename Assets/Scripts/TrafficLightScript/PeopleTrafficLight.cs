using UnityEngine;

namespace TrafficLightScript
{
    [RequireComponent(typeof(Animator))]
    public class PeopleTrafficLight: MonoBehaviour
    {
        [SerializeField]
        private TrafficLight trafficLight;

        private Animator _animator;
        private static readonly int ChangeColor = Animator.StringToHash("ChangeColor");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            trafficLight.OnChangeCurrentColor.AddListener(ChangeCurrentColor);
        }

        private void ChangeCurrentColor()
        {
            if (trafficLight.CurrentColor != Color.Orange)
            {
                ToggleColor();
            }
        }

        private void ToggleColor()
        {
            _animator.SetTrigger(ChangeColor);
        }
    }
}
