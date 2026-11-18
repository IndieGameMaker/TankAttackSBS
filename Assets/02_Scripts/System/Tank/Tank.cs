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
    
        private InputManager _inputManager;
        private TankMovement _movement;
    
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

            // Dependence Injection Method
            _movement.Init(this);
        
        }
    }
}
