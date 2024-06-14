using System;
using Player;
using ServiceLocatorSystem;
using UnityEngine;

public class LayerController : MonoBehaviour
{
    private readonly int _lowerLayer = 1;
    private readonly int _higherLayer = 2;
    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private PlayerScript _player;
    
    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<Collider2D>();
    }

    private void Start()
    {
        _player = ServiceLocator.Instance.Get<PlayerScript>();
    }

    void Update()
    {
        float playerY = _player.Collider.bounds.min.y;
        float objectY = _collider.bounds.min.y;

        if (playerY > objectY)
        {
            _spriteRenderer.sortingOrder = _higherLayer;
            _player.SpriteRenderer.sortingOrder = _lowerLayer;
        }
        else
        {
            _spriteRenderer.sortingOrder = _lowerLayer;
            _player.SpriteRenderer.sortingOrder = _higherLayer;
        }
    }
}