using UnityEngine;

public class Cannon : MonoBehaviour
{
    private TankData _tankData;

    public void Init(TankData tankData)
    {
        _tankData = tankData;
    }
    
    private void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * _tankData.cannonForce);
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision coll)
    {
        coll.gameObject.GetComponent<IDamageable>()?.TakeDamage(_tankData.cannonDamage);

        // if (coll.gameObject.TryGetComponent<IDamageable>(out var damageable))
        // {
        //     damageable.TakeDamage(_tankData.cannonDamage);
        // }
        
        
        var effect = Instantiate(_tankData.explosionPrefab, coll.contacts[0].point, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
    }
}
