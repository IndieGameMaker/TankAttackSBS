using UnityEngine;

namespace TankAttack
{
    public class TankTurret : MonoBehaviour
    {
        [SerializeField] private Transform _turretTr;
        [SerializeField] private Transform _cannonTr;
        
        private TankData _tankData;
        private InputManager _inputManager;
        private UIManager _uiManager;

        public void Init(Tank tank, UIManager uiManager)
        {
            _tankData = tank.TankData;
            _inputManager = tank.Input;
            _uiManager = uiManager;
        }
    }
}
