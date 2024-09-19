using _knockBalls.Scripts.Bullet;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _knockBalls.Scripts.Input
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private BulletManager _bulletManager;
        private Camera _mainCamera;
        
        private PlayerInput _playerInput;
        
        private void Awake()
        {
            _playerInput = new PlayerInput();
            _mainCamera = Camera.main;
        }

        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }

        private bool TouchedThisFrame()
        {
            return _playerInput.Player.Touch.triggered;
        }
        
        private void Update()
        {
            // mobile touch
            if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
            {
                var touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
                var worldPos = _mainCamera.ScreenToWorldPoint(new Vector3(touchPos.x, touchPos.y, 50));
                _bulletManager.ShootTheBullet(worldPos);
            }
            
            // mouse touch
            if (TouchedThisFrame())
            {
                var mousePos = Mouse.current.position.ReadValue();
                var worldPos = _mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 50));
                _bulletManager.ShootTheBullet(worldPos);
            }
        }
    }
}
