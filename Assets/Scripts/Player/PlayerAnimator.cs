using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator), typeof(PlayerMove), typeof(SpriteRenderer))]
    public class PlayerAnimator : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private PlayerMove _playerMove;
        private Animator _animator;
        private MoveDirection _currentDirection = MoveDirection.Right;
        private static readonly int IsTop = Animator.StringToHash("IsTop");
        private static readonly int IsDown = Animator.StringToHash("IsDown");
        private static readonly int HorizontalMove = Animator.StringToHash("HorizontalMove");
        private static readonly int VerticalMove = Animator.StringToHash("VerticalMove");

        void Start()
        {
            _animator = GetComponent<Animator>();
            _playerMove = GetComponent<PlayerMove>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            _animator.SetFloat(HorizontalMove, Mathf.Abs(_playerMove.HorizontalMove));
            _animator.SetFloat(VerticalMove, Mathf.Abs(_playerMove.VerticalMove));

            if (_playerMove.HorizontalMove < 0 )
            {
                SetDirection(MoveDirection.Left);
            }
            else if (_playerMove.HorizontalMove > 0 )
            {
                SetDirection(MoveDirection.Right);
            }
            
            else if (_playerMove.VerticalMove > 0)
            {
                SetDirection(MoveDirection.Top);
            }
            
            else if (_playerMove.VerticalMove < 0)
            {
                SetDirection(MoveDirection.Down);
            }
            
            Flip();
        }

        private void SetDirection(MoveDirection newDirection)
        {
            _currentDirection = newDirection;
            _animator.SetBool(IsTop, false);
            _animator.SetBool(IsDown, false);
            switch (newDirection)
            {
                case MoveDirection.Down:
                    _animator.SetBool(IsDown, true);
                    break;
                case MoveDirection.Top:
                    _animator.SetBool(IsTop, true);
                    break;
            }
        }

        private void Flip()
        {
            if (_currentDirection == MoveDirection.Right)
            {
                _spriteRenderer.flipX = false;
            }
            else if (_currentDirection == MoveDirection.Left)
            {
                _spriteRenderer.flipX = true;
            }
        }
    }
}
