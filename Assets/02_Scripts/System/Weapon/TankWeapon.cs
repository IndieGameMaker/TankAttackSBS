using Photon.Pun;
using UnityEngine;

/*
 * RPC (Remote Procedure Call)
 * 다른 PC에 있는 함수를 호출
 */
namespace TankAttack
{
    public class TankWeapon : MonoBehaviourPun
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
            _inputManager.OnFireInput += FireAction;
        }

        private void OnDisable()
        {
            if (!_isMine) return;
            _inputManager.OnFireInput -= FireAction;
        }

        // RPC 호출
        private void FireAction()
        {
            if (!_isMine) return;

            // Fire(); // 로컬 메서드를 호출
            // 다른 네트워크 유저의 Fire 호출
            photonView.RPC(nameof(Fire), RpcTarget.AllViaServer);
            
            AudioManager.Instance.PlayFireSfx();
        }
        
        [PunRPC]
        private void Fire()
        {
            GameObject cannon = Instantiate(_tankData.cannonPrefab, _firePos.position, _firePos.rotation);
            cannon.GetComponent<Cannon>().Init(_tankData);
        }
    }
}
