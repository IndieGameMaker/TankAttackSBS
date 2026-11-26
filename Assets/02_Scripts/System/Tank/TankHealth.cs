using UnityEngine;

namespace TankAttack
{
    public class TankHealth : MonoBehaviour, IDamageable
    {
        private TankData _tankData;
        private bool _isMine;
        private float _currHp;

        public void Init(Tank tank)
        {
            _tankData = tank.TankData;
            _isMine   = tank.IsMine;
            _currHp = _tankData.maxHp;
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
        }
    }
}
