using System;
using System.Collections.Generic;
using ServiceLocatorSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace SceneManagement
{
    public class SceneManager : MonoBehaviour, IService
    {
        [SerializeField] private List<SceneMover> sceneMovers;
        
        [HideInInspector] public Location currentLocation;

        private void Awake()
        {
            currentLocation = sceneMovers[0].HideLocation;
        }

        public SceneMover GetSceneMoverAtCurrentLocation()
        {
            foreach (var sceneMover in sceneMovers)
            {
                if (sceneMover.HideLocation == currentLocation)
                {
                    return sceneMover;
                }
            }
            
            Debug.LogError($"Doesn't have sceneMover at currentLocation");
            throw new Exception();
        }
    }
}