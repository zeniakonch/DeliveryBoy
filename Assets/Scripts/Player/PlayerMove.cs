using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMove : MonoBehaviour
    {
        private Rigidbody2D _rb;
        public float HorizontalMove { get; private set; } = 0f;
        public float VerticalMove { get; private set; } = 0f;
        [SerializeField]
        private float speed = 1f;
    
    
        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
    
        void Update()
        {
            HorizontalMove = Input.GetAxis("Horizontal") * speed;
            VerticalMove = Input.GetAxis("Vertical") * speed;
        }
    
        private void FixedUpdate()
        {
            Vector2 targetVelocity = new Vector2(HorizontalMove * 10f, VerticalMove * 10f);
            _rb.velocity = targetVelocity;
        }
    }
}
