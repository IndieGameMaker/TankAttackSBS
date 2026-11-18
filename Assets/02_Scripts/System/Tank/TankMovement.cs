using UnityEngine;

namespace TankAttack
{
    public class TankMovement : MonoBehaviour
    {
        private TankData _tankData;
        private InputManager _inputManager;

        private float h, v;

        #region Unity Methods
        private void OnEnable()
        {
            if (_inputManager != null)
            {
                _inputManager.OnMoveInput += Move;
            }
        }

        private void OnDisable()
        {
            if (_inputManager != null)
            {
                _inputManager.OnMoveInput -= Move;
            }
        }

        private void FixedUpdate()
        {
            // 이동처리 로직
            Vector3 moveVelocity = transform.forward * _tankData.moveSpeed * v;
        }
        
        
        #endregion

        public void Init(Tank tank)
        {
            _tankData = tank.TankData;
            _inputManager = tank.Input;
            _inputManager.OnMoveInput += Move;
        }

        private void Move(Vector2 moveInput)
        {
            h = moveInput.x;
            v = moveInput.y;
    
            Debug.Log($"h={h}, v={v}");
        }
    }
}

