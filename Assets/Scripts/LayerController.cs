using Player;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    private readonly int _lowerLayer = 1;

    private readonly int _higherLayer = 2;

    private Collider2D _collider;

    private SpriteRenderer _spriteRenderer;
    
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }
        
    void Update()
    {
        float playerY = PlayerScript.Instance.Collider.bounds.min.y;
        float objectY = _collider.bounds.min.y;

        if (playerY > objectY)
        {
            _spriteRenderer.sortingOrder = _higherLayer;
            PlayerScript.Instance.SpriteRenderer.sortingOrder = _lowerLayer;
        }
        else
        {
            _spriteRenderer.sortingOrder = _lowerLayer;
            PlayerScript.Instance.SpriteRenderer.sortingOrder = _higherLayer;
        }
    }
}