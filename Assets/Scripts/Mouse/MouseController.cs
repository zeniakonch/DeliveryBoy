using System;
using InventorySystem;
using JetBrains.Annotations;
using UnityEngine;

namespace Mouse
{
    public class MouseController : MonoBehaviour
    {
        public static MouseController Instance;

        private void Awake()
        {
            Instance = this;
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                GameObject obj = GetGameObjectUnderCursor();
                if (obj != null)
                {
                    MovableObject movableObject = obj.GetComponent<MovableObject>();
                    if (movableObject != null)
                    {
                        movableObject.PickUp();
                    }
                }
                
            }
        }

        [CanBeNull]
        private GameObject GetGameObjectUnderCursor()
        {
            Ray2D ray = new Ray2D(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                return hit.collider.gameObject;
            }

            return null;
        }
    }
}