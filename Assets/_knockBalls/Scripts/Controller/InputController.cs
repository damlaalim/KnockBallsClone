using UnityEngine;
using UnityEngine.InputSystem;

namespace _knockBalls.Scripts.Controller
{
    public class InputController : MonoBehaviour
    {
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
                var worldPosition = _mainCamera.ScreenToWorldPoint(new Vector3(touchPos.x, touchPos.y, _mainCamera.nearClipPlane));
            }
            
            // mouse touch
            if (TouchedThisFrame())
            {
                var mousePosition = Mouse.current.position.ReadValue();
                var worldPosition = _mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, _mainCamera.nearClipPlane));
            }
        }
    }
}
