using System.Collections.Generic;
using UnityEngine;

namespace TankAttack
{
    public class TankHealth : MonoBehaviour, IDamageable
    {
        private TankData _tankData;
        private bool _isMine;
        private float _currHp;
        
        private List<MeshRenderer> _renderers = new();

        public void Init(Tank tank)
        {
            _tankData = tank.TankData;
            _isMine   = tank.IsMine;
            _currHp = _tankData.maxHp;
            
            GetComponentsInChildren<MeshRenderer>(_renderers);
        }

        public void TakeDamage(float damage, int actorNumber)
        {
            Debug.Log($"피격: {damage}");
            _currHp -= damage;

            if (_currHp <= 0.0f)
            {
                Die(actorNumber);
            }
        }

        private void Die(int actorNumber)
        {
            Debug.Log($"사망 : {actorNumber}");
            SetTankVisible(false);
        }
        
        // 탱크의 랜더러를 활성화/비활성화 메서드
        private void SetTankVisible(bool visible)
        {
            foreach (var renderer in _renderers)
            {
                renderer.enabled = visible;
            }
        }
    }
}
