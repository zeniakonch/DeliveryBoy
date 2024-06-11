using UI.Inventory;
using UnityEngine;

namespace Bootstraps
{
    public class MainBootstrap : MonoBehaviour
    {
        private void Start()
        {
            InventoryPanel.Instance.Initialize();
        }
    }
}
