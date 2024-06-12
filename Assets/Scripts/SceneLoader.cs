using ServiceLocatorSystem;
using UI.Inventory;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class SceneLoader : MonoBehaviour
{
    private Collider2D _collider;
    [SerializeField] private int sceneIndex;

    public void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LoadScene();
        }
    }

    private void LoadScene()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; 
        SceneManager.LoadScene(sceneIndex);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InventoryPanel inventoryPanel = ServiceLocator.Instance.Get<InventoryPanel>();
        if (inventoryPanel != null)
        {
            inventoryPanel.UpdateInventory(); 
        }
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}