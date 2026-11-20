using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TankAttack
{
    public class InputManager : MonoBehaviour
    {
        // InputSystem Action 변수 
        [SerializeField] private InputActionProperty moveAction;
        [SerializeField] private InputActionProperty fireAction;
        [SerializeField] private InputActionProperty scrollAction;
        
        public static InputManager Instance { get; private set; }

        // 이벤트 정의 (이동/회전, 발사, 스크롤)
        public event Action<Vector2> OnMoveInput;
        public event Action<Vector2> OnScrollInput;
        public event Action OnFireInput;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void OnEnable()
        {
            moveAction.action.Enable();

            moveAction.action.performed += OnTankMove;
            moveAction.action.canceled += OnTankMove;

            scrollAction.action.performed += OnScroll;
            scrollAction.action.canceled += OnScroll;
        }
        private void OnDisable()
        {
            moveAction.action.Disable();
            
            moveAction.action.performed -= OnTankMove;
            moveAction.action.canceled -= OnTankMove;
            
            scrollAction.action.performed -= OnScroll;
            scrollAction.action.canceled -= OnScroll;
        }

        private void OnScroll(InputAction.CallbackContext ctx)
        {
            if (ctx.phase == InputActionPhase.Performed)
            {
                OnScrollInput?.Invoke(ctx.ReadValue<Vector2>());
            }
            else if (ctx.phase == InputActionPhase.Canceled)
            {
                OnScrollInput?.Invoke(Vector2.zero);
            }
        }

        private void OnTankMove(InputAction.CallbackContext ctx)
        {
            if (ctx.phase == InputActionPhase.Canceled)
            {
                OnMoveInput?.Invoke(Vector2.zero);
                return;
            }            
            
            OnMoveInput?.Invoke(ctx.ReadValue<Vector2>());
        }
    }
}
