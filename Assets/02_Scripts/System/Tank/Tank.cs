/*
 * - TankMovement
 * - TankTurret
 * - TankWeapon
 * - TankHealth
 */

using UnityEngine;

namespace TankAttack
{
    public class Tank : MonoBehaviour
    {
        [SerializeField] private TankData _tankData;
    
        // 컴포넌트 선언
        private InputManager _inputManager;
        private TankMovement _movement;
        private TankTurret _turret;
    
        // 프로퍼티 선언
        public TankData TankData => _tankData;
        public InputManager Input => _inputManager;

        private void Start()
        {
            InitComponents();
        }
    
        private void InitComponents()
        {
            _inputManager = InputManager.Instance;
            _movement = GetComponent<TankMovement>();
            _turret = GetComponent<TankTurret>();

            // 컴포넌트 초기화
            // Dependence Injection Method
            _movement.Init(this);
            _turret.Init(this, UIManager.Instance);
        }
    }
}
