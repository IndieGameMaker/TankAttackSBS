/*
 * - TankMovement
 * - TankTurret
 * - TankWeapon
 * - TankHealth
 */
using Photon.Pun;
using Unity.Cinemachine;
using UnityEngine;

namespace TankAttack
{
    public class Tank : MonoBehaviourPun
    {
        [SerializeField] private TankData _tankData;
    
        // 컴포넌트 선언
        private InputManager _inputManager;
        private TankMovement _movement;
        private TankTurret _turret;
    
        // 프로퍼티 선언
        public TankData TankData => _tankData;
        public InputManager Input => _inputManager;
        public bool IsMine => photonView.IsMine;

        private void Awake()
        {
            if (IsMine) InitLocalPlayer();
        }
        
        private void Start()
        {
            InitComponents();
        }

        private void InitLocalPlayer()
        {
            // 자신의 탱크만 컨트롤하기 위해 InputManager 초기화
            _inputManager = InputManager.Instance;
            // 시네머신 카메라 설정
            FindAnyObjectByType<CinemachineCamera>().Follow = transform;
        }
        
        private void InitComponents()
        {
            _movement = GetComponent<TankMovement>();
            _turret = GetComponent<TankTurret>();

            // 컴포넌트 초기화
            // Dependence Injection Method
            _movement.Init(this);
            _turret.Init(this, UIManager.Instance);
        }
    }
}
