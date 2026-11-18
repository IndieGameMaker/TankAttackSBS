using UnityEngine;

namespace TankAttack
{
    public class TankMovement : MonoBehaviour
    {
        private TankData _tankData;
        private InputManager _inputManager;

        private float h, v;
        private Rigidbody _rb;

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
            // 전진 후진 벡터
            Vector3 moveVelocity = transform.forward * _tankData.moveSpeed * v;
            
            // 일정한 힘으로 바닦으로 힘을 가함
            moveVelocity.y = _rb.linearVelocity.y - 10.0f * Time.fixedDeltaTime;
            _rb.linearVelocity = moveVelocity;
            
            // 회전 처리 로직
            Quaternion rot = Quaternion.Euler(0f, h * _tankData.turnSpeed * Time.fixedDeltaTime , 0f);
            _rb.MoveRotation(_rb.rotation * rot);
        }
        #endregion

        // Tank 초기화 메서드 : 각종 컴포넌트 데이터 설정
        public void Init(Tank tank)
        {
            _tankData = tank.TankData;
            _inputManager = tank.Input;
            _inputManager.OnMoveInput += Move;
            
            InitTankPhysics();
        }
        
        // 물리엔진 초기화 메서드
        private void InitTankPhysics()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Move(Vector2 moveInput)
        {
            h = moveInput.x;
            v = moveInput.y;
    
            Debug.Log($"h={h}, v={v}");
        }
    }
}

