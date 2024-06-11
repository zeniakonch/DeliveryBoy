using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace TrafficLightScript
{
    [RequireComponent(typeof(Animator))]
    public class TrafficLight : MonoBehaviour
    {
        [SerializeField] public TrafficLightScriptableObject trafficLightSettings;

        private Animator _animator;
        private bool _isWait = false;
        private bool _isInteracted = false;
        private bool _canInteract = true;
        private float _temporaryTime;
        public UnityEvent OnChangeCurrentColor { get; private set; } = new UnityEvent();
        public Color CurrentColor { get; private set; } = Color.Red;
        private static readonly int ChangeColor = Animator.StringToHash("ChangeColor");
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        private void Update()
        {
            if (!_isWait)
            {
                StartCoroutine(ToggleColor());
            }
        }
        private IEnumerator ToggleColor()
        {
            yield return WaitNextColor();
            CurrentColor = ColorsOperations.GetNextColor(CurrentColor);
            _animator.SetTrigger(ChangeColor);
            OnChangeCurrentColor.Invoke();
            _canInteract = true;
        }
        private IEnumerator WaitNextColor()
        {
            _isWait = true;
            if (_isInteracted && CurrentColor == Color.Green)
            {
                _isInteracted = false;
                yield return new WaitForSeconds(_temporaryTime);
            }
            else
            {
                yield return new WaitForSeconds(ColorsOperations.GetColorTime(trafficLightSettings, CurrentColor));
            }
            _isWait = false;
        }
        public void SetTemporaryTime(float time)
        {
            if (_canInteract)
            {
                _temporaryTime = time;
                _isInteracted = true;
                _canInteract = false;
                Debug.Log("Кнопка для переключения светофора была нажата. Новое время: " + time);
            }
        }
    }
}
