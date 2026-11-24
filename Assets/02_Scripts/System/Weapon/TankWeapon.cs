using UnityEngine;

namespace TankAttack
{
    public class TankWeapon : MonoBehaviour
    {
        [SerializeField] private Transform _firePos;
    
        private TankData _tankData;
        private InputManager _inputManager;
        private bool _isMine;

        public void Init(Tank tank)
        {
            _tankData = tank.TankData;
            _inputManager = tank.Input;
            _isMine = tank.IsMine;
        }

        private void OnEnable()
        {
            if (!_isMine) return;
            _inputManager.OnFireInput += Fire;
        }

        private void OnDisable()
        {
            if (!_isMine) return;
            _inputManager.OnFireInput -= Fire;
        }

        private void Fire()
        {
            GameObject cannon = Instantiate(_tankData.cannonPrefab, _firePos.position, _firePos.rotation);
            cannon.GetComponent<Cannon>().Init(_tankData);
        }
    }
}
