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

        private Camera _mainCamera;
        
        public void Init(Tank tank, UIManager uiManager)
        {
            _tankData = tank.TankData;
            _inputManager = tank.Input;
            _uiManager = uiManager;
            
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            DetectTarget();
        }
        
        private void DetectTarget()
        {
            Vector2 screenPoint = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
            //Ray 생성
            Ray ray = _mainCamera.ScreenPointToRay(screenPoint);
            Debug.DrawRay(ray.origin, ray.direction * 100.0f, Color.green);

            if (Physics.Raycast(ray, out RaycastHit hit, _tankData.maxDistance, 1 << 8))
            {
                // 타겟 검출 되었을 때
                _uiManager.SetDetectTarget(true);
                _uiManager.SetTargetDistance(hit.distance);
            }
            else
            {
                _uiManager.SetDetectTarget(false);
                _uiManager.SetTargetDistance(0);
            }
        }
    }
}
