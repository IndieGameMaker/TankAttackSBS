using UnityEngine;

namespace TankAttack
{
    public class TankMovement : MonoBehaviour
    {
        private TankData _tankData;
        private InputManager _inputManager;
        private bool _isMine;

        private float h, v;
        private Rigidbody _rb;

        // 부드러운 이동처리를 위한 변수 Vector2.SmoothDamp
        private Vector2 _moveInput; // 목표값
        private Vector2 _smoothMoveInput; // 현재값
        private Vector2 _currentVelocity; // 내부적으로 사용하는 변수

        #region Unity Methods

        private void OnEnable()
        {
            if (!_isMine) return;
            if (_inputManager != null)
            {
                _inputManager.OnMoveInput += Move;
            }
        }

        private void OnDisable()
        {
            if (!_isMine) return;
            if (_inputManager != null)
            {
                _inputManager.OnMoveInput -= Move;
            }
        }

        private void FixedUpdate()
        {
            if (!_isMine) return;
            
            // 전진 후진 벡터
            Vector3 moveVelocity = transform.forward * _tankData.moveSpeed * v;

            // 일정한 힘으로 바닦으로 힘을 가함
            moveVelocity.y = _rb.linearVelocity.y - 10.0f * Time.fixedDeltaTime;
            _rb.linearVelocity = moveVelocity;

            // 회전 처리 로직
            Quaternion rot = Quaternion.Euler(0f, h * _tankData.turnSpeed * Time.fixedDeltaTime, 0f);
            _rb.MoveRotation(_rb.rotation * rot);
        }

        private void Update()
        {
            if (_isMine)
            {
                SmoothMoveInput();
            }
        }

        #endregion


        #region User Methods

        // Tank 초기화 메서드 : 각종 컴포넌트 데이터 설정
        public void Init(Tank tank)
        {
            _tankData = tank.TankData;
            _inputManager = tank.Input;
            _isMine = tank.IsMine;

            InitTankPhysics();
        }

        // 물리엔진 초기화 메서드
        private void InitTankPhysics()
        {
            _rb = GetComponent<Rigidbody>();
            if (!_isMine)
            {
                // 다른 유저의 탱크인 경우 물리 적용을 하지 않는다.
                _rb.isKinematic = true;
            }
        }

        private void Move(Vector2 moveInput)
        {
            // h = moveInput.x;
            // v = moveInput.y;

            _moveInput = moveInput;
        }

        // 부드러운 입력값 처리
        private void SmoothMoveInput()
        {
            // 입력값 보간
            _smoothMoveInput =
                Vector2.SmoothDamp(_smoothMoveInput, _moveInput, ref _currentVelocity, _tankData.smoothTime);
            h = _smoothMoveInput.x;
            v = _smoothMoveInput.y;
        }

        #endregion
    }
}