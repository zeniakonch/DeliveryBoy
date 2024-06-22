using System.Collections.Generic;
using OrdersSystem;
using Player;
using ServiceLocatorSystem;
using UnityEngine;

namespace SceneManagement
{
    [RequireComponent(typeof(Collider2D))]
    public class SceneMover : MonoBehaviour
    {
        [SerializeField] private Transform spawnTransform;
        [SerializeField] private Location showLocation;
        
        [field: SerializeField] public Location HideLocation { get; private set; }

        private PlayerScript _player;
        private SceneManager _sceneManager;
        private OrderController _orderController;

        private void Start()
        {
            _player = ServiceLocator.Instance.Get<PlayerScript>();
            _sceneManager = ServiceLocator.Instance.Get<SceneManager>();
            _orderController = ServiceLocator.Instance.Get<OrderGenerator>().OrderController;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                foreach (var obj in showLocation.objects)
                {
                    obj.gameObject.SetActive(true);
                }

                foreach (var obj in HideLocation.objects)
                {
                    obj.gameObject.SetActive(false);
                }

                _sceneManager.currentLocation = showLocation;
                _player.transform.position = spawnTransform.position;
                _orderController.UpdateArrow();
            }
        }
    }
}