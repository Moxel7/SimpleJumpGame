using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public InputActionAsset InputActionAsset;
        
        private InputAction _moveAction;
        private InputAction _jumpAction;
        
        private Vector2 _movementDir;
        
        
        private Rigidbody2D _rigidbody;
        
        public float  walkSpeed = 5f;
        public float jumpForce = 3f;

        private void OnEnable()
        {
            InputActionAsset.FindActionMap("Player").Enable();
        }

        private void OnDisable()
        {
            InputActionAsset.FindActionMap("Player").Disable();
        }

        private void Awake()
        {
            _moveAction = InputActionAsset.FindAction("Move");
            _jumpAction = InputActionAsset.FindAction("Jump");
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _movementDir = _moveAction.ReadValue<Vector2>();

            if (_jumpAction.WasPressedThisFrame())
            {
                Debug.Log("Jump");
                Jump();
            }
            Debug.Log(_movementDir);
        }

        private void FixedUpdate()
        {
            Walking();
        }

        private void Walking()
        {
            _rigidbody.linearVelocity = new Vector2(_movementDir.x * walkSpeed, _rigidbody.linearVelocity.y);
        }

        private void Jump()
        {
            _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, 0f);
            _rigidbody.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
            Debug.Log("Velocity nach Jump: " + _rigidbody.linearVelocity);
        }
    }
}
