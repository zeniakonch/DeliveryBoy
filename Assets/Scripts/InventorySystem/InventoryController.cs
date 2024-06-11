using UnityEngine;

namespace InventorySystem
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private int countSlots;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                panel.SetActive(!panel.activeInHierarchy);
            }
        }
    }
}
