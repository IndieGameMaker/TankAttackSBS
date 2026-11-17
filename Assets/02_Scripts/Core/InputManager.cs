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
        }
        private void OnDisable()
        {
            moveAction.action.Disable();
            
            moveAction.action.performed -= OnTankMove;
        }

        private void OnTankMove(InputAction.CallbackContext ctx)
        {
            Debug.Log(ctx.ReadValue<Vector2>());
        }
    }
}
